namespace FormProjIS
{
    partial class DeleteVegetalForm
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
            this.listViewVegetais = new System.Windows.Forms.ListView();
            this.columnNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnKcal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTipoDose = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDose = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewVegetais
            // 
            this.listViewVegetais.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNome,
            this.columnKcal,
            this.columnEstado,
            this.columnTipoDose,
            this.columnDose});
            this.listViewVegetais.FullRowSelect = true;
            this.listViewVegetais.GridLines = true;
            this.listViewVegetais.Location = new System.Drawing.Point(12, 12);
            this.listViewVegetais.Name = "listViewVegetais";
            this.listViewVegetais.Size = new System.Drawing.Size(654, 345);
            this.listViewVegetais.TabIndex = 0;
            this.listViewVegetais.UseCompatibleStateImageBehavior = false;
            this.listViewVegetais.View = System.Windows.Forms.View.Details;
            this.listViewVegetais.DoubleClick += new System.EventHandler(this.listViewVegetais_DoubleClick);
            // 
            // columnNome
            // 
            this.columnNome.Text = "Nome";
            this.columnNome.Width = 221;
            // 
            // columnKcal
            // 
            this.columnKcal.Text = "Kcal";
            this.columnKcal.Width = 74;
            // 
            // columnEstado
            // 
            this.columnEstado.DisplayIndex = 3;
            this.columnEstado.Text = "Estado";
            this.columnEstado.Width = 121;
            // 
            // columnTipoDose
            // 
            this.columnTipoDose.DisplayIndex = 2;
            this.columnTipoDose.Text = "Tipo Dose";
            this.columnTipoDose.Width = 137;
            // 
            // columnDose
            // 
            this.columnDose.Text = "Dose";
            this.columnDose.Width = 95;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(591, 363);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // DeleteVegetalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 398);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listViewVegetais);
            this.Name = "DeleteVegetalForm";
            this.Text = "DeleteVegetalForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewVegetais;
        private System.Windows.Forms.ColumnHeader columnNome;
        private System.Windows.Forms.ColumnHeader columnKcal;
        private System.Windows.Forms.ColumnHeader columnEstado;
        private System.Windows.Forms.ColumnHeader columnTipoDose;
        private System.Windows.Forms.ColumnHeader columnDose;
        private System.Windows.Forms.Button buttonOK;
    }
}