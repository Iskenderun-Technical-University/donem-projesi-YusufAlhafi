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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace donem_projesi_YousefAlhafi
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\YUSUF AL-HAFI\Desktop\c# donem-projesi-Yousef Alhafi 212503511\donem-projesi-YousefAlhafi\donem-projesi-YousefAlhafi\Database.mdf"";Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }
        public static bool check(string str)
        {
            return (String.IsNullOrEmpty(str) ||
                str.Trim().Length == 0) ? true : false;
        }
        public DataTable LoadUserTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM PatientTab";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

 

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.PatientTab' table. You can move, or remove it, as needed.
            this.patientTabTableAdapter.Fill(this.databaseDataSet.PatientTab);
            dataGridView1.DataSource = LoadUserTable();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check(textBox1.Text) == true || check(textBox2.Text) == true || check(textBox3.Text) == true || check(textBox4.Text) == true)
            {
                MessageBox.Show("please enter the required data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "insert into PatientTab (PatientName , PatientAge , PhoneNumber , DoctorName ) values ( @PatientName , @PatientAge ,@PhoneNumber ,@DoctorName ) ";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PatientName", textBox1.Text);
                cmd.Parameters.AddWithValue("@PatientAge", textBox2.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);
                cmd.Parameters.AddWithValue("@DoctorName", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added");
                dataGridView1.DataSource = LoadUserTable();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                }

            }

            catch (Exception)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check(textBox1.Text) == true || check(textBox2.Text) == true || check(textBox3.Text) == true || check(textBox4.Text) == true)
            {
                MessageBox.Show("please enter the required data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "UPDATE PatientTab set PatientName=@PatientName ,PatientAge=@PatientAge ,PhoneNumber=@PhoneNumber,DoctorName=@DoctorName where id = '" + dataGridView1.CurrentRow.Cells[0].Value +"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@PatientName", textBox1.Text);
                cmd.Parameters.AddWithValue("@PatientAge", textBox2.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);
                cmd.Parameters.AddWithValue("@DoctorName", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("updated successfully");
                dataGridView1.DataSource = LoadUserTable();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (check(textBox1.Text) == true || check(textBox2.Text) == true || check(textBox3.Text) == true || check(textBox4.Text) == true)
            {
                MessageBox.Show("please enter the required data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string query = "DELETE FROM PatientTab WHERE id= '" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("deleted successfully");
                dataGridView1.DataSource = LoadUserTable();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            }
        }
    }
}
