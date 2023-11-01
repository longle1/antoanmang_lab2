namespace Question_4
{
    partial class Dashboard
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
            this.btnClient = new System.Windows.Forms.Button();
            this.btnServer = new System.Windows.Forms.Button();
            this.btnServerLan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(49, 164);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(250, 55);
            this.btnClient.TabIndex = 9;
            this.btnClient.Text = "Create new TCP Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(458, 164);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(250, 55);
            this.btnServer.TabIndex = 8;
            this.btnServer.Text = "Open TCP Server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnServerLan
            // 
            this.btnServerLan.Location = new System.Drawing.Point(458, 225);
            this.btnServerLan.Name = "btnServerLan";
            this.btnServerLan.Size = new System.Drawing.Size(250, 55);
            this.btnServerLan.TabIndex = 10;
            this.btnServerLan.Text = "Open TCP Server LAN";
            this.btnServerLan.UseVisualStyleBackColor = true;
            this.btnServerLan.Click += new System.EventHandler(this.btnServerLan_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnServerLan);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnServer);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnServerLan;
    }
}