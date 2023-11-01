namespace Question_3
{
    partial class Q3___Dashboardcs
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
            this.btnTCPServer = new System.Windows.Forms.Button();
            this.btnTCPClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTCPServer
            // 
            this.btnTCPServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCPServer.ForeColor = System.Drawing.Color.Crimson;
            this.btnTCPServer.Location = new System.Drawing.Point(100, 50);
            this.btnTCPServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTCPServer.Name = "btnTCPServer";
            this.btnTCPServer.Size = new System.Drawing.Size(171, 30);
            this.btnTCPServer.TabIndex = 7;
            this.btnTCPServer.Text = "TCP Server";
            this.btnTCPServer.UseVisualStyleBackColor = true;
            this.btnTCPServer.Click += new System.EventHandler(this.btnTCPServer_Click);
            // 
            // btnTCPClient
            // 
            this.btnTCPClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCPClient.ForeColor = System.Drawing.Color.Crimson;
            this.btnTCPClient.Location = new System.Drawing.Point(380, 50);
            this.btnTCPClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTCPClient.Name = "btnTCPClient";
            this.btnTCPClient.Size = new System.Drawing.Size(171, 30);
            this.btnTCPClient.TabIndex = 8;
            this.btnTCPClient.Text = "TCP Client";
            this.btnTCPClient.UseVisualStyleBackColor = true;
            this.btnTCPClient.Click += new System.EventHandler(this.btnTCPClient_Click);
            // 
            // Q3___Dashboardcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleVioletRed;
            this.ClientSize = new System.Drawing.Size(711, 129);
            this.Controls.Add(this.btnTCPClient);
            this.Controls.Add(this.btnTCPServer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Q3___Dashboardcs";
            this.Text = "Q3___Dashboardcs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTCPServer;
        private System.Windows.Forms.Button btnTCPClient;
    }
}