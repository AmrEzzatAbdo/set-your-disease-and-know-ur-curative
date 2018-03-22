using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=KARIM_HAGAGI_PC;Initial Catalog=S.U.D&&N.U.C;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public static string constr = "Data Source=KARIM_HAGAGI_PC;Initial Catalog=S.U.D&&N.U.C;Integrated Security=True";

        public Form1()
        {
            

            InitializeComponent();

            this.Size = new Size(407, this.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (textBox1.Text != "")
                    {
                        SqlConnection con = new SqlConnection(constr);
                        SqlCommand cmd = new SqlCommand("select_all", con);
                        cmd.Parameters.Add(new SqlParameter("@C_Name", textBox1.Text));
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //DataSet ds = new DataSet();
                        //da.Fill(ds, "x");
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    else
                        dataGridView1.DataSource = null;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (textBox1.Text != "")
                    {
                        SqlConnection con = new SqlConnection(constr);
                        SqlCommand cmd = new SqlCommand("select_all_by_id", con);
                        cmd.Parameters.Add(new SqlParameter("@C_ID", textBox1.Text));
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //DataSet ds = new DataSet();
                        //da.Fill(ds, "x");
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    else
                        dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void test_Click(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("insert into Curative (C_Name,C_Information,C_Side_Effect,C_Reason) values('" + TxtCn.Text + "','" + TxtCi.Text + "','" + TxtCs.Text + "','" + TxtCr.Text + "' ) ", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your information added successfully ", "user Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("some errors was occured " + ex.Message);

            }
            finally
            {
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Select C_Name,C_Information,C_Side_Effect,C_Reason From Curative Where C_ID=" + TxtId.Text + "", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                TxtName.Text = dr["C_Name"].ToString();
                TxtInfo.Text = dr["C_Information"].ToString();
                TextSide.Text = dr["C_Side_Effect"].ToString();
                TxtReason.Text = dr["C_Reason"].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("sume errors was occured " + ex.Message);
            }
            finally
            {
                dr.Close();
                cn.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Update Curative Set C_Name='" + TxtName.Text + "',C_Information='" + TxtInfo.Text + "',C_Side_Effect='" + TextSide.Text + "',C_Reason='" + TxtReason.Text + "' Where C_ID=" + TxtId.Text + " ", cn);
               
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Errore Update " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" If you one of the admins enter user and password ", "attintion", MessageBoxButtons.OK);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Size = new Size(742, this.Height);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Size = new Size(742, this.Height);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Size = new Size(407, this.Height);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Admin.Text == "Amr Ezzat" && AdminPass.Text == "1271997")
            {
                this.Size = new Size(1098, this.Height);
            }
            else
                MessageBox.Show("User name or password invalid ", "attintion", MessageBoxButtons.OK);
        }

        
    }
}
