using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using HotelDesktopSql.PracownikF;

namespace HotelDesktopSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = Dictionary.Dc_borderStyle;
            this.Text = "Logowanie";
            LoginTB.Text = "Bartosz";
            PasswordTB.Text = "Gronostaj";
            this.BackColor = Dictionary.BackColor;
            label1.ForeColor = Dictionary.ForeColor;
            label2.ForeColor = Dictionary.ForeColor;

            Zaloguj.BackColor = Dictionary.ButtonBackColor;
            Zaloguj.ForeColor = Dictionary.ForeColor;
            Exit.BackColor = Dictionary.ButtonBackColor;
            Exit.ForeColor = Dictionary.ForeColor;
            BaseOperation(query, query2);
        }

        string query = "select Osoba.O_ID, Osoba.O_Imie,Osoba.O_Nazwisko from Database_1.dbo.Osoba";
        string query2 ="select Pracownik.Pra_ID,Pracownik.Pra_Login,Pracownik.Pra_Haslo from Database_1.dbo.Pracownik";

        List<Osoba> klienci = new List<Osoba>();
        List<Pracownik> pracownicy = new List<Pracownik>();

        private void BaseOperation(string query, string query2)
        {
            using (SqlConnection sqlConn = new SqlConnection(Dictionary.connectionString))
            using (SqlCommand cmd = new SqlCommand(query, sqlConn))
            {
                sqlConn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow x = dt.Rows[i];
                    klienci.Add(new Osoba()
                    {
                        O_ID = x.Field<Int32>(0),
                        O_Imie = x.Field<string>(1),
                        O_Nazwisko = x.Field<string>(2)
                    });
                }
            }
            using (SqlConnection sqlConn = new SqlConnection(Dictionary.connectionString))
            using (SqlCommand cmd = new SqlCommand(query2, sqlConn))
            {
                sqlConn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow x = dt.Rows[i];
                    pracownicy.Add(new Pracownik()
                    {
                        Pr_ID = x.Field<Int32>(0),
                        Pr_Imie = x.Field<string>(1),
                        Pr_Nazwisko = x.Field<string>(2)
                    });
                }
            }
        }

        private void Zaloguj_Click(object sender, EventArgs e)
        {

            if (!LogAsEmployee()&& !LogAsClient())
                MessageBox.Show("Błędne dane. Spróbuj ponownie.");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private bool LogAsEmployee()
        {
            for (int i = 0; i < pracownicy.Count; i++)
            {
                if (pracownicy[i].Pr_Imie.Equals(LoginTB.Text) && pracownicy[i].Pr_Nazwisko.Equals(PasswordTB.Text))
                {
                    PracownikForm PracownikWindow = new PracownikForm(pracownicy[i]);
                    Hide();
                    if (PracownikWindow.ShowDialog() == DialogResult.OK)
                    {
                        LoginTB.Text = "";
                        PasswordTB.Text = "";
                        Show();
                    }
                    return true;
                }
            }
            return false;
        }

        private bool LogAsClient()
        {
            for (int i = 0; i < klienci.Count; i++)
            {
                if (klienci[i].O_Imie.Equals(LoginTB.Text) && klienci[i].O_Nazwisko.Equals(PasswordTB.Text))
                {
                    Klient.KlientForm KlientWindow = new Klient.KlientForm(klienci[i]);
                    this.Hide();
                    if (KlientWindow.ShowDialog() == DialogResult.OK)
                    {
                        LoginTB.Text = "";
                        PasswordTB.Text = "";
                        this.Show();
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
