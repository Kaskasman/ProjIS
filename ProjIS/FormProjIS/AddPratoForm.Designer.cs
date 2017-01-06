namespace FormProjIS
{
    partial class AddPratoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRestaurante = new System.Windows.Forms.Label();
            this.comboBoxRestaurante = new System.Windows.Forms.ComboBox();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.textBoxKCal = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelQuantidade = new System.Windows.Forms.Label();
            this.labelKCal = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRestaurante
            // 
            this.labelRestaurante.AutoSize = true;
            this.labelRestaurante.Location = new System.Drawing.Point(9, 15);
            this.labelRestaurante.Name = "labelRestaurante";
            this.labelRestaurante.Size = new System.Drawing.Size(71, 13);
            this.labelRestaurante.TabIndex = 0;
            this.labelRestaurante.Text = "Restaurante: ";
            // 
            // comboBoxRestaurante
            // 
            this.comboBoxRestaurante.FormattingEnabled = true;
            this.comboBoxRestaurante.Location = new System.Drawing.Point(86, 12);
            this.comboBoxRestaurante.Name = "comboBoxRestaurante";
            this.comboBoxRestaurante.Size = new System.Drawing.Size(237, 21);
            this.comboBoxRestaurante.TabIndex = 1;
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Location = new System.Drawing.Point(86, 91);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(237, 20);
            this.textBoxQuantidade.TabIndex = 13;
            // 
            // textBoxKCal
            // 
            this.textBoxKCal.Location = new System.Drawing.Point(86, 65);
            this.textBoxKCal.Name = "textBoxKCal";
            this.textBoxKCal.Size = new System.Drawing.Size(237, 20);
            this.textBoxKCal.TabIndex = 12;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(86, 39);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(237, 20);
            this.textBoxNome.TabIndex = 11;
            // 
            // labelQuantidade
            // 
            this.labelQuantidade.AutoSize = true;
            this.labelQuantidade.Location = new System.Drawing.Point(12, 94);
            this.labelQuantidade.Name = "labelQuantidade";
            this.labelQuantidade.Size = new System.Drawing.Size(68, 13);
            this.labelQuantidade.TabIndex = 10;
            this.labelQuantidade.Text = "Quantidade: ";
            // 
            // labelKCal
            // 
            this.labelKCal.AutoSize = true;
            this.labelKCal.Location = new System.Drawing.Point(45, 68);
            this.labelKCal.Name = "labelKCal";
            this.labelKCal.Size = new System.Drawing.Size(35, 13);
            this.labelKCal.TabIndex = 9;
            this.labelKCal.Text = "KCal: ";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(39, 42);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(41, 13);
            this.labelNome.TabIndex = 8;
            this.labelNome.Text = "Nome: ";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(167, 128);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(248, 129);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // AddPratoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 162);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxQuantidade);
            this.Controls.Add(this.textBoxKCal);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelQuantidade);
            this.Controls.Add(this.labelKCal);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.comboBoxRestaurante);
            this.Controls.Add(this.labelRestaurante);
            this.Name = "AddPratoForm";
            this.Text = "AddPratoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRestaurante;
        private System.Windows.Forms.ComboBox comboBoxRestaurante;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.TextBox textBoxKCal;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelQuantidade;
        private System.Windows.Forms.Label labelKCal;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}