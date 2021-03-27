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
    public partial class NewBirthday : Form
    {
        User currentUser;
        Birthday currentBirthday;
        public NewBirthday(User user)
        {
            InitializeComponent();

            currentUser = user;
        }

        public NewBirthday(Birthday birthday)
        {
            InitializeComponent();

            currentBirthday = birthday;

            Text = "Update birthday"; 

            FillFormWithSelectedBirthday();
        }

        private void FillFormWithSelectedBirthday()
        {
            btnCreateBirthday.Text = "Update";

            txtName.Text = currentBirthday.Name;
            txtSurname.Text = currentBirthday.Surname;
            dtpBirthDay.Value = currentBirthday.Date_Of_Birthday;
            rTxtRemark.Text = currentBirthday.Remark;
        }

        private void btnCreateBirthday_Click(object sender, EventArgs e)
        {
            if (btnCreateBirthday.Text == "Create")
            {
                if (ChekUserInput())
                {
                    Birthday birthday = new Birthday();

                    birthday.Name = txtName.Text;
                    birthday.Surname = txtSurname.Text;
                    birthday.Date_Of_Birthday = dtpBirthDay.Value;
                    birthday.Remark = rTxtRemark.Text;
                    birthday.User_Id = currentUser.Id;

                    GlobalConfig.Birthday.CreateNewBirthday(birthday);

                    Close();
                }
            }
            else 
            {
                if (ChekUserInput())
                {                  
                    currentBirthday.Name = txtName.Text;
                    currentBirthday.Surname = txtSurname.Text;
                    currentBirthday.Date_Of_Birthday = dtpBirthDay.Value;
                    currentBirthday.Remark = rTxtRemark.Text;

                    GlobalConfig.Birthday.UpdateBirthday(currentBirthday);

                    Close();
                }
            }           
        }

        private bool ChekUserInput()
        {
            bool output = true;

            if (txtName.Text == "")
            {
                output = false;
            }

            if (txtSurname.Text == "")
            {
                output = false;
            }

            return output;
        }
    }
}
