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
    public partial class KlientRezerwuj : Form
    {
        //Klient
        Osoba klient; //trzeba pobierać z wczesniej przy logowaniu

        //Zamowienie
        DateTime KiedyKupiono = new DateTime();

        //ListaTowarow
        List<Pokoj> NowaListaTowarow = new List<Pokoj>();

        List<Pokoj> Rachunek = new List<Pokoj>();

        public KlientRezerwuj(Osoba _aktualnyKlient)
        {
            InitializeComponent();
            this.FormBorderStyle = Dictionary.Dc_borderStyle;
            fillDefaultComponents();
            klient = _aktualnyKlient;
            aktualizujGrida();
            this.BackColor = Dictionary.BackColor;
            Dictionary.DesignButton(SearchBT);
            Dictionary.DesignButton(Ok);
            Dictionary.DesignButton(Anuluj);
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            KiedyKupiono = DateTime.Now;
            if (dateFrom.Value > dateTo.Value)
            {
                MessageBox.Show("Ustawiłeś błędny zakres dni rezerwacji");
            }
            else if (dateFrom.Value < KiedyKupiono.AddDays(0))
            {
                MessageBox.Show("Nie możesz dokonać rezerwacji na dni ktore przeminęły");
            }
            else
            {
                string idPokoju;
                try
                {
                    idPokoju = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Zaznacz interesujący cię pokój (wiersz)");
                    return;
                }
                string DataRezerwacji = "'" + KiedyKupiono.Year + "." +
                                        ((KiedyKupiono.Month < 10)
                                            ? ("0" + KiedyKupiono.Month.ToString())
                                            : KiedyKupiono.Month.ToString()) + "." +
                                        ((KiedyKupiono.Day < 10)
                                            ? "0" + KiedyKupiono.Day.ToString()
                                            : KiedyKupiono.Day.ToString()) + "'";
                var x = dateFrom.Value;
                string RezerwacjaOd = "'" + x.Year + "." +
                                      ((x.Month < 10) ? ("0" + x.Month.ToString()) : x.Month.ToString()) + "." +
                                      ((x.Day < 10) ? "0" + x.Day.ToString() : x.Day.ToString()) + "'";
                x = dateTo.Value;
                string RezerwacjaDo = "'" + x.Year + "." +
                                      ((x.Month < 10) ? ("0" + x.Month.ToString()) : x.Month.ToString()) + "." +
                                      ((x.Day < 10) ? "0" + x.Day.ToString() : x.Day.ToString()) + "'";

                var query = "insert into Database_1.dbo.Rezerwacja(R_Kiedy, R_NaKiedy, R_DoKiedy, O_ID)" +
                            "values(" + DataRezerwacji + "," + RezerwacjaOd + "," + RezerwacjaDo + "," + klient.O_ID +
                            ")";
                Dictionary.InsertData(query, "Zamowienia");
                //dodanie jeszcze do asocjacji połaczenie z pokojem
                DataGridView temp = new DataGridView();
                SqlDataAdapter tempAdap = new SqlDataAdapter();
                DataSet tempDataset = new DataSet();
                query =
                    "select Rezerwacja.R_ID ,Rezerwacja.R_Kiedy from Database_1.dbo.Rezerwacja where Rezerwacja.R_Kiedy = " +
                    DataRezerwacji + "";
                Dictionary.SelectData(query, false, ref temp, new Panel(), ref tempAdap, ref tempDataset, "Zamowienia",
                    this);
                int idRezerwacji = tempDataset.Tables[0].Rows[tempDataset.Tables[0].Rows.Count - 1].Field<int>(0);
                query = "insert into Database_1.dbo.Relationship_2(P_ID, R_ID)" +
                        "values(" + idPokoju + "," + idRezerwacji + ")";
                Dictionary.InsertData(query, "Relationsip_2");
            }

            this.Close();
        }

        private void fillDefaultComponents()
        {
            string przeglądanieListyTowarów = "select Pokoj.P_IluOsobowy from Pokoj group by Pokoj.P_IluOsobowy";
            BaseOperation(dataGridView1, przeglądanieListyTowarów, 1);
        }

        private void BaseOperation(DataGridView Grid, string query, int ListType)
        {
            using (SqlConnection sqlConn = new SqlConnection(Dictionary.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, sqlConn))
            {
                sqlConn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                Grid.DataSource = dt;
                if (ListType == 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow x = dt.Rows[i];
                        NowaListaTowarow.Add(new Pokoj(x.Field<Int32>(0)));
                        comboBox1.Items.Add(NowaListaTowarow[i].IluOsobowy);
                    }
                }
            }
        }

        private void aktualizujGrida()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = (Rachunek);
            //dataGridView1.Columns[0].Visible = false;
        }

        private void Anuluj_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            //comboBox1.SelectedIndex;
            var x = dateFrom.Value;
            string RezerwacjaOd = "'" + x.Year + "." +
                                  ((x.Month < 10) ? ("0" + x.Month.ToString()) : x.Month.ToString()) + "." +
                                  ((x.Day < 10) ? "0" + x.Day.ToString() : x.Day.ToString()) + "'";
            x = dateTo.Value;
            string RezerwacjaDo = "'" + x.Year + "." +
                                  ((x.Month < 10) ? ("0" + x.Month.ToString()) : x.Month.ToString()) + "." +
                                  ((x.Day < 10) ? "0" + x.Day.ToString() : x.Day.ToString()) + "'";

            var query = "select DISTINCT " +
                        "Pokoj.P_ID, " +
                        "Pokoj.P_Nr as NrPokoju, " +
                        "Pokoj.P_KosztDzienny as KosztDzienny" +
                        " from Pokoj" +
                        " where " +
                        " Pokoj.P_IluOsobowy = " + comboBox1.Items[comboBox1.SelectedIndex].ToString() + " and" +
                        " Pokoj.P_CzyGotowy != 0 and" +
                        " Pokoj.P_ID not in" +
                        " (" +
                        " select Pokoj.P_ID" +
                        " from Pokoj" +
                        " inner join Relationship_2 on Relationship_2.P_ID = Pokoj.P_ID" +
                        " inner join Rezerwacja on Rezerwacja.R_ID = Relationship_2.R_ID" +
                        " where" +
                        " Pokoj.P_IluOsobowy = " + comboBox1.Items[comboBox1.SelectedIndex].ToString() +
                        " and" +
                        " (" +
                        " Rezerwacja.R_NaKiedy <= " + RezerwacjaOd + " and" +
                        " Rezerwacja.R_DoKiedy >= " + RezerwacjaOd + "" +
                        " or" +
                        " Rezerwacja.R_NaKiedy <= " + RezerwacjaDo + " and" +
                        " Rezerwacja.R_DoKiedy >= " + RezerwacjaDo + "" +
                        " )" +
                        " )";
            SqlDataAdapter tempAdap = new SqlDataAdapter();
            DataSet tempDataset = new DataSet();
            Dictionary.SelectData(query, true, ref dataGridView1, new Panel(), ref tempAdap, ref tempDataset, "Pokoj",
                this);
            dataGridView1.Width = this.Width;
            //dataGridView1.Columns[0].Visible = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Invalidate();
        }
    }

    class Pokoj
    {
        public Pokoj(int id)
        {
            IluOsobowy = id;
        }

        public int IluOsobowy { get; private set; }
    }
}
