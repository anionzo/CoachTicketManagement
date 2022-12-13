using CoachTicketManagement.Models;
using CoachTicketManagement.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoachTicketManagement
{
    public partial class fAccountInfo : Form
    {
        private Employee _Employee;
        public fAccountInfo(Employee employee)
        {
            InitializeComponent();
            this._Employee = employee;
        }

        private void btnfAIUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fAccountInfo_Load(object sender, EventArgs e)
        {
            TxtIdAccount.Text = _Employee.IdAccount.ToString();
            TxtIdEmployee.Text = _Employee.Id.ToString();
            TxtName.Text = _Employee.Name;
            ControlHelper.Instance.loadCity(CboCity);
            ControlHelper.Instance.loadDistrict(CboDistrict);
            ControlHelper.Instance.loadWard(CboWard);
            CboWard.SelectedValue = _Employee.IdWard;
            int idDistrict = ADOHelper.Instance.ExecuteScalar("select IDDistrict from tbl_Ward where IDWard = @para_0", new object[] { _Employee.IdWard });
            CboDistrict.SelectedValue = idDistrict;
            int idCity = ADOHelper.Instance.ExecuteScalar("select IDCity from tbl_District where IDDistrict = @para_0", new object[] { idDistrict });
            CboCity.SelectedValue = idCity;
            ControlHelper.Instance.loadTypeEmployee(CboTypeOfEmployee);
            DtpDateOfBirth.Value = _Employee.DateOfBirth;
            ControlHelper.Instance.loadGender(CboGender);
            CboGender.SelectedText = _Employee.Gender;
            TxtIdentityCard.Text = _Employee.IdentityCard;
            TxtPhone.Text = _Employee.Phone;
            TxtEmail.Text = _Employee.Email;
            panelMain.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            panelMain.Enabled = btnSave.Enabled = true;
            CboTypeOfEmployee.Enabled = false;
            TxtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtName.Text) || string.IsNullOrEmpty(TxtIdentityCard.Text) ||
                string.IsNullOrEmpty(TxtPhone.Text) || string.IsNullOrEmpty(TxtEmail.Text))
            {
                MessageBox.Show("Không được bỏ trống thông tin !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
    }
}
