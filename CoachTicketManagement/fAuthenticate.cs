using CoachTicketManagement.Core;
using CoachTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoachTicketManagement
{
    public partial class fAuthenticate : Form
    {
        List<Account> accounts = AccountService.Instance.GetAccounts();
        List<Employee> employees = EmployeeService.Instance.GetEmployees();
        public fAuthenticate()
        {
            InitializeComponent();
            pictureBoxEyePassword.Image = imageListEye.Images[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int idAccount = AccountService.Instance.LoginGetIDAccount(txtUsername.Text, txtPassword.Text);
            if (idAccount > 0)
            {
                Employee employee = employees.Find(x => x.Id == accounts.Find(a => a.Id == idAccount).IdEmployee);
                this.Hide();
                fManagement f = new fManagement(employee, employees, accounts);
                f.ShowDialog();
                this.Show();
            }
            else MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fAuthenticate_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void pictureBoxEyePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar != '\0')
            {
                txtPassword.PasswordChar = '\0';
                pictureBoxEyePassword.Image = imageListEye.Images[1];
            }    
            else
            {
                txtPassword.PasswordChar = '*';
                pictureBoxEyePassword.Image = imageListEye.Images[0];
            }
        }
    }
}
