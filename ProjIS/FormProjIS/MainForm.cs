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
                            Vegetal[] vegetais = client.AddVegetal(token);
                            foreach (Vegetal b in vegetais)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "ADD - Exercicio":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "ADD - Pratos Fast Food":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "DELETE - Vegetal":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "DELETE - Exercicio":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "DELETE - Prato Fast Food":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "GET - Vegetais BY Nome":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "GET - Exercicios BY Nome":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "GET - Pratos Fast Food BY Nome":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "GET - Vegetal BY Calorias":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "GET - Exercicio BY Calorias":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
                            }
                            break;
                        case "GET - Pratos Fast Food BY Calorias":
                            Book[] books = client.GetBooks(token);
                            foreach (Book b in books)
                            {
                                textBoxOutput.Text += printBook(b) + Environment.NewLine;
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

        private string printVegetal(Book book)
        {
            return "Title: " + book.Title + Environment.NewLine
                   + "Author: " + book.Author + Environment.NewLine
                   + "Year: " + book.Year + Environment.NewLine
                   + "Price: " + book.Price + Environment.NewLine
                   + "Category: " + book.Category + Environment.NewLine;
        }

        private string printExercicio(Book book)
        {
            return "Title: " + book.Title + Environment.NewLine
                   + "Author: " + book.Author + Environment.NewLine
                   + "Year: " + book.Year + Environment.NewLine
                   + "Price: " + book.Price + Environment.NewLine
                   + "Category: " + book.Category + Environment.NewLine;
        }

        private string printRestaurante(Book book)
        {
            return "Title: " + book.Title + Environment.NewLine
                   + "Author: " + book.Author + Environment.NewLine
                   + "Year: " + book.Year + Environment.NewLine
                   + "Price: " + book.Price + Environment.NewLine
                   + "Category: " + book.Category + Environment.NewLine;
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
