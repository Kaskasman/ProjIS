namespace FormProjIS
{
    partial class AddVegetalForm
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
            this.labelNome = new System.Windows.Forms.Label();
            this.labelKCal = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelTipoDose = new System.Windows.Forms.Label();
            this.labelDose = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxKCal = new System.Windows.Forms.TextBox();
            this.textBoxEstado = new System.Windows.Forms.TextBox();
            this.textBoxTipoDose = new System.Windows.Forms.TextBox();
            this.textBoxDose = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(27, 9);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(41, 13);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome: ";
            // 
            // labelKCal
            // 
            this.labelKCal.AutoSize = true;
            this.labelKCal.Location = new System.Drawing.Point(33, 35);
            this.labelKCal.Name = "labelKCal";
            this.labelKCal.Size = new System.Drawing.Size(35, 13);
            this.labelKCal.TabIndex = 1;
            this.labelKCal.Text = "KCal: ";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(22, 61);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(46, 13);
            this.labelEstado.TabIndex = 2;
            this.labelEstado.Text = "Estado: ";
            // 
            // labelTipoDose
            // 
            this.labelTipoDose.AutoSize = true;
            this.labelTipoDose.Location = new System.Drawing.Point(6, 87);
            this.labelTipoDose.Name = "labelTipoDose";
            this.labelTipoDose.Size = new System.Drawing.Size(62, 13);
            this.labelTipoDose.TabIndex = 3;
            this.labelTipoDose.Text = "Tipo Dose: ";
            // 
            // labelDose
            // 
            this.labelDose.AutoSize = true;
            this.labelDose.Location = new System.Drawing.Point(30, 113);
            this.labelDose.Name = "labelDose";
            this.labelDose.Size = new System.Drawing.Size(38, 13);
            this.labelDose.TabIndex = 4;
            this.labelDose.Text = "Dose: ";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(74, 6);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(237, 20);
            this.textBoxNome.TabIndex = 5;
            // 
            // textBoxKCal
            // 
            this.textBoxKCal.Location = new System.Drawing.Point(74, 32);
            this.textBoxKCal.Name = "textBoxKCal";
            this.textBoxKCal.Size = new System.Drawing.Size(237, 20);
            this.textBoxKCal.TabIndex = 6;
            // 
            // textBoxEstado
            // 
            this.textBoxEstado.Location = new System.Drawing.Point(74, 58);
            this.textBoxEstado.Name = "textBoxEstado";
            this.textBoxEstado.Size = new System.Drawing.Size(237, 20);
            this.textBoxEstado.TabIndex = 7;
            // 
            // textBoxTipoDose
            // 
            this.textBoxTipoDose.Location = new System.Drawing.Point(74, 84);
            this.textBoxTipoDose.Name = "textBoxTipoDose";
            this.textBoxTipoDose.Size = new System.Drawing.Size(237, 20);
            this.textBoxTipoDose.TabIndex = 8;
            // 
            // textBoxDose
            // 
            this.textBoxDose.Location = new System.Drawing.Point(74, 110);
            this.textBoxDose.Name = "textBoxDose";
            this.textBoxDose.Size = new System.Drawing.Size(237, 20);
            this.textBoxDose.TabIndex = 9;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(236, 136);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(155, 135);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddVegetalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 170);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxDose);
            this.Controls.Add(this.textBoxTipoDose);
            this.Controls.Add(this.textBoxEstado);
            this.Controls.Add(this.textBoxKCal);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelDose);
            this.Controls.Add(this.labelTipoDose);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.labelKCal);
            this.Controls.Add(this.labelNome);
            this.Name = "AddVegetalForm";
            this.Text = "AddVegetalForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelKCal;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label labelTipoDose;
        private System.Windows.Forms.Label labelDose;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxKCal;
        private System.Windows.Forms.TextBox textBoxEstado;
        private System.Windows.Forms.TextBox textBoxTipoDose;
        private System.Windows.Forms.TextBox textBoxDose;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}