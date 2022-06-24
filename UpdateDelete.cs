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

namespace Gym_Management
{
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IChirazi\Gym_Management\GymMngDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from MemberTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            adapter.Fill(ds);
            MembersSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            PhoneTb.Text = "";
            AgeTb.Text = "";
            GenTb.Text = "";
            EmailTb.Text = "";
            PassTb.Text = "";
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Select The Member To Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from MemberTbl where MId=" + key + ";";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Member Deleted Succesfully");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key=0;
        private void MembersSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(MembersSDGV.SelectedRows[0].Cells[0].Value.ToString());
            NameTb.Text = MembersSDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = MembersSDGV.SelectedRows[0].Cells[2].Value.ToString();
            AgeTb.Text = MembersSDGV.SelectedRows[0].Cells[3].Value.ToString();
            GenTb.Text = MembersSDGV.SelectedRows[0].Cells[4].Value.ToString();
            EmailTb.Text = MembersSDGV.SelectedRows[0].Cells[5].Value.ToString();
            PassTb.Text = MembersSDGV.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == "" || PhoneTb.Text == "" || AgeTb.Text == "" || GenTb.Text == "" || EmailTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update MemberTbl set MName='" + NameTb.Text + "', MPhone='" + PhoneTb.Text + "',MAge='" + AgeTb.Text + "',MGen='" + GenTb.Text + "',MEmail='" + EmailTb.Text + "',MAbonament='" + PassTb.Text + "' where MId='"+key +"';";
                    SqlCommand command = new SqlCommand(query, Con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Member Updated Succesfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
