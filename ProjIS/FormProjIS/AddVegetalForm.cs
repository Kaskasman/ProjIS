﻿using System;
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
    public partial class AddVegetalForm : Form
    {
        private Service1 client;
        private string token;

        public AddVegetalForm(Service1 client, string token)
        {
            InitializeComponent();
            this.client = client;
            this.token = token;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Vegetal v = new Vegetal(textBoxNome.Text, textBoxEstado.Text, textBoxKCal.Text, textBoxTipoDose.Text, textBoxDose.Text);

                client.AddVegetal(v, token);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
