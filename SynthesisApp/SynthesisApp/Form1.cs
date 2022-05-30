using LogicLayer;
using DataAccessLayer;
using Entities;


namespace SynthesisApp
{
    public partial class Form1 : Form
    {

        private UsersManager usersManager = new UsersManager(new UsersDB());
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = usersManager.RetrieveUserByCredentials(tbUsername.Text, tbPassword.Text);

            if (user!=null && user.Type == "Admin")
            {
                this.Hide();
                tbUsername.Text = String.Empty;
                tbPassword.Text = String.Empty;
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}