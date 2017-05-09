namespace Fahad
{
    partial class web
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(73, 59);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(698, 400);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(698, 400);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://github.com/fahad462/Tic_Tac_Toe-Minimax-", System.UriKind.Absolute);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "https://github.com/fahad462/Tic_Tac_Toe-Minimax-";
            // 
            // web
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(857, 471);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(873, 510);
            this.MinimumSize = new System.Drawing.Size(873, 510);
            this.Name = "web";
            this.Text = "Git Repository";
            this.Load += new System.EventHandler(this.web_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
    }
}