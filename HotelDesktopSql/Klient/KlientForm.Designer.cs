namespace HotelDesktopSql.Klient
{
    partial class KlientForm
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
            this.Exit = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            this.TowarGV = new System.Windows.Forms.DataGridView();
            this.DodajZamowieni = new System.Windows.Forms.Button();
            this.PrzegladajTowary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TowarGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.Location = new System.Drawing.Point(797, 12);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Wyjdz";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Close_Click);
            // 
            // LogOut
            // 
            this.LogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOut.Location = new System.Drawing.Point(716, 12);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(75, 23);
            this.LogOut.TabIndex = 1;
            this.LogOut.Text = "Wyloguj";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.Logout_Click);
            // 
            // TowarGV
            // 
            this.TowarGV.AllowUserToAddRows = false;
            this.TowarGV.AllowUserToDeleteRows = false;
            this.TowarGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TowarGV.Location = new System.Drawing.Point(12, 41);
            this.TowarGV.MaximumSize = new System.Drawing.Size(850, 528);
            this.TowarGV.MinimumSize = new System.Drawing.Size(850, 300);
            this.TowarGV.Name = "TowarGV";
            this.TowarGV.ReadOnly = true;
            this.TowarGV.Size = new System.Drawing.Size(850, 300);
            this.TowarGV.TabIndex = 2;
            this.TowarGV.Visible = false;
            // 
            // DodajZamowieni
            // 
            this.DodajZamowieni.Location = new System.Drawing.Point(136, 12);
            this.DodajZamowieni.Name = "DodajZamowieni";
            this.DodajZamowieni.Size = new System.Drawing.Size(118, 23);
            this.DodajZamowieni.TabIndex = 3;
            this.DodajZamowieni.Text = "Rezerwuj";
            this.DodajZamowieni.UseVisualStyleBackColor = true;
            this.DodajZamowieni.Click += new System.EventHandler(this.DodajZamowieni_Click);
            // 
            // PrzegladajTowary
            // 
            this.PrzegladajTowary.Location = new System.Drawing.Point(12, 12);
            this.PrzegladajTowary.Name = "PrzegladajTowary";
            this.PrzegladajTowary.Size = new System.Drawing.Size(118, 23);
            this.PrzegladajTowary.TabIndex = 4;
            this.PrzegladajTowary.Text = "Twoje Rezerwacje";
            this.PrzegladajTowary.UseVisualStyleBackColor = true;
            this.PrzegladajTowary.Click += new System.EventHandler(this.TwojeRezerwacje_Click);
            // 
            // KlientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.PrzegladajTowary);
            this.Controls.Add(this.DodajZamowieni);
            this.Controls.Add(this.TowarGV);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.Exit);
            this.MaximumSize = new System.Drawing.Size(900, 620);
            this.MinimumSize = new System.Drawing.Size(900, 400);
            this.Name = "KlientForm";
            this.Text = "Okno Klienta";
            ((System.ComponentModel.ISupportInitialize)(this.TowarGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.DataGridView TowarGV;
        private System.Windows.Forms.Button DodajZamowieni;
        private System.Windows.Forms.Button PrzegladajTowary;
    }
}