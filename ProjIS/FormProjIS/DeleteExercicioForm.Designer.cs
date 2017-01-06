namespace FormProjIS
{
    partial class DeleteExercicioForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.listViewExercicios = new System.Windows.Forms.ListView();
            this.columnNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnKcal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(388, 363);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // listViewExercicios
            // 
            this.listViewExercicios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNome,
            this.columnKcal,
            this.columnMet});
            this.listViewExercicios.FullRowSelect = true;
            this.listViewExercicios.GridLines = true;
            this.listViewExercicios.Location = new System.Drawing.Point(12, 12);
            this.listViewExercicios.Name = "listViewExercicios";
            this.listViewExercicios.Size = new System.Drawing.Size(451, 345);
            this.listViewExercicios.TabIndex = 2;
            this.listViewExercicios.UseCompatibleStateImageBehavior = false;
            this.listViewExercicios.View = System.Windows.Forms.View.Details;
            this.listViewExercicios.DoubleClick += new System.EventHandler(this.listViewExercicios_DoubleClick);
            // 
            // columnNome
            // 
            this.columnNome.Text = "Nome";
            this.columnNome.Width = 250;
            // 
            // columnKcal
            // 
            this.columnKcal.Text = "Kcal";
            this.columnKcal.Width = 74;
            // 
            // columnMet
            // 
            this.columnMet.Text = "Met";
            this.columnMet.Width = 121;
            // 
            // DeleteExercicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 397);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listViewExercicios);
            this.Name = "DeleteExercicioForm";
            this.Text = "DeleteExercicioForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ListView listViewExercicios;
        private System.Windows.Forms.ColumnHeader columnNome;
        private System.Windows.Forms.ColumnHeader columnKcal;
        private System.Windows.Forms.ColumnHeader columnMet;
    }
}