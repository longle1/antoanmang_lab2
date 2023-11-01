namespace Question_3
{
    partial class Server
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
            this.Server_contents = new System.Windows.Forms.RichTextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Server_contents
            // 
            this.Server_contents.Location = new System.Drawing.Point(41, 84);
            this.Server_contents.Name = "Server_contents";
            this.Server_contents.Size = new System.Drawing.Size(545, 224);
            this.Server_contents.TabIndex = 3;
            this.Server_contents.Text = "";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(415, 34);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(171, 44);
            this.btnListen.TabIndex = 2;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleVioletRed;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.Server_contents);
            this.Controls.Add(this.btnListen);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Server";
            this.Text = "Q3 - Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Server_contents;
        private System.Windows.Forms.Button btnListen;
    }
}