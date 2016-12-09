using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // chave: username
        // valor: objeto user
        private Dictionary<string, User> users;

        // chave: uid
        // valor: objeto Token
        private Dictionary<string, Token> tokens;

        private static string FILEPATH;

        private class Token
        {
            private string value; // uid
            private long timeout; // daqui a quanto tempo é que o token deixa de ser valido
            private User user; // user ao qual o token está assiciado

            public Token(User user) : this(user, 240000) // token válido por 4 minutos 
            { }

            public Token(User user, long timeout)
            {
                this.value = Guid.NewGuid().ToString();
                this.timeout = Environment.TickCount + timeout;
                this.user = user;
            }

            public string Value
            {
                get { return value; }
            }

            public long Timeout
            {
                get { return timeout; }
            }

            public User User
            {
                get { return user; }
            }

            public string Username
            {
                get { return user.Username; }
            }

            public void UpdateTimeout()
            {
                UpdateTimeout(240000); // token renovado por 4 minutos
            }

            public void UpdateTimeout(long timeout)
            {
                this.timeout = Environment.TickCount + timeout;
            }

            public Boolean isTimeoutExpired()
            {
                return Environment.TickCount > timeout;
            }
        }

        public Service1()
        {
            // instacia os dois Dictionaries
            this.users = new Dictionary<string, User>();
            this.tokens = new Dictionary<string, Token>();

            // default administrator
            // cria um primeiro utilizador de administração
            users.Add("admin", new User("admin", "admin", true));

            // define a filepath do ficheiro bookstore.xml
            //FILEPATH = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "bookstore.xml");
        }

        public void SignUp(User user, string token)
        {
            checkAuthentication(token, true);

            // ver se o username ja existe
            if (users.Keys.Contains(user.Username))
            {
                throw new ArgumentException("ERROR: username already exists: " + user.Username);
            }

            // acrescenta o user recebido ao dicionario utilizado 
            // o username como chave
            users.Add(user.Username, user);
        }

        public string LogIn(string username, string password)
        {
            cleanUpTokens();

            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password) && password.Equals(users[username].Password))
            {
                Token tokenObject = new Token(users[username]);
                tokens.Add(tokenObject.Value, tokenObject);
                return tokenObject.Value;
            }
            else
            {
                throw new ArgumentException("ERROR: invalid username/password combination.");
            }
        }

        public void LogOut(string token)
        {
            tokens.Remove(token);
            cleanUpTokens();
        }

        public bool IsAdmin(string token)
        {
            return tokens[token].User.Admin;
        }

        public bool IsLoggedIn(string token)
        {
            bool res = true;

            try
            {
                checkAuthentication(token, false);
            }
            catch (ArgumentException)
            {
                res = false;
            }
            return res;
        }

        private void cleanUpTokens()
        {
            // percorre os Tokens que estão no dictionary e remove-os se já tiverem expirados
            foreach (Token tokenObject in tokens.Values)
            {
                if (tokenObject.isTimeoutExpired())
                {
                    tokens.Remove(tokenObject.Username);
                }
            }
        }

        private Token checkAuthentication(string token, bool mustBeAdmin)
        {
            Token tokenObject;

            if (String.IsNullOrEmpty(token))
            {
                throw new ArgumentException("ERROR: invalid token value.");
            }

            try
            {
                tokenObject = tokens[token];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("ERROR: user is not logged in (expired session?).");
            }

            if (tokenObject.isTimeoutExpired())
            {
                tokens.Remove(tokenObject.Username);
                throw new ArgumentException("ERROR: the session has expired. Please log in again.");
            }

            // se chegou aqui é porque: 
            // - o uid passado nao é nulo
            // - o uid existe no dicionario de tokens, e foi possivel obter o objeto Token
            // - o Token tem um timeout que ainda nao expirou
            // caso contrario, teria sido lançada uma ArgumentException com uma explicacao do erro

            // aqui vai-se verificar se, caso o parametro mustBeAdmin esteja a true, o user ao qual foi dado o token é admin
            if (mustBeAdmin && !tokens[token].User.Admin)
            {
                throw new ArgumentException("ERROR: only admins are allowed to perform this operation.");
            }

            // quando se chega aqui é porque o token é valido, e renova-lo em 4 min
            tokenObject.UpdateTimeout();
            return tokenObject;
        }

        // ------ PARA FAZER ------

        // ADD
        public void AddVegetal(Vegetal vegatal, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode bookstoreNode = doc.SelectSingleNode("/bookstore");
            XmlElement bookNode = doc.CreateElement("book");
            bookNode.SetAttribute("CATEGORY", book.Category);
            XmlElement titleNode = doc.CreateElement("title");
            titleNode.InnerText = book.Title;
            bookNode.AppendChild(titleNode);
            XmlElement authorNode = doc.CreateElement("author");
            authorNode.InnerText = book.Author;
            bookNode.AppendChild(authorNode);
            XmlElement yearNode = doc.CreateElement("year");
            yearNode.InnerText = book.Year.ToString();
            bookNode.AppendChild(yearNode);
            XmlElement priceNode = doc.CreateElement("price");
            priceNode.InnerText = Convert.ToString(book.Price, NumberFormatInfo.InvariantInfo);
            bookNode.AppendChild(priceNode);
            bookstoreNode.AppendChild(bookNode);
            doc.Save(FILEPATH);
        }

        public void AddExercicio(Exercicio exercicio, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode bookstoreNode = doc.SelectSingleNode("/bookstore");
            XmlElement bookNode = doc.CreateElement("book");
            bookNode.SetAttribute("CATEGORY", book.Category);
            XmlElement titleNode = doc.CreateElement("title");
            titleNode.InnerText = book.Title;
            bookNode.AppendChild(titleNode);
            XmlElement authorNode = doc.CreateElement("author");
            authorNode.InnerText = book.Author;
            bookNode.AppendChild(authorNode);
            XmlElement yearNode = doc.CreateElement("year");
            yearNode.InnerText = book.Year.ToString();
            bookNode.AppendChild(yearNode);
            XmlElement priceNode = doc.CreateElement("price");
            priceNode.InnerText = Convert.ToString(book.Price, NumberFormatInfo.InvariantInfo);
            bookNode.AppendChild(priceNode);
            bookstoreNode.AppendChild(bookNode);
            doc.Save(FILEPATH);
        }

        public void AddPrato(Restaurante restaurante, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode bookstoreNode = doc.SelectSingleNode("/bookstore");
            XmlElement bookNode = doc.CreateElement("book");
            bookNode.SetAttribute("CATEGORY", book.Category);
            XmlElement titleNode = doc.CreateElement("title");
            titleNode.InnerText = book.Title;
            bookNode.AppendChild(titleNode);
            XmlElement authorNode = doc.CreateElement("author");
            authorNode.InnerText = book.Author;
            bookNode.AppendChild(authorNode);
            XmlElement yearNode = doc.CreateElement("year");
            yearNode.InnerText = book.Year.ToString();
            bookNode.AppendChild(yearNode);
            XmlElement priceNode = doc.CreateElement("price");
            priceNode.InnerText = Convert.ToString(book.Price, NumberFormatInfo.InvariantInfo);
            bookNode.AppendChild(priceNode);
            bookstoreNode.AppendChild(bookNode);
            doc.Save(FILEPATH);
        }

        // DELETE
        public void DeleteVegetal(string title, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode bookstoreNode = doc.SelectSingleNode("/bookstore");
            XmlNode bookNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']");

            if (bookNode != null)
            {
                bookstoreNode.RemoveChild(bookNode);
                doc.Save(FILEPATH);
            }
        }

        public void DeleteExercicio(string title, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode bookstoreNode = doc.SelectSingleNode("/bookstore");
            XmlNode bookNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']");

            if (bookNode != null)
            {
                bookstoreNode.RemoveChild(bookNode);
                doc.Save(FILEPATH);
            }
            checkAuthentication(token, true);
        }

        public void DeletePrato(string title, string token) 
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode bookstoreNode = doc.SelectSingleNode("/bookstore");
            XmlNode bookNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']");

            if (bookNode != null)
            {
                bookstoreNode.RemoveChild(bookNode);
                doc.Save(FILEPATH);
            }
        }

        // GET
        public Vegetal GetCaloriasByVegetal(string title, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode titleNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/title");

            if (titleNode == null)
            {
                return null;
            }

            XmlNode authorNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/author");
            XmlNode yearNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/year");
            XmlNode priceNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/price");
            XmlNode categoryNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/@CATEGORY");
            Book book = new Book(titleNode.InnerText, authorNode.InnerText, Convert.ToInt32(yearNode.InnerText), Convert.ToDouble(priceNode.InnerText, NumberFormatInfo.InvariantInfo), categoryNode.InnerText);

            return book;
        }

        public Exercicio GetCaloriasByExercicio(string title, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode titleNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/title");

            if (titleNode == null)
            {
                return null;
            }

            XmlNode authorNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/author");
            XmlNode yearNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/year");
            XmlNode priceNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/price");
            XmlNode categoryNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/@CATEGORY");
            Book book = new Book(titleNode.InnerText, authorNode.InnerText, Convert.ToInt32(yearNode.InnerText), Convert.ToDouble(priceNode.InnerText, NumberFormatInfo.InvariantInfo), categoryNode.InnerText);

            return book;
        }

        public Restaurante GetCaloriasByPrato(string title, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNode titleNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/title");

            if (titleNode == null)
            {
                return null;
            }

            XmlNode authorNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/author");
            XmlNode yearNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/year");
            XmlNode priceNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/price");
            XmlNode categoryNode = doc.SelectSingleNode("/bookstore/book[title='" + title + "']/@CATEGORY");
            Book book = new Book(titleNode.InnerText, authorNode.InnerText, Convert.ToInt32(yearNode.InnerText), Convert.ToDouble(priceNode.InnerText, NumberFormatInfo.InvariantInfo), categoryNode.InnerText);

            return book;
        }

        public List<Vegetal> GetVegetaisByCalorias(string category, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNodeList bookNodes = doc.SelectNodes("/bookstore/book[@CATEGORY='" + category + "']");
            List<Book> books = new List<Book>();

            foreach (XmlNode bookNode in bookNodes)
            {
                XmlNode titleNode = bookNode.SelectSingleNode("title");
                XmlNode authorNode = bookNode.SelectSingleNode("author");
                XmlNode yearNode = bookNode.SelectSingleNode("year");
                XmlNode priceNode = bookNode.SelectSingleNode("price");
                XmlAttribute categoryNode = bookNode.Attributes["CATEGORY"];
                Book book = new Book(titleNode.InnerText, authorNode.InnerText, Convert.ToInt32(yearNode.InnerText), Convert.ToDouble(priceNode.InnerText, NumberFormatInfo.InvariantInfo), categoryNode.Value);
                books.Add(book);
            }

            return books;
        }

        public List<Exercicio> GetExerciciosByCalorias(string category, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            XmlNodeList bookNodes = doc.SelectNodes("/bookstore/book[@CATEGORY='" + category + "']");
            List<Book> books = new List<Book>();

            foreach (XmlNode bookNode in bookNodes)
            {
                XmlNode titleNode = bookNode.SelectSingleNode("title");
                XmlNode authorNode = bookNode.SelectSingleNode("author");
                XmlNode yearNode = bookNode.SelectSingleNode("year");
                XmlNode priceNode = bookNode.SelectSingleNode("price");
                XmlAttribute categoryNode = bookNode.Attributes["CATEGORY"];
                Book book = new Book(titleNode.InnerText, authorNode.InnerText, Convert.ToInt32(yearNode.InnerText), Convert.ToDouble(priceNode.InnerText, NumberFormatInfo.InvariantInfo), categoryNode.Value);
                books.Add(book);
            }

            return books;
        }
    }
}
