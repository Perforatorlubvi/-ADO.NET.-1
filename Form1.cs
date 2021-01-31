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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataReader dr = null;
        SqlCommand cmd = null;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fruits_vegetables;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                MessageBox.Show("Успех");
            }
            else
            {
                MessageBox.Show("Попробуйте ище раз");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            if(conn.State == ConnectionState.Closed)
            {
                MessageBox.Show("Вы отключены");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr.GetString(0)+"\t" + dr.GetString(1) + "\t" + dr.GetString(2) + "\t"+ dr.GetInt32(3)+"\r\n";


            }
            dr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select Name from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr.GetString(0) +"\r\n";


            }
            dr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select color from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr.GetString(0) + "\r\n";


            }
            dr.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select max(Calorie) from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr.GetInt32(0) + "\r\n";


            }
            dr.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select min(Calorie) from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr.GetInt32(0) + "\r\n";
            }
            dr.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select avg(Calorie) from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr.GetInt32(0) + "\r\n";
            }
            dr.Close();
        }
        int countv = 0;
        int countf = 0;
        private void Form1_Shown(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fruits_vegetables;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "select type from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetString(0).ToLower() == "vegetable")
                {
                    countv++;
                }
                if (dr.GetString(0).ToLower() == "fruit")
                {
                    countf++;
                }
            }
            label4.Text = countv.ToString();
            label1.Text = countf.ToString();
            dr.Close();
        }
      

        int countC;
        private void button9_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select color from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetString(0).ToLower() ==textBox2.Text.ToLower())
                {
                    countC++;
                }
                else
                {
                    textBox1.Text = "Nothing";
                }

            }
            textBox1.Text = countC.ToString();

            dr.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetInt32(3) < int.Parse(textBox2.Text))
                {
                    textBox1.Text += dr.GetString(0) + "\t" + dr.GetString(1) + "\t" + dr.GetString(2) + "\t" + dr.GetInt32(3) + "\r\n";
                }
                else
                {
                    textBox1.Text = "Nothing";
                }

            }
            dr.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetInt32(3) > int.Parse(textBox2.Text))
                {
                    textBox1.Text += dr.GetString(0) + "\t" + dr.GetString(1) + "\t" + dr.GetString(2) + "\t" + dr.GetInt32(3) + "\r\n";
                }
                else
                {
                    textBox1.Text = "Nothing";
                }

            }
            dr.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetInt32(3) > int.Parse(textBox3.Text)&& dr.GetInt32(3) < int.Parse(textBox4.Text))
                {
                    textBox1.Text += dr.GetString(0) + "\t" + dr.GetString(1) + "\t" + dr.GetString(2) + "\t" + dr.GetInt32(3) + "\r\n";
                }
               
            }
            dr.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cmd = new SqlCommand();
            cmd.CommandText = "select * from Vegetables_fruts";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetString(2).ToLower() =="yellow" || dr.GetString(2).ToLower() =="red")
                {
                    textBox1.Text += dr.GetString(0) + "\t" + dr.GetString(1) + "\t" + dr.GetString(2) + "\t" + dr.GetInt32(3) + "\r\n";
                }
               
            }
            dr.Close();
        }
    }
}
