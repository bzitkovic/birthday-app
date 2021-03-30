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
    public partial class BirthdayViewer : Form
    {
        User currentUser;
        public BirthdayViewer(User user)
        {
            InitializeComponent();

            currentUser = user;

            lblWelcome.Text = $"Welcome: {user.Username}";

            RefreshGUI();

            FillComboBox();
        }

        private void FillComboBox()
        {
            List<string> months = new List<string>();

            months.Add("January");
            months.Add("February");
            months.Add("March");
            months.Add("April");
            months.Add("May");
            months.Add("June");
            months.Add("July");
            months.Add("August");
            months.Add("September");
            months.Add("October");
            months.Add("November");
            months.Add("December");
            months.Add("Search all");

            cmbMonth.DataSource = months;
        }

        private void RefreshGUI()
        {
            dgvBirthdays.DataSource = null;
            dgvBirthdays.DataSource = GlobalConfig.Birthday.GetAllBirthdays(currentUser);

            dgvBirthdays.Columns["Id"].Visible = false;
            dgvBirthdays.Columns["User"].Visible = false;
            dgvBirthdays.Columns["User_Id"].Visible = false;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            NewBirthday frm = new NewBirthday(currentUser);

            frm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Birthday birthday = GetSelectedBirthday();

            if (birthday != null)
            {
                NewBirthday frm = new NewBirthday(birthday);

                frm.Show();
            }           
        }

        private Birthday GetSelectedBirthday()
        {
            return (dgvBirthdays.CurrentRow != null ? dgvBirthdays.CurrentRow.DataBoundItem as Birthday : null);
        }

        private void BirthdayViewer_Activated(object sender, EventArgs e)
        {
            RefreshGUI();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Birthday birthday = GetSelectedBirthday();

            if (birthday != null)
            {
                GlobalConfig.Birthday.DeleteBirthday(birthday);

                RefreshGUI();
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = cmbMonth.SelectedItem.ToString();

            dgvBirthdays.DataSource = null;

            dgvBirthdays.DataSource = GlobalConfig.Birthday.FilterBirthdaysByMonth(month);

            if (dgvBirthdays.RowCount != 0)
            {
                dgvBirthdays.Columns["Id"].Visible = false;
                dgvBirthdays.Columns["User"].Visible = false;
                dgvBirthdays.Columns["User_Id"].Visible = false;
            }
            
        }
    }
}
