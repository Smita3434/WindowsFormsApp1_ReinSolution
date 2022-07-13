using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApp1_ReinSolution
{
    public partial class Form5 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form5()
        {
            InitializeComponent();
            //step1
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //step2
                string qry = "insert into Employee values(@Name,@Salary)";
                // step3
                cmd = new SqlCommand(qry, con);
                //step4
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(textBox3.Text));
                //step5
                con.Open();
                //step6
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Success! Record inserted");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from Employee where Id=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
                con.Open();
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        textBox2.Text = dr["Name"].ToString();
                        textBox3.Text = dr["Salary"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //step2
                string qry = "update Employee set Name=@Name,Salary=@Salary where Id=@id";
                // step3
                cmd = new SqlCommand(qry, con);
                //step4
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(textBox3.Text));
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
                //step5
                con.Open();
                //step6
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Success! Record Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //step2
                string qry = "delete from Employee where Id=@id";
                // step3
                cmd = new SqlCommand(qry, con);
                //step4
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
                //step5
                con.Open();
                //step6
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Success! Record Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            finally
            {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from Employee ";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                { 
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        empGridView.DataSource = dt;
                    
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
