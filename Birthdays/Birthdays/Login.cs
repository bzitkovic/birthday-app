using BirthdayLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Birthdays
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register frm = new Register();

            frm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();

            user.Username = txtUsername.Text;
            user.Password = txtPasword.Text;

            user = GlobalConfig.Login.LoginUser(user);

            if (user != null)
            {
                BirthdayViewer frm = new BirthdayViewer(user);

                Hide();

                frm.Show();
            }
        }
    }
}
