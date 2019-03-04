namespace STAR_TEAM.PL
{
    partial class Loading
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
            this.Loading_Time = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Titel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.Load_Tx = new System.Windows.Forms.Label();
            this.Tx = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Loading_Time
            // 
            this.Loading_Time.Enabled = true;
            this.Loading_Time.Interval = 5000;
            this.Loading_Time.Tick += new System.EventHandler(this.Loading_Time_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.panel1.Location = new System.Drawing.Point(-3, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 26);
            this.panel1.TabIndex = 0;
            // 
            // Titel
            // 
            this.Titel.AutoSize = true;
            this.Titel.Font = new System.Drawing.Font("Tempus Sans ITC", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titel.ForeColor = System.Drawing.Color.OrangeRed;
            this.Titel.Location = new System.Drawing.Point(34, 76);
            this.Titel.Name = "Titel";
            this.Titel.Size = new System.Drawing.Size(396, 84);
            this.Titel.TabIndex = 2;
            this.Titel.Text = "STAR-TEAM";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(418, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 17);
            this.label19.TabIndex = 3;
            this.label19.Text = "V 1.0";
            // 
            // Load_Tx
            // 
            this.Load_Tx.AutoSize = true;
            this.Load_Tx.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_Tx.ForeColor = System.Drawing.Color.White;
            this.Load_Tx.Location = new System.Drawing.Point(4, 209);
            this.Load_Tx.Name = "Load_Tx";
            this.Load_Tx.Size = new System.Drawing.Size(84, 21);
            this.Load_Tx.TabIndex = 4;
            this.Load_Tx.Text = "Loading...";
            // 
            // Tx
            // 
            this.Tx.Enabled = true;
            this.Tx.Interval = 600;
            this.Tx.Tick += new System.EventHandler(this.Tx_Tick);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(462, 258);
            this.Controls.Add(this.Load_Tx);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.Titel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Loading_Time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Titel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label Load_Tx;
        private System.Windows.Forms.Timer Tx;
    }
}