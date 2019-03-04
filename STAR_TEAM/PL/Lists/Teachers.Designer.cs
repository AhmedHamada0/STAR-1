namespace STAR_TEAM.PL.Lists
{
    partial class Teachers
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
            this.TxSearch_Teach = new iTalk.iTalk_TextBox_Small();
            this.Del_btn = new iTalk.iTalk_Button_1();
            this.Add_btn = new iTalk.iTalk_Button_1();
            this.TxID = new iTalk.iTalk_TextBox_Small();
            this.Refresh_btn = new iTalk.iTalk_Button_1();
            this.Teach_List = new System.Windows.Forms.ListView();
            this.Tech_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tech_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchTx = new System.Windows.Forms.Timer(this.components);
            this.Exit = new iTalk.iTalk_Button_1();
            this.SuspendLayout();
            // 
            // TxSearch_Teach
            // 
            this.TxSearch_Teach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxSearch_Teach.BackColor = System.Drawing.Color.Transparent;
            this.TxSearch_Teach.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxSearch_Teach.ForeColor = System.Drawing.Color.DimGray;
            this.TxSearch_Teach.Location = new System.Drawing.Point(12, 5);
            this.TxSearch_Teach.MaxLength = 32767;
            this.TxSearch_Teach.Multiline = false;
            this.TxSearch_Teach.Name = "TxSearch_Teach";
            this.TxSearch_Teach.ReadOnly = false;
            this.TxSearch_Teach.Size = new System.Drawing.Size(213, 28);
            this.TxSearch_Teach.TabIndex = 28;
            this.TxSearch_Teach.Text = "Search";
            this.TxSearch_Teach.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxSearch_Teach.UseSystemPasswordChar = false;
            this.TxSearch_Teach.TextChanged += new System.EventHandler(this.TxSearch_Teach_TextChanged);
            this.TxSearch_Teach.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TxSearch_Teach_MouseMove);
            // 
            // Del_btn
            // 
            this.Del_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Del_btn.BackColor = System.Drawing.Color.Transparent;
            this.Del_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Del_btn.Image = null;
            this.Del_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Del_btn.Location = new System.Drawing.Point(191, 313);
            this.Del_btn.Name = "Del_btn";
            this.Del_btn.Size = new System.Drawing.Size(38, 28);
            this.Del_btn.TabIndex = 27;
            this.Del_btn.Text = "Del";
            this.Del_btn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Del_btn.Visible = false;
            this.Del_btn.Click += new System.EventHandler(this.Del_btn_Click);
            // 
            // Add_btn
            // 
            this.Add_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_btn.BackColor = System.Drawing.Color.Transparent;
            this.Add_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_btn.Image = null;
            this.Add_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add_btn.Location = new System.Drawing.Point(191, 313);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(38, 28);
            this.Add_btn.TabIndex = 26;
            this.Add_btn.Text = "Add";
            this.Add_btn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // TxID
            // 
            this.TxID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxID.BackColor = System.Drawing.Color.Transparent;
            this.TxID.Font = new System.Drawing.Font("Tahoma", 11F);
            this.TxID.ForeColor = System.Drawing.Color.DimGray;
            this.TxID.Location = new System.Drawing.Point(12, 313);
            this.TxID.MaxLength = 32767;
            this.TxID.Multiline = false;
            this.TxID.Name = "TxID";
            this.TxID.ReadOnly = true;
            this.TxID.Size = new System.Drawing.Size(173, 28);
            this.TxID.TabIndex = 25;
            this.TxID.Text = "ID";
            this.TxID.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxID.UseSystemPasswordChar = false;
            // 
            // Refresh_btn
            // 
            this.Refresh_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Refresh_btn.BackColor = System.Drawing.Color.Transparent;
            this.Refresh_btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh_btn.Image = null;
            this.Refresh_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Refresh_btn.Location = new System.Drawing.Point(510, 313);
            this.Refresh_btn.Name = "Refresh_btn";
            this.Refresh_btn.Size = new System.Drawing.Size(136, 28);
            this.Refresh_btn.TabIndex = 24;
            this.Refresh_btn.Text = "Refresh";
            this.Refresh_btn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Refresh_btn.Click += new System.EventHandler(this.Refresh_btn_Click);
            // 
            // Teach_List
            // 
            this.Teach_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Teach_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(47)))), ((int)(((byte)(65)))));
            this.Teach_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tech_ID,
            this.Tech_Name,
            this.Email,
            this.Type});
            this.Teach_List.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Teach_List.ForeColor = System.Drawing.Color.White;
            this.Teach_List.FullRowSelect = true;
            this.Teach_List.Location = new System.Drawing.Point(12, 36);
            this.Teach_List.Name = "Teach_List";
            this.Teach_List.Size = new System.Drawing.Size(776, 273);
            this.Teach_List.TabIndex = 23;
            this.Teach_List.UseCompatibleStateImageBehavior = false;
            this.Teach_List.View = System.Windows.Forms.View.Details;
            this.Teach_List.SelectedIndexChanged += new System.EventHandler(this.Teach_List_SelectedIndexChanged);
            // 
            // Tech_ID
            // 
            this.Tech_ID.Text = "ID";
            this.Tech_ID.Width = 73;
            // 
            // Tech_Name
            // 
            this.Tech_Name.Text = "Name";
            this.Tech_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Tech_Name.Width = 236;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Email.Width = 331;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 129;
            // 
            // SearchTx
            // 
            this.SearchTx.Enabled = true;
            this.SearchTx.Interval = 3000;
            this.SearchTx.Tick += new System.EventHandler(this.SearchTx_Tick);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Image = null;
            this.Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit.Location = new System.Drawing.Point(652, 313);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(136, 28);
            this.Exit.TabIndex = 29;
            this.Exit.Text = "Done";
            this.Exit.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Teachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(800, 347);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.TxSearch_Teach);
            this.Controls.Add(this.Del_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.TxID);
            this.Controls.Add(this.Refresh_btn);
            this.Controls.Add(this.Teach_List);
            this.Name = "Teachers";
            this.Text = "Teachers";
            this.Load += new System.EventHandler(this.Teachers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_TextBox_Small TxSearch_Teach;
        private iTalk.iTalk_Button_1 Del_btn;
        private iTalk.iTalk_Button_1 Add_btn;
        private iTalk.iTalk_TextBox_Small TxID;
        private iTalk.iTalk_Button_1 Refresh_btn;
        private System.Windows.Forms.ListView Teach_List;
        private System.Windows.Forms.ColumnHeader Tech_ID;
        private System.Windows.Forms.ColumnHeader Tech_Name;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.Timer SearchTx;
        private iTalk.iTalk_Button_1 Exit;
    }
}