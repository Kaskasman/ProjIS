namespace FormProjIS
{
    partial class AddExercicio
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxMet = new System.Windows.Forms.TextBox();
            this.textBoxKCal = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelMet = new System.Windows.Forms.Label();
            this.labelKCal = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(135, 102);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(216, 103);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 22;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxMet
            // 
            this.textBoxMet.Location = new System.Drawing.Point(54, 64);
            this.textBoxMet.Name = "textBoxMet";
            this.textBoxMet.Size = new System.Drawing.Size(237, 20);
            this.textBoxMet.TabIndex = 19;
            // 
            // textBoxKCal
            // 
            this.textBoxKCal.Location = new System.Drawing.Point(54, 38);
            this.textBoxKCal.Name = "textBoxKCal";
            this.textBoxKCal.Size = new System.Drawing.Size(237, 20);
            this.textBoxKCal.TabIndex = 18;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(54, 12);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(237, 20);
            this.textBoxNome.TabIndex = 17;
            // 
            // labelMet
            // 
            this.labelMet.AutoSize = true;
            this.labelMet.Location = new System.Drawing.Point(17, 67);
            this.labelMet.Name = "labelMet";
            this.labelMet.Size = new System.Drawing.Size(31, 13);
            this.labelMet.TabIndex = 14;
            this.labelMet.Text = "Met: ";
            // 
            // labelKCal
            // 
            this.labelKCal.AutoSize = true;
            this.labelKCal.Location = new System.Drawing.Point(13, 41);
            this.labelKCal.Name = "labelKCal";
            this.labelKCal.Size = new System.Drawing.Size(35, 13);
            this.labelKCal.TabIndex = 13;
            this.labelKCal.Text = "KCal: ";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(7, 15);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(41, 13);
            this.labelNome.TabIndex = 12;
            this.labelNome.Text = "Nome: ";
            // 
            // AddExercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 143);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxMet);
            this.Controls.Add(this.textBoxKCal);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelMet);
            this.Controls.Add(this.labelKCal);
            this.Controls.Add(this.labelNome);
            this.Name = "AddExercicio";
            this.Text = "AddExercicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxMet;
        private System.Windows.Forms.TextBox textBoxKCal;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelMet;
        private System.Windows.Forms.Label labelKCal;
        private System.Windows.Forms.Label labelNome;
    }
}