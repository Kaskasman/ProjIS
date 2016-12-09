using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // AUTHENTICATION
        [WebInvoke(Method = "POST", UriTemplate = "/signup?token={token}")]
        [OperationContract]
        void SignUp(User user, string token); // admin only

        [WebInvoke(Method = "POST", UriTemplate = "/login?username={username}&password={password}")]
        [OperationContract]
        string LogIn(string username, string password);

        [WebInvoke(Method = "POST", UriTemplate = "/logout")]
        [OperationContract]
        void LogOut(string token);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/isadmin?token={token}")]
        bool IsAdmin(string token);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/isloggedin?token={token}")]
        bool IsLoggedIn(string token);

        // ------ PARA FAZER ------

        // ADD 
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/vegetal?token={token}")]
        void AddVegetal(Vegetal vegetal, string token); 

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/exercicio?token={token}")]
        void AddExercicio(Exercicio exercicio, string token); 

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/restaurante?token={token}")]
        void AddPrato(Restaurante restaurante, string token); 

        // DELETE 
        [OperationContract(Name = "DeleteVegetalByNome")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/vegetal/{title}?token={token}")]
        void DeleteVegetal(string title, string token); 

        [OperationContract(Name = "DeleteExercicioByNome")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/exercicio/{title}?token={token}")]
        void DeleteExercicio(string title, string token); 

        // ----- delete refeicao tem de ter restaurante e prato -----
        [OperationContract(Name = "DeleteRefeicaoByNome")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/restaurante/{title}?token={token}")]
        void DeletePrato(string title, string token);

        // GET
        [OperationContract(Name = "GetBookByTitle")]
        [WebInvoke(Method = "GET", UriTemplate = "/book/{title}?token={token}")]
        Vegetal GetCaloriasByVegetal(string title, string token);

        [OperationContract(Name = "GetBookByTitle")]
        [WebInvoke(Method = "GET", UriTemplate = "/book/{title}?token={token}")]
        Exercicio GetCaloriasByExercicio(string title, string token);

        [OperationContract(Name = "GetBookByTitle")]
        [WebInvoke(Method = "GET", UriTemplate = "/book/{title}?token={token}")]
        Restaurante GetCaloriasByPrato(string title, string token);

        [OperationContract(Name = "GetBooksByCategory")]
        [WebInvoke(Method = "GET", UriTemplate = "/books/{category}?token={token}")]
        List<Vegetal> GetVegetaisByCalorias(string category, string token);

        [OperationContract(Name = "GetBooksByCategory")]
        [WebInvoke(Method = "GET", UriTemplate = "/books/{category}?token={token}")]
        List<Exercicio> GetExerciciosByCalorias(string category, string token);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class User
    {
        private string username;
        private string password;
        private bool admin;

        public User(string username, string password, bool admin)
        {
            this.admin = admin;
            this.username = username;
            this.password = password;
        }

        [DataMember]
        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }

    [DataContract]
    public class Vegetal
    {
        private string nome;
        private string calorias;
        private string dose;
        private string estado;

        public Vegetal(string nome, string estado, string calorias, string dose)
        {
            this.nome = nome;
            this.estado = estado;
            this.calorias = calorias;
            this.dose = dose;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        public string Dose
        {
            get { return dose; }
            set { dose = value; }
        }

        public override string ToString()
        {
            return nome + "|" + estado + "|" + calorias + " kcal|" + dose;
        }
    }

    [DataContract]
    public class Restaurante
    {
        private string nomeRestaurante;
        private string nome;
        private string quantidade;
        private string calorias;

        public Restaurante(string nomeRestaurante, string nome, string quantidade, string calorias)
        {
            this.nomeRestaurante = nomeRestaurante;
            this.nome = nome;
            this.quantidade = quantidade;
            this.calorias = calorias;
        }

        public string NomeRestaurante
        {
            get { return nomeRestaurante; }
            set { nomeRestaurante = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public string Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        public override string ToString()
        {
            return nomeRestaurante + " " + nome + " " + quantidade + " " + calorias;
        }
    }

    [DataContract]
    public class Exercicio
    {
        private string nome;
        private int calorias;
        private float met;

        public Exercicio(string nome, int calorias, float met)
        {
            this.Nome = nome;
            this.Calorias = calorias;
            this.Met = met;
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public int Calorias
        {
            get
            {
                return calorias;
            }

            set
            {
                calorias = value;
            }
        }

        public float Met
        {
            get
            {
                return met;
            }

            set
            {
                met = value;
            }
        }

        public override string ToString()
        {
            return nome + " " + calorias + " " + met;
        }
    }
}
