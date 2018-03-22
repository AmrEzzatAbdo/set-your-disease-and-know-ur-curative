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
    public partial class Form2 : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=KARIM_HAGAGI_PC;Initial Catalog=S.U.D&&N.U.C;Integrated Security=True");
        SqlCommand cmd;
        private const int Constant = 1;
    
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
                cmd = new SqlCommand("insert into Useres (U_Name,U_Age,U_Gender,U_Curative_Search) values('" + TxtName.Text + "'," + TxtAge.Text + ",'" + TxtG.Text+ "','" + TxtDisease.Text + "' ) ", cn);
                cn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your information added successfully ","user Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            DialogResult Result = MessageBox.Show("");
            if (Result==DialogResult.OK)
            {
                Form1 f2 = new Form1();
                f2.Show();
                this.Hide();
            }
            }
            catch(SqlException ex){
            MessageBox.Show("sume errors was occured "+ex.Message);
            
            }
            finally{
            cn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public string TxtGender { get; set; }
    }
}
