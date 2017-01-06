using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Xml;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private static readonly string EXERCICIO_FILEPATH_XML = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "exercicios.xml");
        private static readonly string EXERCICIO_FILEPATH_SCHEMA = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "exerciciosSchema.xml");

        private static readonly string PRATO_FILEPATH_XML = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "restaurantes.xml");
        private static readonly string PRATO_FILEPATH_SCHEMA = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "restaurantesSchema.xml");

        private static readonly string VEGETAL_FILEPATH_XML = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "vegetais.xml");
        private static readonly string VEGETAL_FILEPATH_SCHEMA = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "vegetaisSchema.xml");

        // chave: username
        // valor: objeto user
        private Dictionary<string, User> users;

        // chave: uid
        // valor: objeto Token
        private Dictionary<string, Token> tokens;

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

        // ADMINISTRACAO

        // MIGRACAO DADOS
        // VALIDAR
        // SUBMETER

        // ADD
        public void AddVegetal(Vegetal vegetal, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(VEGETAL_FILEPATH_XML);

            XmlNode vegetaisNode = doc.SelectSingleNode("/vegetais");

            XmlElement vegetalElement = doc.CreateElement("vegetal");
            
            XmlElement vegetalNome = doc.CreateElement("nome");
            vegetalNome.InnerText = vegetal.Nome;
            vegetalElement.AppendChild(vegetalNome);

            XmlElement vegetalKcal = doc.CreateElement("kcal");
            vegetalKcal.InnerText = vegetal.Calorias;
            vegetalElement.AppendChild(vegetalKcal);

            XmlElement vegetalEstado = doc.CreateElement("estado");
            vegetalEstado.InnerText = vegetal.Estado;
            vegetalElement.AppendChild(vegetalEstado);

            XmlElement vegetalTipoDose = doc.CreateElement("tipoDose");
            vegetalTipoDose.InnerText = vegetal.TipoDeDose;
            vegetalElement.AppendChild(vegetalTipoDose);

            XmlElement vegetalDose = doc.CreateElement("dose");
            vegetalDose.InnerText = vegetal.Dose;
            vegetalElement.AppendChild(vegetalDose);

            vegetaisNode.AppendChild(vegetalElement);

            doc.Save(VEGETAL_FILEPATH_XML);
        }

        public void AddExercicio(Exercicio exercicio, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(EXERCICIO_FILEPATH_XML);

            XmlNode exercicioNode = doc.SelectSingleNode("/exercicios");

            XmlElement exercicioElement = doc.CreateElement("exercicio");
            
            XmlElement exercicioNome = doc.CreateElement("nome");
            exercicioNome.InnerText = exercicio.Nome;
            exercicioElement.AppendChild(exercicioNome);

            XmlElement exercicioKcal = doc.CreateElement("kcal");
            exercicioKcal.InnerText = exercicio.Calorias.ToString();
            exercicioElement.AppendChild(exercicioKcal);

            XmlElement exercicioMet = doc.CreateElement("met");
            exercicioMet.InnerText = exercicio.Met.ToString();
            exercicioElement.AppendChild(exercicioMet);

            exercicioNode.AppendChild(exercicioElement);

            doc.Save(EXERCICIO_FILEPATH_XML);
        }

        public void AddPrato(Restaurante prato, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(PRATO_FILEPATH_XML);

            XmlNode restaurantesNode = doc.SelectSingleNode("/restaurantes");

            XmlElement pratoElement = doc.CreateElement("prato");

            XmlElement pratoNome = doc.CreateElement("nome");
            pratoNome.InnerText = prato.Nome;
            pratoElement.AppendChild(pratoNome);

            XmlElement pratoKcal = doc.CreateElement("kcal");
            pratoKcal.InnerText = prato.Calorias;
            pratoElement.AppendChild(pratoKcal);

            XmlElement pratoQuantidade = doc.CreateElement("quantidade");
            pratoQuantidade.InnerText = prato.Quantidade;
            pratoElement.AppendChild(pratoQuantidade);

            XmlNode restauranteElement = doc.SelectSingleNode("//restaurante[@nomeRestaurante = '" + prato.NomeRestaurante + "']");

            if (restauranteElement == null)
            {
                XmlElement restaurant = doc.CreateElement("restaurante");
                restaurant.SetAttribute("name", prato.NomeRestaurante);
                restaurant.AppendChild(pratoElement);
                restauranteElement.AppendChild(restaurant);
            }
            else
            {
                restauranteElement.AppendChild(pratoElement);
            }

            restaurantesNode.AppendChild(restauranteElement);

            doc.Save(PRATO_FILEPATH_XML);
        }

        // DELETE
        public void DeleteVegetal(string nome, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(VEGETAL_FILEPATH_XML);
            XmlNode vegetaisNode = doc.DocumentElement;

            XmlNode nodeToRemove = doc.SelectSingleNode("//food[nome='" + nome + "']");
            vegetaisNode.RemoveChild(nodeToRemove);

            doc.Save(VEGETAL_FILEPATH_XML);
        }

        public void DeleteExercicio(string nome, string token)
        {
            checkAuthentication(token, true);
            XmlDocument doc = new XmlDocument();
            doc.Load(EXERCICIO_FILEPATH_XML);
            XmlNode exerciciosNode = doc.DocumentElement;

            XmlNode nodeToRemove = doc.SelectSingleNode("//exercicio[nome='" + nome + "']");
            exerciciosNode.RemoveChild(nodeToRemove);

            doc.Save(EXERCICIO_FILEPATH_XML);
        }

        public void DeletePrato(string nome, string token)
        {
            checkAuthentication(token, true);

            XmlDocument doc = new XmlDocument();
            doc.Load(PRATO_FILEPATH_XML);
            XmlNode restaurantesNode = doc.DocumentElement;
            XmlNode restauranteElement = doc.SelectSingleNode("//restaurante[prato[nome='" + nome +"']]");
            XmlNode nodeToRemove = doc.SelectSingleNode("//prato[nome='" + nome + "']");

            restauranteElement.RemoveChild(nodeToRemove);
            doc.Save(PRATO_FILEPATH_XML);
        }

        // GET

        public List<Vegetal> GetAllVegetais(string token)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(VEGETAL_FILEPATH_XML);

            XmlNodeList nodes = doc.SelectNodes("//Vegetais");
            List<Vegetal> lista = new List<Vegetal>();

            foreach (XmlNode n in nodes)
            {
                    Vegetal veg = new Vegetal(n.SelectSingleNode("nome").InnerText, n.SelectSingleNode("estado").InnerText, n.SelectSingleNode("kcal").InnerText, n.SelectSingleNode("tipoDose").InnerText, n.SelectSingleNode("dose").InnerText);

                    lista.Add(veg);
                
            }

            return lista;
        }

        public List<Exercicio> GetAllExercicios(string token)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(EXERCICIO_FILEPATH_XML);

            XmlNodeList nodes = doc.SelectNodes("//Exercicios");
            List<Exercicio> lista = new List<Exercicio>();

            foreach (XmlNode n in nodes)
            {
                Exercicio exe = new Exercicio(n.SelectSingleNode("nome").InnerText, Convert.ToInt32(n.SelectSingleNode("kcal").InnerText), float.Parse(n.SelectSingleNode("met").InnerText));

                lista.Add(exe);
            }

            return lista;
        }

        public List<Restaurante> GetAllPratos(string token)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(PRATO_FILEPATH_XML);

            XmlNodeList nodes = doc.SelectNodes("//Restaurante");
            List<Restaurante> lista = new List<Restaurante>();

            foreach (XmlNode n in nodes)
            {
                Restaurante res = new Restaurante(n.SelectSingleNode("@nomeRestaurante").InnerText, n.SelectSingleNode("nome").InnerText, n.SelectSingleNode("quantidade").InnerText, n.SelectSingleNode("kcal").InnerText);

                lista.Add(res);
            }

            return lista;
        }

        public List<String> GetAllRestaurantes(string token)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(PRATO_FILEPATH_XML);

            XmlNodeList nodes = doc.SelectNodes("//Restaurante");
            List<String> lista = new List<String>();

            foreach (XmlNode n in nodes)
            {
                String nome = n.SelectSingleNode("@nomeRestaurante").InnerText;

                lista.Add(nome);
            }

            return lista;
        }

        public Int32 GetCaloriasByVegetal(string nome, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(VEGETAL_FILEPATH_XML);
            XmlNode vegetalNode = doc.SelectSingleNode("//vegetal[nome='" + nome + "']");
            XmlNode calorias = vegetalNode.SelectSingleNode("kcal");

            int caloriasFinal = Convert.ToInt32(calorias.Value);

            return caloriasFinal;
        }

        public Int32 GetCaloriasByExercicio(string nome, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(EXERCICIO_FILEPATH_XML);
            XmlNode exercicioNode = doc.SelectSingleNode("//exercicio[nome='" + nome + "']");
            XmlNode calorias = exercicioNode.SelectSingleNode("kcal");

            int caloriasFinal = Convert.ToInt32(calorias.Value);

            return caloriasFinal;
        }

        public Int32 GetCaloriasByPrato(string nome, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(PRATO_FILEPATH_XML);
            XmlNode pratoNode = doc.SelectSingleNode("//prato[nome='" + nome + "']");
            XmlNode calorias = pratoNode.SelectSingleNode("kcal");

            int caloriasFinal = Convert.ToInt32(calorias.Value);

            return caloriasFinal;
        }

        public Int32 GetCaloriasByConjuntoPrato(List<Restaurante> conjuntoPrato, string token)
        {
            checkAuthentication(token, false);
            XmlDocument doc = new XmlDocument();
            doc.Load(PRATO_FILEPATH_XML);

            int soma = 0;

            foreach (Restaurante prato in conjuntoPrato)
            {
                soma += GetCaloriasByPrato(prato.Nome, token);
            }

            return soma;
        }

        public List<Vegetal> GetVegetaisByCalorias(int calorias, string token)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(VEGETAL_FILEPATH_XML);

            XmlNodeList nodes = doc.SelectNodes("//Vegetais");
            List<Vegetal> lista = new List<Vegetal>();

            foreach (XmlNode n in nodes)
            {
                int kcal = Convert.ToInt32(n.SelectSingleNode("kcal").InnerText);

                if ((calorias + 20 >= kcal) &&
                    (calorias - 20 <= kcal))
                {
                    Vegetal veg = new Vegetal(n.SelectSingleNode("nome").InnerText, n.SelectSingleNode("estado").InnerText, n.SelectSingleNode("kcal").InnerText, n.SelectSingleNode("tipoDose").InnerText, n.SelectSingleNode("dose").InnerText);

                    lista.Add(veg);
                }
            }

            return lista;
        }

        public List<Vegetal> GetSomatorioVegetaisByCalorias(int calorias, string token)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(VEGETAL_FILEPATH_XML);

            XmlNodeList nodes = doc.SelectNodes("//Vegetais");
            List<Vegetal> lista = new List<Vegetal>();

            foreach (XmlNode n in nodes)
            {
                int kcal = Convert.ToInt32(n.SelectSingleNode("kcal").InnerText);
                String nome = n.SelectSingleNode("nome").InnerText;

                bool aux = false;

                if (!aux)
                {
                    foreach (XmlNode m in nodes)
                    {
                        if (!aux)
                        {
                            if (nome != m.SelectSingleNode("nome").InnerText)
                            {
                                int kcalAux = Convert.ToInt32(m.SelectSingleNode("kcal").InnerText);

                                if (calorias < kcal + kcalAux)
                                {
                                    Vegetal veg = new Vegetal(n.SelectSingleNode("nome").InnerText,
                                        n.SelectSingleNode("estado").InnerText, n.SelectSingleNode("kcal").InnerText,
                                        n.SelectSingleNode("tipoDose").InnerText, n.SelectSingleNode("dose").InnerText);
                                    lista.Add(veg);

                                    Vegetal veg2 = new Vegetal(m.SelectSingleNode("nome").InnerText,
                                        m.SelectSingleNode("estado").InnerText, m.SelectSingleNode("kcal").InnerText,
                                        m.SelectSingleNode("tipoDose").InnerText, m.SelectSingleNode("dose").InnerText);
                                    lista.Add(veg2);

                                    aux = true;
                                }
                            }
                        }
                    }
                }
            }

            return lista;
        }


        public List<Exercicio> GetExerciciosByCalorias(int calorias, string token)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(EXERCICIO_FILEPATH_XML);

            XmlNodeList nodes = doc.SelectNodes("//Exercicios");
            List<Exercicio> lista = new List<Exercicio>();

            foreach (XmlNode n in nodes)
            {
                int kcal = Convert.ToInt32(n.SelectSingleNode("kcal").InnerText);

                if ((calorias + 20 >= kcal) &&
                    (calorias < kcal))
                {
                    Exercicio exe = new Exercicio(n.SelectSingleNode("nome").InnerText, kcal, float.Parse(n.SelectSingleNode("met").InnerText));

                    lista.Add(exe);
                }
            }

            return lista;
        }

        public String GetInformacaoTotalAndroid(List<Restaurante> conjuntoPratos, string token)
        {
            String info;

            int caloriasPratos = GetCaloriasByConjuntoPrato(conjuntoPratos, token);
            List<Vegetal> listaVegetais = GetSomatorioVegetaisByCalorias(caloriasPratos, token);
            List<Exercicio> listaExercicios = GetExerciciosByCalorias(caloriasPratos, token);

            String infoVeg = "";
            String infoExe = "";

            foreach (Vegetal veg in listaVegetais)
            {
                if (infoVeg != "")
                {
                    infoVeg += ", " + veg.Nome;
                }
                else
                {
                    infoVeg = veg.Nome;
                }
            }

            foreach (Exercicio exe in listaExercicios)
            {
                if (infoExe != "")
                {
                    infoExe += ", " + exe.Nome;
                }
                else
                {
                    infoExe = exe.Nome;
                }
            }

            info = "As calorias do conjunto de pratos selecionado é de: " + caloriasPratos +
                   "\nPara queimar todas as calorias ingeridas por esses pratos terá de fazer os seguintes exercicios: " +
                   infoExe +
                   "\nDeverá substituir por alimentação mais saudavel, como por exemplo este conjunto de vegetais: " +
                   infoVeg;
                
            return info;
        }
    }
}
