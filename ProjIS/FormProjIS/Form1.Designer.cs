namespace FormProjIS
{
    partial class Form1
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
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_carregarEXCEL);
            this.panel1.Controls.Add(this.bt_carregarJS);
            this.panel1.Controls.Add(this.bt_carregarTXT);
            this.panel1.Location = new System.Drawing.Point(835, 28);
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
            this.rtb_display.Location = new System.Drawing.Point(12, 28);
            this.rtb_display.Name = "rtb_display";
            this.rtb_display.Size = new System.Drawing.Size(817, 183);
            this.rtb_display.TabIndex = 4;
            this.rtb_display.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 576);
            this.Controls.Add(this.rtb_display);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_carregarJS;
        private System.Windows.Forms.Button bt_carregarTXT;
        private System.Windows.Forms.Button bt_carregarEXCEL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox rtb_display;
    }
}

