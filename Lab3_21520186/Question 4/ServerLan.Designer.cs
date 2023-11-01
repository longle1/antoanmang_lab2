namespace Question_4
{
    partial class ServerLan
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
            this.btnListen = new System.Windows.Forms.Button();
            this.Server_contents = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listUserActive = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(402, 45);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(121, 42);
            this.btnListen.TabIndex = 8;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Server_contents
            // 
            this.Server_contents.Location = new System.Drawing.Point(20, 94);
            this.Server_contents.Name = "Server_contents";
            this.Server_contents.Size = new System.Drawing.Size(503, 287);
            this.Server_contents.TabIndex = 7;
            this.Server_contents.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(593, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Participants";
            // 
            // listUserActive
            // 
            this.listUserActive.HideSelection = false;
            this.listUserActive.Location = new System.Drawing.Point(596, 94);
            this.listUserActive.Name = "listUserActive";
            this.listUserActive.Size = new System.Drawing.Size(149, 287);
            this.listUserActive.TabIndex = 9;
            this.listUserActive.UseCompatibleStateImageBehavior = false;
            this.listUserActive.View = System.Windows.Forms.View.List;
            // 
            // ServerLan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listUserActive);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.Server_contents);
            this.Name = "ServerLan";
            this.Text = "ServerLan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerLan_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.RichTextBox Server_contents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listUserActive;
    }
}