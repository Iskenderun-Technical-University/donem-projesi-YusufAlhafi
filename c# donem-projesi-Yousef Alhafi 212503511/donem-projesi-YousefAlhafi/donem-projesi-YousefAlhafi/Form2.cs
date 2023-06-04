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

namespace donem_projesi_YousefAlhafi
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\YUSUF AL-HAFI\Desktop\c# donem-projesi-Yousef Alhafi 212503511\donem-projesi-YousefAlhafi\donem-projesi-YousefAlhafi\Database.mdf"";Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[1].Show();
            this.Close();
        }
        public DataTable LoadUserTable()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM DoctorTab";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static bool check(string str)
        {
            return (String.IsNullOrEmpty(str) ||
                str.Trim().Length == 0) ? true : false;
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet1.DoctorTab' table. You can move, or remove it, as needed.
            this.doctorTabTableAdapter.Fill(this.databaseDataSet1.DoctorTab);
            dataGridView1.DataSource = LoadUserTable();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check(textBox1.Text) == true || check(textBox2.Text) == true || check(textBox3.Text) == true || check(textBox4.Text) == true)
            {
                MessageBox.Show("please enter the required data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "insert into DoctorTab (DoctorName , Specialization , YearsOfExperience , PhoneNumber ) values ( @DoctorName , @Specialization ,@YearsOfExperience ,@PhoneNumber) ";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Specialization", textBox2.Text);
                cmd.Parameters.AddWithValue("@YearsOfExperience", textBox3.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added");
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
                string query = "UPDATE DoctorTab set DoctorName=@DoctorName ,Specialization=@Specialization ,YearsOfExperience=@YearsOfExperience,PhoneNumber=@PhoneNumber where id = '" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DoctorName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Specialization", textBox2.Text);
                cmd.Parameters.AddWithValue("@YearsOfExperience", textBox3.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("updated successfully");
                dataGridView1.DataSource = LoadUserTable();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (check(textBox1.Text) == true || check(textBox2.Text) == true || check(textBox3.Text) == true || check(textBox4.Text) == true)
            {
                MessageBox.Show("please enter the required data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                string query = "DELETE FROM DoctorTab WHERE id= '" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("deleted successfully");
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
    }
}
