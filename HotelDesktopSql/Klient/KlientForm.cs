using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelDesktopSql.Klient
{
    public partial class KlientForm : Form
    {
        Osoba AktualnyKlient;

        public KlientForm(Osoba _AktualnyKlient)
        {
            InitializeComponent();

            this.FormBorderStyle = Dictionary.Dc_borderStyle;
            MinimumSize = new Size(600, 0);
            AktualnyKlient = _AktualnyKlient;
            this.BackColor = Dictionary.BackColor;
            Dictionary.DesignButton(PrzegladajTowary);
            Dictionary.DesignButton(DodajZamowieni);
            Dictionary.DesignButton(LogOut);
            Dictionary.DesignButton(Exit);
        }
        //SklepMuzycznyV2Entities db = new SklepMuzycznyV2Entities();

        bool resizedByuser = false;

        

        private void BaseOperation(DataGridView Grid, string query)
        {
            TowarGV.Visible = true;
            using (SqlConnection sqlConn = new SqlConnection(Dictionary.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, sqlConn))
            {
                sqlConn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                Grid.DataSource = dt;
            }
            if (WindowState != FormWindowState.Maximized && !resizedByuser)
            {

                TowarGV.Width = (TowarGV.PreferredSize.Width < Screen.FromControl(this).Bounds.Width - 50) ? TowarGV.PreferredSize.Width : Screen.FromControl(this).Bounds.Width - 50;
                TowarGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (TowarGV.Rows.Count > 0)
                    TowarGV.Height = TowarGV.Rows[0].Height * 10;
                this.Width = TowarGV.Width * 105 / 100;
                this.Height = TowarGV.Height + 100;
            }
        }

        private void TwojeRezerwacje_Click(object sender, EventArgs e)
        {
            string przeglądanieRezerwacji =
                "select Rezerwacja.R_NaKiedy as Od, Rezerwacja.R_DoKiedy as Do, Pokoj.P_Nr as NrPokoju, Pokoj.P_KosztDzienny as KoszDzienny, Pokoj.P_IluOsobowy as IluOsobowy" +
                " from Rezerwacja" +
                " inner join Osoba on Rezerwacja.O_ID = Osoba.O_ID" +
                " inner join Relationship_2 on Rezerwacja.R_ID = Relationship_2.R_ID" +
                " inner join Pokoj on Relationship_2.P_ID = Pokoj.P_ID"+
                " where Osoba.O_ID = " + AktualnyKlient.O_ID;
            BaseOperation(TowarGV, przeglądanieRezerwacji);
        }


        private void DodajZamowieni_Click(object sender, EventArgs e)
        {
            KlientRezerwuj Rezerwacja = new KlientRezerwuj(AktualnyKlient);
            Rezerwacja.Show();
        }
        protected void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}