using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BetaMart
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\LMS.Class\KK3\Project\BetaMart\BetaMart\Betamart.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand comm = new OleDbCommand("INSERT into Goods (Name, Stock, Price, ExpiredDate)VALUES('" + txtName.Text + "'," + txtSort.Text + ", " + txtBrand.Text + ", '" + txtED.Text + "')", con);
            comm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data telah ditambahkan :D");

            clearText();
            fillgrid();
        }
        void fillgrid()
        {
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * from Goods order by ID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand comm = new OleDbCommand("UPDATE Goods set Name='" + txtName.Text + "', Stock=" + txtSort.Text + ", Price=" + txtBrand.Text + ", ExpiredDate='" + txtED.Text + "' Where ID=" + txtID.Text + " ", con);
            comm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data telah diubah :D");

            clearText();
            fillgrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand comm = new OleDbCommand("DELETE from Goods Where ID=" + txtID.Text + "", con);
            comm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data telah dihapus :D");

            clearText();
            fillgrid();
        }
        void clearText()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtSort.Text = "";
            txtBrand.Text = "";
            txtED.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillgrid();
        }


    }
}
