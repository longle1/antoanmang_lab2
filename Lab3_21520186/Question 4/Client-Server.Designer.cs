namespace Question_4
{
    partial class Client_Server
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
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.Client_contents = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listUserActive = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtIpAdress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(174, 317);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(156, 45);
            this.btnLogOut.TabIndex = 15;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Message";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(448, 394);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(156, 39);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(12, 394);
            this.txtSendData.Multiline = true;
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(430, 39);
            this.txtSendData.TabIndex = 12;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 317);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(156, 45);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // Client_contents
            // 
            this.Client_contents.Location = new System.Drawing.Point(12, 34);
            this.Client_contents.Name = "Client_contents";
            this.Client_contents.Size = new System.Drawing.Size(589, 266);
            this.Client_contents.TabIndex = 10;
            this.Client_contents.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Participants";
            // 
            // listUserActive
            // 
            this.listUserActive.HideSelection = false;
            this.listUserActive.Location = new System.Drawing.Point(626, 34);
            this.listUserActive.Name = "listUserActive";
            this.listUserActive.Size = new System.Drawing.Size(162, 399);
            this.listUserActive.TabIndex = 8;
            this.listUserActive.UseCompatibleStateImageBehavior = false;
            this.listUserActive.View = System.Windows.Forms.View.List;
            this.listUserActive.DoubleClick += new System.EventHandler(this.listUserActive_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtIpAdress
            // 
            this.txtIpAdress.Location = new System.Drawing.Point(336, 339);
            this.txtIpAdress.Multiline = true;
            this.txtIpAdress.Name = "txtIpAdress";
            this.txtIpAdress.Size = new System.Drawing.Size(249, 23);
            this.txtIpAdress.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "IP Adress dành cho chat qua LAN";
            // 
            // Client_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIpAdress);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.Client_contents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listUserActive);
            this.Name = "Client_Server";
            this.Text = "Client_Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_Server_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox Client_contents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listUserActive;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtIpAdress;
        private System.Windows.Forms.Label label3;
    }
}