using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelDesktopSql.Pracownik
{
    public partial class PracownikForm : Form
    {
        //Pracownicy Aktualnypracownik;
        public PracownikForm(PracownicyItem _Aktualnypracownik)
        {
            InitializeComponent();
        }
        //{
        //    
        //    this.FormBorderStyle = Dictionary.Dc_borderStyle;
        //    Aktualnypracownik = _Aktualnypracownik;
        //    daneZamowieniaQuerry += "where Zamowienia.Pr_ID=" + Aktualnypracownik.Pr_ID + " or Zamowienia.Pr_ID='0' Order by Za_CzyZrealizowano asc";
        //    Dictionary.DesignButton(CloseBT);
        //    Dictionary.DesignButton(CloseBT);
        //    Dictionary.DesignButton(SelectClients);
        //    Dictionary.DesignButton(SelectZamowienia);
        //    Dictionary.DesignButton(EditTowary);
        //    Dictionary.DesignButton(InsertTowar);
        //    Dictionary.DesignButton(ModWykonawcy);
        //    Dictionary.DesignButton(UpdateBT);
        //    Dictionary.DesignButton(LogoutBT);
        //    this.BackColor = Dictionary.BackColor;
        //}
        //SqlDataAdapter KlienciAdapter, ZamowienieAdapter, TowarAdapter, UtworAdapter;
        //DataSet KlienciDataSet, ZamowienieDataSet, TowarDataSet, UtworDataSet;
        //DataGridView KlienciGrid, ZamowienieGrid, TowarGrid, UtworGrid;

        //string klienciQuerry = "SELECT [Kl_ID],[Kl_Imie] ,[Kl_Nazwisko] ,[Kl_Pesel],[Kl_Mail],[Kl_Adres]FROM[SklepMuzycznyV2].[dbo].[Klienci]";

        //int lastUtworIndex = 0;
        //private void UpdateBT_Click(object sender, EventArgs e)
        //{
        //    Dictionary.UpdateData(ref TowarDataSet, ref TowarAdapter, "Towar", ref TowarGrid, TowarQuerry, this, flowLayoutPanel1);
        //    DataGridView temp = new DataGridView();
        //    temp = UtworGrid;
        //    if (UtworGrid != null)
        //    {
        //        string query = "";
        //        for (int i = 0; i < lastUtworIndex - 1; i++)
        //        {
        //            query = "update SklepMuzycznyV2.dbo.Utwor set Ut_Name = '" + UtworGrid[1, i].Value.ToString() + "',Ut_CzasUtworu='" + ((UtworGrid[2, i].Value == null) ? "0:00" : UtworGrid[2, i].Value.ToString()) + "' where Ut_ID =" + UtworGrid[0, i].Value + ";";
        //            SqlConnection con = new SqlConnection("Data Source=DESKTOP-KL9U024; Initial Catalog=SklepMuzycznyV2;Integrated Security=SSPI");
        //            DataSet ds = new DataSet();
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        for (int i = lastUtworIndex - 1; i < UtworGrid.Rows.Count - 1; i++)
        //        {
        //            string query1;
        //            if (UtworGrid.Rows[i].Cells[2].Value.ToString().Equals(""))
        //                query1 = "insert into SklepMuzycznyV2.dbo.Utwor (To_ID,Ut_Name,Ut_CzasUtworu) values(" + TowarGrid.Rows[TowarGrid.SelectedCells[0].RowIndex].Cells[0].Value + ",'" + UtworGrid.Rows[i].Cells[1].Value + "','0:00')";
        //            else
        //                query1 = "insert into SklepMuzycznyV2.dbo.Utwor (To_ID,Ut_Name,Ut_CzasUtworu) values(" + TowarGrid.Rows[TowarGrid.SelectedCells[0].RowIndex].Cells[0].Value + ",'" + UtworGrid.Rows[i].Cells[1].Value + "','" + UtworGrid.Rows[i].Cells[2].Value + "')";
        //            Dictionary.InsertData(query1, "Utwory");
        //        }

        //    }
        //    UtworGrid.Visible = false;
        //}

        //private void ModWykonawcy_Click(object sender, EventArgs e)
        //{
        //    DodajWykonawce window = new DodajWykonawce();
        //    this.Hide();
        //    if (window.ShowDialog() == DialogResult.OK)
        //    {
        //        this.Show();
        //    }
        //}
        //private void InsertTowar_Click(object sender, EventArgs e)
        //{
        //    DodajTowar dodajTowar = new DodajTowar();
        //    this.Hide();
        //    if (dodajTowar.ShowDialog() == DialogResult.OK)
        //    {
        //        this.Show();
        //    }
        //}
        ////string UtworQuery = "SELECT [Ut_Name],[Ut_CzasUtworu]FROM[SklepMuzycznyV2].[dbo].[Utwor]";
        //string TowarQuerry = "SELECT [To_ID],[To_Nazwa],[To_CenaAktualna],[To_IloscNaStanie] FROM[SklepMuzycznyV2].[dbo].[Towar]";
        //private void EditTowary_Click(object sender, EventArgs e)
        //{

        //    Dictionary.SelectData(TowarQuerry, true, ref TowarGrid, flowLayoutPanel1, ref TowarAdapter, ref TowarDataSet, "Towar", this);
        //    TowarGrid.AllowUserToDeleteRows = false;
        //    TowarGrid.CellClick += TowarGrid_CellClick;
        //    UpdateBT.Visible = true;
        //    TowarGrid.AllowUserToAddRows = false;
        //    TowarGrid.Columns[0].Visible = false;
        //    TowarGrid.Visible = true;
        //    if (ZamowienieGrid != null) ZamowienieGrid.Visible = false;
        //    if (KlienciGrid != null) KlienciGrid.Visible = false;
        //}

        //private void TowarGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string UtworQuery = "SELECT [Ut_ID],[Ut_Name],[Ut_CzasUtworu]FROM[SklepMuzycznyV2].[dbo].[Utwor] where To_ID = " + TowarGrid.Rows[TowarGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
        //    Dictionary.SelectData(UtworQuery, true, ref UtworGrid, flowLayoutPanel1, ref UtworAdapter, ref UtworDataSet, "Utwor", this);
        //    lastUtworIndex = UtworGrid.Rows.Count;
        //    UtworGrid.AllowUserToDeleteRows = false;
        //    //UtworGrid.AllowUserToAddRows = false;
        //    UtworGrid.Visible = true;
        //    UtworGrid.Columns[0].Visible = false;

        //}

        //string daneZamowieniaQuerry = "select Zamowienia.Za_ID as ID,Towar.To_Nazwa as Nazwa," +
        //                              "ListaTowarow.Li_IloscTowaru as IloscTowaru," +
        //                              "ListaTowarow.Li_Cena_Zakupu as CenaZakupu," +
        //                              "Klienci.Kl_Imie as KlImie,Klienci.Kl_Nazwisko as KlNazwisko," +
        //                              "Klienci.Kl_Mail as Mail," +
        //                              "Klienci.Kl_Adres as Adres,Left(Zamowienia.Za_KiedyKupione,11) as 'Kupione Dnia',Left(Zamowienia.Za_NaKiedy,11) as 'Realizacja na',Zamowienia.Za_CzyZrealizowano as CzyZrealizowano,Pracownicy.Pr_Imie as PrImie,Pracownicy.Pr_Nazwisko as PrNazwisko " +
        //                              "from SklepMuzycznyV2.dbo.Zamowienia " +
        //                              "inner join SklepMuzycznyV2.dbo.Klienci on Zamowienia.Kl_ID= Klienci.Kl_ID " +
        //                              "inner join SklepMuzycznyV2.dbo.Pracownicy on Zamowienia.Pr_ID= Pracownicy.Pr_ID " +
        //                              "inner join SklepMuzycznyV2.dbo.ListaTowarow on Zamowienia.Za_ID= ListaTowarow.Za_ID " +
        //                              "inner join SklepMuzycznyV2.dbo.Towar on ListaTowarow.To_ID= Towar.To_ID ";
        //private void SelectZamowienia_Click(object sender, EventArgs e)
        //{
        //    Dictionary.SelectData(daneZamowieniaQuerry, false, ref ZamowienieGrid, flowLayoutPanel1, ref ZamowienieAdapter, ref ZamowienieDataSet, "Zamowienia", this);
        //    ZamowienieGrid.Visible = !ZamowienieGrid.Visible;
        //    UpdateBT.Visible = false;
        //    ZamowienieGrid.AllowUserToAddRows = false;
        //    ZamowienieGrid.AllowUserToDeleteRows = false;
        //    ZamowienieGrid.Visible = true;
        //    ZamowienieGrid.Columns[0].Visible = false;
        //    ZamowienieGrid.Columns[11].Visible = false;
        //    ZamowienieGrid.Columns[12].Visible = false;
        //    if (UtworGrid != null) UtworGrid.Visible = false;
        //    if (TowarGrid != null) TowarGrid.Visible = false;
        //    if (KlienciGrid != null) KlienciGrid.Visible = false;
        //}

        //private void SelectClients_Click(object sender, EventArgs e)
        //{
        //    Dictionary.SelectData(klienciQuerry, false, ref KlienciGrid, flowLayoutPanel1, ref KlienciAdapter, ref KlienciDataSet, "Klienci", this);
        //    KlienciGrid.Visible = !KlienciGrid.Visible;
        //    UpdateBT.Visible = false;
        //    KlienciGrid.Visible = true;
        //    if (UtworGrid != null) UtworGrid.Visible = false;
        //    if (TowarGrid != null) TowarGrid.Visible = false;
        //    if (ZamowienieGrid != null) ZamowienieGrid.Visible = false;
        //}
        //protected void Close_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
        //protected void Logout_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //    DialogResult = DialogResult.OK;
        //}
    }
}
