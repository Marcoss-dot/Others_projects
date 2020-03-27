using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Phone
{
    public partial class Phone : Form
    {
        string _rememberedMobile;
        bool _firstTry = true;

        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = TelePhone; Integrated Security = True");

        public Phone()
        {
            InitializeComponent();
        }

        private void Phone_Load(object sender, EventArgs e)
        {
            Display();

        }

        private void button4_Click(object sender, EventArgs e) // Update button
        {
            if (textBox3.Text == _rememberedMobile)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE Mobiles 
                                            SET First='" + textBox1.Text + "', Last='" + textBox2.Text + "', Mobile='" + textBox3.Text + "', Email='" + textBox4.Text + "', Category='" + comboBox1.Text + "' " +
                                                " WHERE Mobile ='" + textBox3.Text + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated successfully...!");
            }
            else
            {
                var newMobile = textBox3.Text;
                textBox3.Text = _rememberedMobile;
                button3.PerformClick(); // delete old member
                textBox3.Text = newMobile;
                button2.PerformClick(); // add new member
            }
            Display();
        }

        private void button3_Click(object sender, EventArgs e) // Delete Button
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Mobiles WHERE Mobile ='" + textBox3.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            
            MessageBox.Show("Deleted successfully...!");
            Display();

           // button1.PerformClick(); // clear
        }

        private void button2_Click(object sender, EventArgs e) // Insert Button
        {
            textBox1.Text = WriteCapitalLeter(textBox1.Text);
            textBox2.Text = WriteCapitalLeter(textBox2.Text);

            con.Open();
            SqlCommand cmd = new SqlCommand(@"Select Mobile from Mobiles
                                                where Mobile = '" + textBox3.Text+"' ", con);
            SqlDataReader reader = cmd.ExecuteReader();

            bool isExistMobile = false;
            if (reader.Read())
                isExistMobile = true;

            con.Close();

            if ( isExistMobile )
            {
                MessageBox.Show("This Mobile number already exist.");
            }
            else if ((textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || comboBox1.Text != "")&& _firstTry)
            {
                MessageBox.Show("Some text box is empty!");
                _firstTry = false;
            }
            else if (textBox1.Text != "" && textBox3.Text != "")
            {
                con.Open();
                cmd = new SqlCommand(@"INSERT INTO Mobiles(First, Last, Mobile, Email, Category) 
                                                VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Saved successfully...!");
                Display();

                _firstTry = true;
                button1.PerformClick(); // clear
            }
            else
            {
                MessageBox.Show("First Name and Mobile cannot empty!");
            }
        }


        private void button1_Click(object sender, EventArgs e) // Clear button
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();

        }

        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Mobiles", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                // dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Rows[n].Cells[i].Value = item[i].ToString();
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                _rememberedMobile = textBox3.Text;
            }
            catch (Exception)
            {
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter(@"Select * from Mobiles Where (Mobile like '%"+textBox5.Text+"%') " +
                                                    "or (First like '%"+textBox5.Text+"%')" +
                                                    "or (Last like '%" + textBox5.Text + "%')" +
                                                    "or (Email like '%" + textBox5.Text + "%')" +
                                                    "or (Category like '" + textBox5.Text + "%') "
                                                    , con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                // dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Rows[n].Cells[i].Value = item[i].ToString();
                }
            }
        }

        string WriteCapitalLeter(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (i==0)
                {
                    result += text[0].ToString().ToUpper();
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }

    }
}
