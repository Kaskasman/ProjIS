namespace FormProjIS
{
    partial class XmlForm
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
            this.bt_carregarJS = new System.Windows.Forms.Button();
            this.bt_carregarTXT = new System.Windows.Forms.Button();
            this.bt_carregarEXCEL = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rtb_display = new System.Windows.Forms.RichTextBox();
            this.bt_validar = new System.Windows.Forms.Button();
            this.tb_xsd = new System.Windows.Forms.TextBox();
            this.tb_filePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_carregarJS
            // 
            this.bt_carregarJS.Location = new System.Drawing.Point(3, 3);
            this.bt_carregarJS.Name = "bt_carregarJS";
            this.bt_carregarJS.Size = new System.Drawing.Size(103, 54);
            this.bt_carregarJS.TabIndex = 0;
            this.bt_carregarJS.Text = "JS";
            this.bt_carregarJS.UseVisualStyleBackColor = true;
            this.bt_carregarJS.Click += new System.EventHandler(this.bt_carregarJS_Click);
            // 
            // bt_carregarTXT
            // 
            this.bt_carregarTXT.Location = new System.Drawing.Point(3, 63);
            this.bt_carregarTXT.Name = "bt_carregarTXT";
            this.bt_carregarTXT.Size = new System.Drawing.Size(103, 54);
            this.bt_carregarTXT.TabIndex = 1;
            this.bt_carregarTXT.Text = "TXT";
            this.bt_carregarTXT.UseVisualStyleBackColor = true;
            this.bt_carregarTXT.Click += new System.EventHandler(this.bt_carregarTXT_Click);
            // 
            // bt_carregarEXCEL
            // 
            this.bt_carregarEXCEL.Location = new System.Drawing.Point(3, 123);
            this.bt_carregarEXCEL.Name = "bt_carregarEXCEL";
            this.bt_carregarEXCEL.Size = new System.Drawing.Size(103, 54);
            this.bt_carregarEXCEL.TabIndex = 2;
            this.bt_carregarEXCEL.Text = "EXCEL";
            this.bt_carregarEXCEL.UseVisualStyleBackColor = true;
            this.bt_carregarEXCEL.Click += new System.EventHandler(this.bt_carregarEXCEL_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_carregarEXCEL);
            this.panel1.Controls.Add(this.bt_carregarJS);
            this.panel1.Controls.Add(this.bt_carregarTXT);
            this.panel1.Location = new System.Drawing.Point(724, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 183);
            this.panel1.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rtb_display
            // 
            this.rtb_display.Location = new System.Drawing.Point(12, 217);
            this.rtb_display.Name = "rtb_display";
            this.rtb_display.Size = new System.Drawing.Size(820, 347);
            this.rtb_display.TabIndex = 4;
            this.rtb_display.Text = "";
            // 
            // bt_validar
            // 
            this.bt_validar.Location = new System.Drawing.Point(100, 91);
            this.bt_validar.Name = "bt_validar";
            this.bt_validar.Size = new System.Drawing.Size(103, 54);
            this.bt_validar.TabIndex = 0;
            this.bt_validar.Text = "Validar";
            this.bt_validar.UseVisualStyleBackColor = true;
            this.bt_validar.Click += new System.EventHandler(this.bt_validar_Click);
            // 
            // tb_xsd
            // 
            this.tb_xsd.Location = new System.Drawing.Point(100, 63);
            this.tb_xsd.Name = "tb_xsd";
            this.tb_xsd.ReadOnly = true;
            this.tb_xsd.Size = new System.Drawing.Size(585, 20);
            this.tb_xsd.TabIndex = 8;
            // 
            // tb_filePath
            // 
            this.tb_filePath.Location = new System.Drawing.Point(100, 31);
            this.tb_filePath.Name = "tb_filePath";
            this.tb_filePath.ReadOnly = true;
            this.tb_filePath.Size = new System.Drawing.Size(585, 20);
            this.tb_filePath.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "XSD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "XML File Path";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(691, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "..";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(691, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "..";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 576);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tb_xsd);
            this.Controls.Add(this.bt_validar);
            this.Controls.Add(this.tb_filePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtb_display);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_carregarJS;
        private System.Windows.Forms.Button bt_carregarTXT;
        private System.Windows.Forms.Button bt_carregarEXCEL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox rtb_display;
        private System.Windows.Forms.Button bt_validar;
        private System.Windows.Forms.TextBox tb_xsd;
        private System.Windows.Forms.TextBox tb_filePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}

