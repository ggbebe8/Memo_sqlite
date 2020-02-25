using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Arrangement
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        private void fnQuery()
        {
            DataTable dt = new DataTable();
            string strSQL = txtQuery.Text;
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=.\Contents.db");
            conn.Open();
            try
            {
                SQLiteDataAdapter Ap = new SQLiteDataAdapter(strSQL, conn);
                Ap.Fill(dt);
                dteShow.DataSource = dt;
                MessageBox.Show("Äõ¸®¼º°ø");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Dispose();
        }

        private void txtQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                fnQuery();
            else if (e.KeyCode == Keys.F4)
                txtQuery.Clear();
        }
    }
}