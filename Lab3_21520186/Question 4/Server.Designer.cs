namespace Question_4
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.listUserActive = new System.Windows.Forms.ListView();
            this.btnListen = new System.Windows.Forms.Button();
            this.Server_contents = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Participants";
            // 
            // listUserActive
            // 
            this.listUserActive.HideSelection = false;
            this.listUserActive.Location = new System.Drawing.Point(585, 106);
            this.listUserActive.Name = "listUserActive";
            this.listUserActive.Size = new System.Drawing.Size(149, 287);
            this.listUserActive.TabIndex = 7;
            this.listUserActive.UseCompatibleStateImageBehavior = false;
            this.listUserActive.View = System.Windows.Forms.View.List;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(449, 57);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(121, 42);
            this.btnListen.TabIndex = 6;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // Server_contents
            // 
            this.Server_contents.Location = new System.Drawing.Point(67, 106);
            this.Server_contents.Name = "Server_contents";
            this.Server_contents.Size = new System.Drawing.Size(503, 287);
            this.Server_contents.TabIndex = 5;
            this.Server_contents.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listUserActive);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.Server_contents);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listUserActive;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.RichTextBox Server_contents;
        private System.Windows.Forms.Timer timer1;
    }
}