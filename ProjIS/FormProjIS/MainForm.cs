using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormProjIS
{
    public partial class MainForm : Form
    {
        Service1 client;
        private string token;
        private string user;

        public MainForm()
        {
            InitializeComponent();
            client = new Service1();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(token) && client.IsLoggedIn(token))
            {
                MessageBox.Show("A user already logged in: " + user + ". Please log out first.");
            }
            else
            {
                LoginForm formAuth = new LoginForm();
                DialogResult dialogResult = formAuth.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    token = formAuth.Token;
                    user = formAuth.User;
                    MessageBox.Show("LogIn successful: " + user);
                }
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(token) || !client.IsLoggedIn(token))
                {
                    MessageBox.Show("User is not logged in");
                }
                else
                {
                    client.LogOut(token);
                    token = null;
                    user = null;
                    MessageBox.Show("LogOut successful.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(token) || !client.IsLoggedIn(token))
            {
                MessageBox.Show("User is not logged in.");
            }
            else if (!client.IsAdmin(token))
            {
                MessageBox.Show("User does not possess administration privileges.");
            }
            else
            {
                SigninForm formSignUp = new SigninForm(client, token);
                DialogResult dialogResult = formSignUp.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    MessageBox.Show("SignUp successful.");
                }
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            try
            {
                if (String.IsNullOrEmpty(token) || !client.IsLoggedIn(token))
                {
                    MessageBox.Show("User is not logged in.");
                }
                else
                {
                    switch (comboBoxOperation.Text)
                    {
                        case "ADD - Vegetal":
                            AddVegetalForm formAddVegetal = new AddVegetalForm(client, token);
                            DialogResult dialogResultVegetal = formAddVegetal.ShowDialog();
                            if (dialogResultVegetal == DialogResult.OK)
                            {
                                MessageBox.Show("Vegetal Adicionado com Sucesso.");
                            }
                            break;

                        case "ADD - Exercicio":
                            AddExercicio formAddExercicio = new AddExercicio(client, token);
                            DialogResult dialogResultExercicio = formAddExercicio.ShowDialog();
                            if (dialogResultExercicio == DialogResult.OK)
                            {
                                MessageBox.Show("Exercicio Adicionado com Sucesso.");
                            }
                            break;

                        case "ADD - Pratos Fast Food":
                            AddPratoForm formAddPrato = new AddPratoForm(client, token);
                            DialogResult dialogResultPrato = formAddPrato.ShowDialog();
                            if (dialogResultPrato == DialogResult.OK)
                            {
                                MessageBox.Show("Exercicio Adicionado com Sucesso.");
                            }
                            break;

                        case "DELETE - Vegetal":
                            DeleteVegetalForm formDeleteVegetal = new DeleteVegetalForm(client, token);
                            DialogResult dialogResultDelVeg = formDeleteVegetal.ShowDialog();
                            if (dialogResultDelVeg == DialogResult.OK)
                            {
                                MessageBox.Show("Vegetais Eleminados com Sucesso.");
                            }
                            break;

                        case "DELETE - Exercicio":
                            DeleteExercicioForm formDeleteExercicio = new DeleteExercicioForm(client, token);
                            DialogResult dialogResultDelExer = formDeleteExercicio.ShowDialog();
                            if (dialogResultDelExer == DialogResult.OK)
                            {
                                MessageBox.Show("Exercicios Eleminados com Sucesso.");
                            }
                            break;

                        case "DELETE - Prato Fast Food":
                            DeletePratoForm formDeletePrato = new DeletePratoForm(client, token);
                            DialogResult dialogResultDelPrato = formDeletePrato.ShowDialog();
                            if (dialogResultDelPrato == DialogResult.OK)
                            {
                                MessageBox.Show("Pratos Eleminados com Sucesso.");
                            }
                            break;

                        case "GET - Vegetal BY Calorias":
                            Vegetal[] vegetais = client.GetCaloriasByVegetal(textBoxProcura.Text, token);
                            foreach (Vegetal v in vegetais)
                            {
                                textBoxOutput.Text += v.ToString() + Environment.NewLine;
                            }
                            break;

                        case "GET - Exercicio BY Calorias":
                            Exercicio[] exercicios = client.GetCaloriasByExercicio(textBoxProcura.Text, token);
                            foreach (Exercicio exer in exercicios)
                            {
                                textBoxOutput.Text += exer.ToString() + Environment.NewLine;
                            }
                            break;

                        case "GET - Pratos Fast Food BY Calorias":
                            Restaurante[] restaurantes = client.GetCaloriasByPrato(textBoxProcura.Text, token);
                            foreach (Restaurante r in restaurantes)
                            {
                                textBoxOutput.Text += r.ToString() + Environment.NewLine;
                            }
                            break;

                        default:
                            MessageBox.Show("Operation not implemented.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void buttonXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(token) || !client.IsLoggedIn(token))
                {
                    MessageBox.Show("User is not logged in.");
                }
                else
                {
                    XmlForm formXml = new XmlForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
    }
}
