namespace FormProjIS
{
    partial class DeletePratoForm
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
            this.listViewPratos = new System.Windows.Forms.ListView();
            this.columnNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnKcal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRestaurante = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(591, 363);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // listViewPratos
            // 
            this.listViewPratos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRestaurante,
            this.columnNome,
            this.columnKcal,
            this.columnQuantidade});
            this.listViewPratos.FullRowSelect = true;
            this.listViewPratos.GridLines = true;
            this.listViewPratos.Location = new System.Drawing.Point(12, 12);
            this.listViewPratos.Name = "listViewPratos";
            this.listViewPratos.Size = new System.Drawing.Size(654, 345);
            this.listViewPratos.TabIndex = 2;
            this.listViewPratos.UseCompatibleStateImageBehavior = false;
            this.listViewPratos.View = System.Windows.Forms.View.Details;
            this.listViewPratos.DoubleClick += new System.EventHandler(this.listViewPratos_DoubleClick);
            // 
            // columnNome
            // 
            this.columnNome.DisplayIndex = 0;
            this.columnNome.Text = "Nome";
            this.columnNome.Width = 221;
            // 
            // columnKcal
            // 
            this.columnKcal.DisplayIndex = 1;
            this.columnKcal.Text = "Kcal";
            this.columnKcal.Width = 74;
            // 
            // columnRestaurante
            // 
            this.columnRestaurante.Text = "Restaurante";
            this.columnRestaurante.Width = 206;
            // 
            // columnQuantidade
            // 
            this.columnQuantidade.DisplayIndex = 2;
            this.columnQuantidade.Text = "Quantidade";
            this.columnQuantidade.Width = 137;
            // 
            // DeletePratoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 396);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.listViewPratos);
            this.Name = "DeletePratoForm";
            this.Text = "DeletePratoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ListView listViewPratos;
        private System.Windows.Forms.ColumnHeader columnNome;
        private System.Windows.Forms.ColumnHeader columnKcal;
        private System.Windows.Forms.ColumnHeader columnRestaurante;
        private System.Windows.Forms.ColumnHeader columnQuantidade;
    }
}