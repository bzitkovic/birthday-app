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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (CheckUserInput())
            {
                User user = new User();

                user.Username = txtUsername.Text;
                user.Password = txtPasword.Text;

                GlobalConfig.Login.RegisterUser(user);

                Close();
            }
        }

        private bool CheckUserInput()
        {
            bool output = true;

            if (txtUsername.Text == "")
            {
                output = false;
            }

            if (txtPasword.Text == "")
            {
                output = false;
            }

            return output;
        }
    }
}
