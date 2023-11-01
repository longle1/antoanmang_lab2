namespace Question_2
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
            this.btnListen = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.Server_contents = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnListen
            // 
            this.btnListen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListen.ForeColor = System.Drawing.Color.Crimson;
            this.btnListen.Location = new System.Drawing.Point(98, 64);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(147, 37);
            this.btnListen.TabIndex = 7;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Crimson;
            this.btnStop.Location = new System.Drawing.Point(544, 64);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(158, 37);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Server_contents
            // 
            this.Server_contents.HideSelection = false;
            this.Server_contents.Location = new System.Drawing.Point(98, 135);
            this.Server_contents.Name = "Server_contents";
            this.Server_contents.Size = new System.Drawing.Size(604, 277);
            this.Server_contents.TabIndex = 9;
            this.Server_contents.UseCompatibleStateImageBehavior = false;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleVioletRed;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Server_contents);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnListen);
            this.Name = "Server";
            this.Text = "Q2 - Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListView Server_contents;
    }
}