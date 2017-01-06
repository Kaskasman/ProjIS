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
        void AddPrato(Restaurante prato, string token); 

        // DELETE 
        [OperationContract(Name = "DeleteVegetalByNome")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/vegetal/{nome}?token={token}")]
        void DeleteVegetal(string nome, string token); 

        [OperationContract(Name = "DeleteExercicioByNome")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/exercicio/{nome}?token={token}")]
        void DeleteExercicio(string nome, string token); 

        [OperationContract(Name = "DeleteRefeicaoByNome")]
        [WebInvoke(Method = "DELETE", UriTemplate = "/restaurante/{nome}?token={token}")]
        void DeletePrato(string nome, string token);

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Android

        [OperationContract(Name = "GetInformacaoTotalAndroid")]
        [WebInvoke(Method = "POST", UriTemplate = "/GetInformacaoTotalAndroid/token={token}")]
        String GetInformacaoTotalAndroid(List<Restaurante> conjuntoPratos, string token);

        //Vegetal
        [OperationContract(Name = "GetCaloriasByVegetal")]
        [WebInvoke(Method = "POST", UriTemplate = "/vegetal/{nome}?token={token}")]
        Int32 GetCaloriasByVegetal(string nome, string token);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllVegetais?token={token}")]
        List<Vegetal> GetAllVegetais(string token);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetVegetaisByCalorias/calorias?token={token}")]
        List<Vegetal> GetVegetaisByCalorias(int calorias, string token);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetSomatorioVegetaisByCalorias/calorias?token={token}")]
        List<Vegetal> GetSomatorioVegetaisByCalorias(int calorias, string token);

        //Exercicio
        [OperationContract(Name = "GetCaloriasByExercicio")]
        [WebInvoke(Method = "POST", UriTemplate = "/exercicio/{nome}?token={token}")]
        Int32 GetCaloriasByExercicio(string nome, string token);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllExercicios?token={token}")]
        List<Exercicio> GetAllExercicios(string token);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetExerciciosByCalorias/calorias?token={token}")]
        List<Exercicio> GetExerciciosByCalorias(int calorias, string token);

        //Prato + Restaurante
        [OperationContract(Name = "GetCaloriasByPrato")]
        [WebInvoke(Method = "POST", UriTemplate = "/prato/{nome}?token={token}")]
        Int32 GetCaloriasByPrato(string nome, string token);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllPratos?token={token}")]
        List<Restaurante> GetAllPratos(string token);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllRestaurantes?token={token}")]
        List<String> GetAllRestaurantes(string token);

        [OperationContract(Name = "GetCaloriasByConjuntoPrato")]
        [WebInvoke(Method = "POST", UriTemplate = "/GetCaloriasByConjuntoPrato/token={token}")]
        Int32 GetCaloriasByConjuntoPrato(List<Restaurante> conjuntoPrato, string token);
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
        private string tipoDeDose;

        public Vegetal(string nome, string estado, string calorias, string tipoDeDose, string dose)
        {
            this.nome = nome;
            this.estado = estado;
            this.calorias = calorias;
            this.tipoDeDose = tipoDeDose;
            this.dose = dose;
        }

        [DataMember]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [DataMember]
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        [DataMember]
        public string Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        [DataMember]
        public string TipoDeDose
        {
            get { return tipoDeDose; }
            set { tipoDeDose = value; }
        }

        [DataMember]
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

        [DataMember]
        public string NomeRestaurante
        {
            get { return nomeRestaurante; }
            set { nomeRestaurante = value; }
        }

        [DataMember]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        [DataMember]
        public string Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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
