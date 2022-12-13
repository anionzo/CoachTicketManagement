using CoachTicketManagement.Core;
using CoachTicketManagement.Models;
using CoachTicketManagement.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachTicketManagement
{
    public partial class fPayment : Form
    {
        int _IdTrip, _IdEmployee;
        List<Seat> _Seats;


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Sau khi thoát tất cả sẽ reset.\nBạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                    this.Close();
        }


        private void TxtPhone_Leave(object sender, EventArgs e)
        {
            int idBusline = DataService.Instance.GetIDBusLine(_IdTrip);
            if (idBusline == 0)
            {
                MessageBox.Show("Dữ liệu chuyến đi lỗi!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            ControlHelper.Instance.loadCboPickUpPoint(cboPickupPoint, idBusline);
            ControlHelper.Instance.loadCboDropOffPoint(cboDropoffPoint, idBusline);
            if (!Utilities.Instance.CheckPhone(TxtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không đúng định dạng!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TxtPhone.Focus();
                return;
            }
            ControlHelper.Instance.loadGender(CboGender);
            ControlHelper.Instance.loadCity(CboCity);

            List<Client> clients = ClientService.Instance.GetClients();
            Client client = clients.SingleOrDefault(x => x.Phone == TxtPhone.Text);
            if(client != null)
            {
                TxtName.Text = client.Name;
                CboGender.Text = client.Gender;
                TxtIdentityCard.Text = client.IdentityCard;
                TxtEmail.Text = client.Email;
                DtpDateOfBirth.Value = client.DateOfBirth;
                int idward = client.IdWard;
                int iddistrict = DataService.Instance.GetIDDistrict(client.IdWard);
                if(iddistrict == 0)
                {
                    MessageBox.Show("Dữ liệu địa chỉ lỗi!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                int idcity = DataService.Instance.GetIDCity(iddistrict);
                if(idcity == 0)
                {
                    MessageBox.Show("Dữ liệu địa chỉ lỗi!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                CboCity.SelectedValue = idcity;
                CboDistrict.SelectedValue = iddistrict;
                CboWard.SelectedValue = idward;
                cboPickupPoint.Focus();
                return;
            }    
        }
        private bool stringIsNull(TextBox control)
        {
            if(string.IsNullOrEmpty(control.Text))
            {
                MessageBox.Show("Không được bỏ trống !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                control.Focus();
                return true;
            }
            return false;
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (stringIsNull(TxtName))
                return;
            if (stringIsNull(TxtIdentityCard))
                return;
            if (stringIsNull(TxtPhone))
                return;
            if(DateTime.Now.Year - DtpDateOfBirth.Value.Year <= 10)
            {
                MessageBox.Show("Tuổi không đủ !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            } 
            if(cboPickupPoint.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn điểm đón !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (cboDropoffPoint.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn điểm xuống xe !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (CboWard.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn địa chỉ !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            List<Client> clients = ClientService.Instance.GetClients();
            Client client = clients.SingleOrDefault(x => x.Phone == TxtPhone.Text || x.IdentityCard == TxtIdentityCard.Text);
            if(client == null)
            {
                try
                {
                    ADOHelper.Instance.ExecuteNonQuery(@"insert into TBL_CLIENT(NAMECLIENT, DATEOFBIRTHCLIENT, GENDERCLIENT, PHONECLIENT, IDENTITYCARDCLIENT, EMAILCLIENT, IDWARD)
                                                    values (@para_0,@para_1,@para_2,@para_3,@para_4,@para_5,@para_6)", new object[] { TxtName.Text, DtpDateOfBirth.Value, CboGender.SelectedItem.ToString(), TxtPhone.Text, TxtIdentityCard.Text, TxtEmail.Text, (int)CboWard.SelectedValue });

                    clients = ClientService.Instance.GetClients();
                    client = clients.SingleOrDefault(x => x.Phone == TxtPhone.Text || x.IdentityCard == TxtIdentityCard.Text);
                    if(client == null)
                    {
                        MessageBox.Show("Không thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }    
                }
                catch
                {
                    MessageBox.Show("Thông tin bị trùng !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                if(TxtPhone.Text != client.Phone || TxtIdentityCard.Text != client.IdentityCard)
                {
                    MessageBox.Show("Thông tin không khớp !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if(TxtName.Text != client.Name || (int)CboWard.SelectedValue != client.IdWard || CboGender.SelectedItem.ToString() != client.Gender || DtpDateOfBirth.Value != client.DateOfBirth)
                    {
                        DialogResult r = MessageBox.Show("Thông tin có sự thay đổi. Bạn có muốn cập nhật lại dữ liệu?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if(r == DialogResult.Yes)
                        {
                            try
                            {
                                ADOHelper.Instance.ExecuteNonQuery(@"update TBL_CLIENT
                                    set NAMECLIENT = @para_0, DATEOFBIRTHCLIENT = @para_1, GENDERCLIENT = @para_2, PHONECLIENT = @para_3, IDENTITYCARDCLIENT = @para_4, EMAILCLIENT = @para_5, IDWARD = @para_6
                                    where IDCLIENT = @para_7",
                                    new object[] { TxtName.Text, DtpDateOfBirth.Value, CboGender.SelectedItem.ToString(), TxtPhone.Text, TxtIdentityCard.Text, TxtEmail.Text, (int)CboWard.SelectedValue, client.Id });
                            }
                            catch
                            {
                                MessageBox.Show("Thông tin bị trùng !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }    
                    }    
                }
            }

            int idBill = 0;
            int idTicket = 0;
            string result;
            try
            {
                foreach (var item in _Seats)
                {
                    
                    using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString()))
                    {
                        SqlCommand cmd = new SqlCommand(@"declare @idTicket int, @strResult nvarchar(max)
                                exec sp_InsertTicKet @idSeat=@para_0, @idTrip=@para_1, @idPicUpPoint=@para_2, @idDropOffPoint=@para_3, @idTicket=@idTicket output, @strResult=@strResult output
                                select @idTicket as 'IDTICKET', @strResult as 'RESULT'", connection);
                        cmd.Parameters.AddWithValue("@para_0", item.IDSEAT);
                        cmd.Parameters.AddWithValue("@para_1", _IdTrip);
                        cmd.Parameters.AddWithValue("@para_2", (int)cboPickupPoint.SelectedValue);
                        cmd.Parameters.AddWithValue("@para_3", (int)cboDropoffPoint.SelectedValue);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        idTicket = (int)data.Rows[0][0];
                        result = data.Rows[0][1].ToString();
                    }
                    if (idTicket == 0)
                    {
                        MessageBox.Show(result + " của vị trí " + item.SEATPOSITION, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if(idBill == 0)
                    {
                        using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString()))
                        {
                            SqlCommand cmd = new SqlCommand(@"declare @idBill int, @strResult nvarchar(max)
                                                    exec sp_InsertAndGetIdBill @idEmployee = @para_0, @idClient =@para_1, @idBill = @idBill output, @strResult = @strResult output
                                                    select @idBill as 'IDBILL', @strResult as 'RESULT'", connection);
                            cmd.Parameters.AddWithValue("@para_0", _IdEmployee);
                            cmd.Parameters.AddWithValue("@para_1", client.Id);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable data = new DataTable();
                            adapter.Fill(data);
                            idBill = (int)data.Rows[0][0];
                            result = data.Rows[0][1].ToString();
                        }
                        if (idBill == 0)
                        {
                            MessageBox.Show(result, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    } 
                    if(idTicket != 0)
                    {
                        using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString()))
                        {
                            SqlCommand cmd = new SqlCommand(@"declare @strResult nvarchar(max)
                                        exec sp_InsertBillDetails @idBill=@para_0, @idTicket=@para_1, @strResult=@strResult output
                                        select @strResult as 'RESULT'", connection);
                            cmd.Parameters.AddWithValue("@para_0", idBill);
                            cmd.Parameters.AddWithValue("@para_1", idTicket);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable data = new DataTable();
                            adapter.Fill(data);
                            result = data.Rows[0][0].ToString();
                        }
                    }    
                }
                ADOHelper.Instance.ExecuteNonQuery("exec sp_DeteleBill @idBill=@para_0", new object[] { idBill });
                ADOHelper.Instance.ExecuteNonQuery("exec sp_DeteleTicket @idTicket=@para_0", new object[] { idTicket });
                MessageBox.Show("Thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ADOHelper.Instance.ExecuteNonQuery("exec sp_DeteleBill @idBill=@para_0", new object[] { idBill });
                ADOHelper.Instance.ExecuteNonQuery("exec sp_DeteleTicket @idTicket=@para_0", new object[] { idTicket });
            }
        }

        private void TxtIdentityCard_Leave(object sender, EventArgs e)
        {
            if (!Utilities.Instance.CheckIdentityCard(TxtIdentityCard.Text))
            {
                MessageBox.Show("CMND/CCCD không đúng định dạng!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TxtIdentityCard.Focus();
                return;
            }
        }

        private void CboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            if(control.SelectedValue != null)
            {
                ControlHelper.Instance.loadDistrict(CboDistrict, (int)control.SelectedValue);
            }    
        }

        private void CboDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox control = (ComboBox)sender;
            if (control.SelectedValue != null)
            {
                ControlHelper.Instance.loadWard(CboWard, (int)control.SelectedValue);
            }
        }

        public fPayment(int idTrip, int idEmployee, List<Seat> seats)
        {
            InitializeComponent();
            _IdTrip = idTrip;
            _IdEmployee = idEmployee;
            _Seats = seats;
        }
    }
}
