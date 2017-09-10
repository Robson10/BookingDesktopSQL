using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelDesktopSql.PracownikF
{
    public partial class PracownikForm : Form
    {
        Pracownik Aktualnypracownik;
        public PracownikForm(Pracownik _Aktualnypracownik)
        {
            InitializeComponent();

            this.FormBorderStyle = Dictionary.Dc_borderStyle;
            Aktualnypracownik = _Aktualnypracownik;
            Dictionary.DesignButton(CloseBT);
            Dictionary.DesignButton(CloseBT);
            Dictionary.DesignButton(SelectClients);
            Dictionary.DesignButton(SelectZamowienia);
            Dictionary.DesignButton(EditTowary);
            Dictionary.DesignButton(UpdateBT);
            Dictionary.DesignButton(LogoutBT);
            this.BackColor = Dictionary.BackColor;
        }
        SqlDataAdapter KlienciAdapter, RezerwacjaAdapter, PokojAdapter, UtworAdapter;
        DataSet KlienciDataSet, RezerwacjaDataSet, PokojDataSet, UtworDataSet;
        DataGridView KlienciGrid, RezerwacjaGrid, PokojeGrid, UtworGrid;

        
        int lastUtworIndex = 0;
        private void UpdateBT_Click(object sender, EventArgs e)
        {
            if (KlienciGrid!=null&& KlienciGrid.Visible)
            {
                Dictionary.UpdateData(ref KlienciDataSet, ref KlienciAdapter, "Osoba", ref KlienciGrid, klienciQuerry, this,
                    new Panel());
            }
            if (PokojeGrid != null && PokojeGrid.Visible)
            {
                Dictionary.UpdateData(ref PokojDataSet, ref PokojAdapter, "Pokoj", ref PokojeGrid, PokojeQuerry, this,
                    new Panel());
            }
        }

        string PokojeQuerry = "select Pokoj.P_ID, Pokoj.P_Nr as NrPokoju,Pokoj.P_IluOsobowy as IluOsobowy, Pokoj.P_KosztDzienny as KosztDzienny, Pokoj.P_CzyGotowy as CzyGotowy from Pokoj order by Pokoj.P_CzyGotowy, Pokoj.P_Nr asc";
        private void EditTowary_Click(object sender, EventArgs e)
        {

            Dictionary.SelectData(PokojeQuerry, true, ref PokojeGrid, flowLayoutPanel1, ref PokojAdapter, ref PokojDataSet, "Pokoj", this);
            PokojeGrid.AllowUserToDeleteRows = false;
            UpdateBT.Visible = true;
            PokojeGrid.AllowUserToAddRows = false;
            PokojeGrid.Columns[0].Visible = false;
            PokojeGrid.Visible = true;
            PokojeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (RezerwacjaGrid != null) RezerwacjaGrid.Visible = false;
            if (KlienciGrid != null) KlienciGrid.Visible = false;
        }


        #region done
        private string daneRezerwacji =
            "select Osoba.O_Imie,Osoba.O_Nazwisko,Rezerwacja.R_NaKiedy,Rezerwacja.R_DoKiedy,Pokoj.P_Nr,Pokoj.P_KosztDzienny,Pokoj.P_CzyGotowy from Rezerwacja" +
            " inner join Osoba on Rezerwacja.O_ID=Osoba.O_ID" +
            " inner join Relationship_2 on Relationship_2.R_ID=Rezerwacja.R_ID" +
            " inner join Pokoj on Pokoj.P_ID = Relationship_2.P_ID" +
            " order by Osoba.O_Imie, Osoba.O_Nazwisko, Rezerwacja.R_NaKiedy, Rezerwacja.R_DoKiedy asc";
        private void SelectRezerwacje_Click(object sender, EventArgs e)
        {
            Dictionary.SelectData(daneRezerwacji, false, ref RezerwacjaGrid, flowLayoutPanel1, ref RezerwacjaAdapter, ref RezerwacjaDataSet, "Rezerwacja", this);
            RezerwacjaGrid.Visible = !RezerwacjaGrid.Visible;
            UpdateBT.Visible = false;
            RezerwacjaGrid.AllowUserToAddRows = false;
            RezerwacjaGrid.AllowUserToDeleteRows = false;
            RezerwacjaGrid.Visible = true;
            RezerwacjaGrid.ReadOnly = true;
            RezerwacjaGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (UtworGrid != null) UtworGrid.Visible = false;
            if (PokojeGrid != null) PokojeGrid.Visible = false;
            if (KlienciGrid != null) KlienciGrid.Visible = false;
        }

        string klienciQuerry= "select osoba.O_ID as ID, Osoba.O_Imie as Imie,Osoba.O_Nazwisko as Nazwisko, Osoba.O_Mail as Mail, Osoba.O_Tel as Telefon from Database_1.dbo.Osoba";
        private void SelectClients_Click(object sender, EventArgs e)
        {
            Dictionary.SelectData(klienciQuerry, false, ref KlienciGrid, flowLayoutPanel1, ref KlienciAdapter, ref KlienciDataSet, "Osoba", this);
            KlienciGrid.Visible = !KlienciGrid.Visible;
            KlienciGrid.Columns[0].Visible = false;
            UpdateBT.Visible = true;
            KlienciGrid.Visible = true;
            KlienciGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (UtworGrid != null) UtworGrid.Visible = false;
            if (PokojeGrid != null) PokojeGrid.Visible = false;
            if (RezerwacjaGrid != null) RezerwacjaGrid.Visible = false;
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
        #endregion
    }
}
