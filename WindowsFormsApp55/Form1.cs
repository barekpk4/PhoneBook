using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp55
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-P7K57AH\SQLEXPRESS;Initial Catalog=crud;Integrated Security=true;");

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = txtFN.Text;
            string lname = txtLF.Text;
            int mobile = Convert.ToInt32(txtMN.Text);
            string email = txtE.Text;
            string relation = txtR.Text;
            string city = (comboBox1.SelectedItem).ToString();



            SqlCommand cmd = new SqlCommand("insert into phone values('" + fname + "','" + lname + "'," + mobile + ",'" + email + "','" + relation + "','" + city + "')", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ClearAll();
            LoadData();

        }
        private void LoadData()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select*from phone", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void ClearAll()
        {
            txtFN.Clear();
            txtLF.Clear();
            txtMN.Focus();
            txtE.Clear();
            txtR.Clear(); //this is a little mistake//
                          // comboBox1.
            comboBox1.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = txtFN.Text;
            string lname = txtLF.Text;
            int mobile = Convert.ToInt32(txtMN.Text);
            string email = txtE.Text;
            string relation = txtR.Text;
            string city = (comboBox1.SelectedItem).ToString();


            SqlCommand cmd = new SqlCommand("update phone set fname='" + fname + "',lname='" + lname + "',email='" + email + "',relation='" + relation + "',city='" + city + "' where mobile='" + mobile + "'", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ClearAll();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int mobile = Convert.ToInt32(txtMN.Text);

            SqlDataAdapter sda = new SqlDataAdapter("select * from phone where mobile ='" + mobile + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtFN.Text = dt.Rows[0][0].ToString();
                txtLF.Text = dt.Rows[0][1].ToString();

                txtE.Text = dt.Rows[0][3].ToString();
                txtR.Text = dt.Rows[0][4].ToString();
                comboBox1.Text = dt.Rows[0][5].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int mobile = Convert.ToInt32(txtMN.Text);
            SqlCommand cmd = new SqlCommand("DELETE   FROM PHONE WHERE mobile='" + mobile + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadData();
        }
    }
}
