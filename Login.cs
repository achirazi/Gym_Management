namespace Gym_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            UserTb.Text = "";
            PassTb.Text = "";
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (UserTb.Text == "" || PassTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else if (UserTb.Text == "Admin" && PassTb.Text == "Dabuleni")
            { 
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong User or Password");
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}