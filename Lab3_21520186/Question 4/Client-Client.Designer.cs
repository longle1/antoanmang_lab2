namespace Question_4
{
    partial class Client_Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendDif = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.Client_contents = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Message";
            // 
            // btnSendDif
            // 
            this.btnSendDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendDif.Location = new System.Drawing.Point(522, 362);
            this.btnSendDif.Name = "btnSendDif";
            this.btnSendDif.Size = new System.Drawing.Size(124, 47);
            this.btnSendDif.TabIndex = 8;
            this.btnSendDif.Text = "Send Public Key";
            this.btnSendDif.UseVisualStyleBackColor = true;
            this.btnSendDif.Click += new System.EventHandler(this.btnSendDif_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(652, 362);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(136, 47);
            this.btnSendMessage.TabIndex = 7;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(55, 362);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(461, 47);
            this.txtSendMessage.TabIndex = 6;
            // 
            // Client_contents
            // 
            this.Client_contents.Location = new System.Drawing.Point(55, 37);
            this.Client_contents.Name = "Client_contents";
            this.Client_contents.Size = new System.Drawing.Size(684, 289);
            this.Client_contents.TabIndex = 5;
            this.Client_contents.Text = "";
            // 
            // Client_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendDif);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.Client_contents);
            this.Name = "Client_Client";
            this.Text = "Client_Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_Client_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendDif;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.RichTextBox Client_contents;
    }
}