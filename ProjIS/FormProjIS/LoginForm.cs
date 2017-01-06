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
    public partial class LoginForm : Form
    {
        private Service1 client;
        private string token;
        private string user;

        public LoginForm()
        {
            InitializeComponent();
            this.client = client;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                user = textBoxUsername.Text;
                token = client.LogIn(textBoxUsername.Text, textBoxPassword.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                MessageBox.Show(ex.Message, "ERROR");
            }
            this.Close();
        }

        public string Token
        {
            get
            {
                return token;
            }
        }

        public string User
        {
            get
            {
                return user;
            }
        }
    }
}
