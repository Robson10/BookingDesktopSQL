namespace HotelDesktopSql.PracownikF
{
    partial class PracownikForm
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
            this.SelectClients = new System.Windows.Forms.Button();
            this.EditTowary = new System.Windows.Forms.Button();
            this.SelectZamowienia = new System.Windows.Forms.Button();
            this.LogoutBT = new System.Windows.Forms.Button();
            this.CloseBT = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.UpdateBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectClients
            // 
            this.SelectClients.Location = new System.Drawing.Point(12, 12);
            this.SelectClients.Name = "SelectClients";
            this.SelectClients.Size = new System.Drawing.Size(133, 23);
            this.SelectClients.TabIndex = 0;
            this.SelectClients.Text = "Przeglądaj dane klientów";
            this.SelectClients.UseVisualStyleBackColor = true;
            this.SelectClients.Click += new System.EventHandler(this.SelectClients_Click);
            // 
            // EditTowary
            // 
            this.EditTowary.Location = new System.Drawing.Point(292, 12);
            this.EditTowary.Name = "EditTowary";
            this.EditTowary.Size = new System.Drawing.Size(133, 23);
            this.EditTowary.TabIndex = 1;
            this.EditTowary.Text = "Przeglądaj Pokoje";
            this.EditTowary.UseVisualStyleBackColor = true;
            this.EditTowary.Click += new System.EventHandler(this.EditTowary_Click);
            // 
            // SelectZamowienia
            // 
            this.SelectZamowienia.Location = new System.Drawing.Point(151, 12);
            this.SelectZamowienia.Name = "SelectZamowienia";
            this.SelectZamowienia.Size = new System.Drawing.Size(135, 23);
            this.SelectZamowienia.TabIndex = 2;
            this.SelectZamowienia.Text = "Przeglądaj Rezerwacje";
            this.SelectZamowienia.UseVisualStyleBackColor = true;
            this.SelectZamowienia.Click += new System.EventHandler(this.SelectRezerwacje_Click);
            // 
            // LogoutBT
            // 
            this.LogoutBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoutBT.Location = new System.Drawing.Point(880, 11);
            this.LogoutBT.Name = "LogoutBT";
            this.LogoutBT.Size = new System.Drawing.Size(75, 23);
            this.LogoutBT.TabIndex = 12;
            this.LogoutBT.Text = "Wyloguj";
            this.LogoutBT.UseVisualStyleBackColor = true;
            this.LogoutBT.Click += new System.EventHandler(this.Logout_Click);
            // 
            // CloseBT
            // 
            this.CloseBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBT.Location = new System.Drawing.Point(962, 12);
            this.CloseBT.Name = "CloseBT";
            this.CloseBT.Size = new System.Drawing.Size(75, 23);
            this.CloseBT.TabIndex = 13;
            this.CloseBT.Text = "Zamknij";
            this.CloseBT.UseVisualStyleBackColor = true;
            this.CloseBT.Click += new System.EventHandler(this.Close_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 100);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(1024, 448);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1024, 448);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // UpdateBT
            // 
            this.UpdateBT.Location = new System.Drawing.Point(12, 71);
            this.UpdateBT.Name = "UpdateBT";
            this.UpdateBT.Size = new System.Drawing.Size(133, 23);
            this.UpdateBT.TabIndex = 16;
            this.UpdateBT.Text = "AktualizujBaze";
            this.UpdateBT.UseVisualStyleBackColor = true;
            this.UpdateBT.Visible = false;
            this.UpdateBT.Click += new System.EventHandler(this.UpdateBT_Click);
            // 
            // PracownikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 560);
            this.Controls.Add(this.UpdateBT);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.CloseBT);
            this.Controls.Add(this.LogoutBT);
            this.Controls.Add(this.SelectZamowienia);
            this.Controls.Add(this.EditTowary);
            this.Controls.Add(this.SelectClients);
            this.MaximumSize = new System.Drawing.Size(1065, 599);
            this.MinimumSize = new System.Drawing.Size(1065, 599);
            this.Name = "PracownikForm";
            this.Text = "Okno Pracownika";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectClients;
        private System.Windows.Forms.Button EditTowary;
        private System.Windows.Forms.Button SelectZamowienia;
        private System.Windows.Forms.Button LogoutBT;
        private System.Windows.Forms.Button CloseBT;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button UpdateBT;
    }
}