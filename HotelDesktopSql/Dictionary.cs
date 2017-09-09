using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelDesktopSql
{
    class Dictionary
    {
        public static FormBorderStyle Dc_borderStyle = FormBorderStyle.Sizable;
        public static string connectionString = @"Data Source=DESKTOP-RA0M75M\XXX; Initial Catalog=Database_1;Integrated Security=SSPI"; //important!!!
        public static Color BackColor = Color.DimGray;
        public static Color ForeColor = Color.Wheat;
        public static Color ButtonBackColor = Color.Gray;
        public static Color BorderColor = Color.Transparent;
        public static void DesignButton(Button x)
        {
            x.ForeColor = ForeColor;
            x.BackColor = ButtonBackColor;
            x.FlatStyle = FlatStyle.Flat;
            x.FlatAppearance.BorderSize = 0;
        }
        public static void SelectData(string query, bool gridIsVisible, ref DataGridView grid, Panel Parent, ref SqlDataAdapter adapter, ref DataSet dataSet, string tableName, Form window)
        {
            if (grid == null)
            {
                grid = new DataGridView();
                grid.Visible = gridIsVisible;
                Parent.Controls.Add(grid);
            }
            getData(ref dataSet, ref adapter, tableName, ref grid, query, window);
        }
        public static void UpdateData(ref DataSet dataSet, ref SqlDataAdapter dataAdapter, string tableName, ref DataGridView grid, string query, Form window, Panel panel)
        {
            SqlCommandBuilder cmd = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataSet, tableName);
            getData(ref dataSet, ref dataAdapter, tableName, ref grid, query, window);
        }
        private static void getData(ref DataSet dataSet, ref SqlDataAdapter adapter, string tableName, ref DataGridView grid, string query, Form window)
        {
            using (SqlConnection con = new SqlConnection() { ConnectionString = connectionString })
            {
                con.Open();
                adapter = new SqlDataAdapter(query, connectionString);
                con.Close();
            }
            dataSet = new DataSet();
            adapter.Fill(dataSet, tableName);
            grid.DataSource = dataSet.Tables[0];

            grid.Width = window.MaximumSize.Width - 50;

            //window.Width = grid.Width + 50;
            //panel.Width = grid.Width + 50;
            //window.Height = window.PreferredSize.Height;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public static void InsertData(string querry, string tableName)
        {
            using (SqlConnection con = new SqlConnection() { ConnectionString = connectionString })
            {
                con.Open();
                SqlCommand command = new SqlCommand(querry, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void DeleteData(string query, string table)
        {
            using (SqlConnection con = new SqlConnection() { ConnectionString = connectionString })
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
