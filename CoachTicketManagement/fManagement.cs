using CoachTicketManagement.Core;
using CoachTicketManagement.Models;
using CoachTicketManagement.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;


namespace CoachTicketManagement
{
    public partial class fManagement : Form
    {
        List<Employee> _employees;
        List<Account> _accounts;
        Employee _curEmployee;

        List<List<PictureBox>> listA = new List<List<PictureBox>>();
        List<List<PictureBox>> listB = new List<List<PictureBox>>();
        public fManagement(Employee cur, List<Employee> employees, List<Account> accounts)
        {
            InitializeComponent();
            this._employees = employees;
            this._accounts = accounts;
            this._curEmployee = cur;
        }

        private void Enable()
        {
            panelSeat.Enabled = btnStartChooseSeat.Enabled = btnPayment.Enabled = false;
        }

        private void AddHeader()
        {
            dataGridViewTrip.Columns.Clear();
            dataGridViewTrip.Columns.Add("IDTRIP", "Mã Chuyến Xe");
            dataGridViewTrip.Columns[0].DataPropertyName = "IDTRIP";
            dataGridViewTrip.Columns.Add("Time", "Thời gian");
            dataGridViewTrip.Columns[1].DataPropertyName = "Time";
            dataGridViewTrip.Columns.Add("NAMEEMPLOYEE", "Tên nhân viên");
            dataGridViewTrip.Columns[2].DataPropertyName = "NAMEEMPLOYEE";
            dataGridViewTrip.Columns.Add("LICENSEPLATE", "Biển số");
            dataGridViewTrip.Columns[3].DataPropertyName = "LICENSEPLATE";
            dataGridViewTrip.Columns.Add("NAMEDRIVER", "Tên tài xế");
            dataGridViewTrip.Columns[4].DataPropertyName = "NAMEDRIVER";
            dataGridViewTrip.Columns.Add("DEPARTUREDAY", "Ngày khởi hành");
            dataGridViewTrip.Columns[5].DataPropertyName = "DEPARTUREDAY";
            dataGridViewTrip.Columns.Add("AMOUNTEMPTYSEAT", "Số ghế trống");
            dataGridViewTrip.Columns[6].DataPropertyName = "AMOUNTEMPTYSEAT";
            dataGridViewTrip.Columns.Add("Price", "Giá vé");
            dataGridViewTrip.Columns[7].DataPropertyName = "Price";

            dataGridViewTrip.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void fManagement_Load(object sender, EventArgs e)
        {
            picBoxEmpty.Image = imageListSeat.Images[0];
            picBoxNo.Image = imageListSeat.Images[1];
            picBoxChoose.Image = imageListSeat.Images[2];


            AddHeader();

            showSeat();
            if (String.Compare(EmployeeService.Instance.CheckPermissionByID(_curEmployee.Id), "Admin", true) == 0)
                ToolStripAdmin.Enabled = true;
            else ToolStripAdmin.Enabled = false;
            //ControlHelper.Instance.loadCboBusLine(cboBusLine);
            cboBusLine.DisplayMember = "BusLine";
            cboBusLine.ValueMember = "IDBUSLINE";
            cboBusLine.DataSource = ADOHelper.Instance.ExecuteReader(@"select IDBUSLINE, DEPARTURESTATION + ' - ' + DESTINATIONSTATION as 'BusLine'
                                                                        from TBL_BUSLINE b
                                                                        where IDBUSLINE IN(select t.IDBUSLINE

                                                                                            from TBL_TRIP t, TBL_TIMEBUSLINE ti

                                                                                            where t.IDTIME = ti.IDTIME and((DEPARTUREDAY > cast(GETDATE() as date)) or(DEPARTUREDAY = cast(GETDATE() as date)

                                                                                            and cast(GETDATE() as time(0)) < ti.STARTTIME)))");
        }
        void loadSeat(int idTrip)
        {
            List<Seat> seats = ADOHelper.Instance.ExecuteReader<Seat>("select * from f_GetSeatByIDTrip(@para_0)", new object[] { idTrip });
            if(seats.Count > 0)
            {
                int rowDownstairs = Utilities.Instance._Downstairs_RowOfSeats, rowUpstairs = Utilities.Instance._Upstairs_RowOfSeats;
                for (int i = 2; i < rowDownstairs - 1; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (seats.SingleOrDefault(x => x.SEATPOSITION == listA[i][j].Name) != null)
                        {
                            listA[i][j].Image = imageListSeat.Images[Utilities.Instance._KhongBan];
                            listA[i][j].Tag = Utilities.Instance._KhongBan;
                        }
                        else
                        {
                            listA[i][j].Image = imageListSeat.Images[Utilities.Instance._Trong];
                            listA[i][j].Tag = Utilities.Instance._Trong;
                        }
                    }
                }
                for (int i = 0; i < rowUpstairs; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (seats.SingleOrDefault(x => x.SEATPOSITION == listB[i][j].Name) != null)
                        {
                            listB[i][j].Image = imageListSeat.Images[Utilities.Instance._KhongBan];
                            listB[i][j].Tag = Utilities.Instance._KhongBan;
                        }
                        else
                        {
                            listB[i][j].Image = imageListSeat.Images[Utilities.Instance._Trong];
                            listB[i][j].Tag = Utilities.Instance._Trong;
                        }
                    }
                }
            }
            else
            {
                ResetSeats();
            }
        }

        void showSeat()
        {
            createSeat();
            panelSeat.Enabled = false;
        }

        void createSeat()
        {
            int width = Utilities.Instance._WidthSeat, height = Utilities.Instance._HeightSeat;
            int rowDownstairs = Utilities.Instance._Downstairs_RowOfSeats, rowUpstairs = Utilities.Instance._Upstairs_RowOfSeats;
            for (int i = 0; i < rowDownstairs; i++)
            {
                listA.Add(new List<PictureBox>());
                for (int j = 0; j < 3; j++)
                {
                    PictureBox pic = new PictureBox();
                    if (i < 2 || i == rowDownstairs - 1)
                    {
                        pic.Image = imageListSeat.Images[Utilities.Instance._KhongBan];
                        pic.Tag = Utilities.Instance._KhongBan;
                    }
                    else
                    {
                        pic.Image = imageListSeat.Images[Utilities.Instance._Trong];
                        pic.Tag = Utilities.Instance._Trong;
                    }
                    pic.Name = "A" + ((i * 3) + j + 1).ToString();
                    pic.Size = new Size(width, height);
                    flowLayoutPanelA.Controls.Add(pic);
                    pic.Click += Pic_Click;
                    listA[i].Add(pic);
                }
            }
            for (int i = 0; i < rowUpstairs; i++)
            {
                listB.Add(new List<PictureBox>());
                for (int j = 0; j < 3; j++)
                {
                    PictureBox pic = new PictureBox();
                    pic.Image = imageListSeat.Images[Utilities.Instance._Trong];
                    pic.Tag = Utilities.Instance._Trong;
                    pic.Name = "B" + ((i * 3) + j + 1).ToString();
                    pic.Size = new Size(width, height);
                    flowLayoutPanelB.Controls.Add(pic);
                    pic.Click += Pic_Click;
                    listB[i].Add(pic);
                }
            }
        }
        private void ResetSeats()
        {
            int rowDownstairs = Utilities.Instance._Downstairs_RowOfSeats, rowUpstairs = Utilities.Instance._Upstairs_RowOfSeats;
            for (int i = 0; i < rowDownstairs; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PictureBox pic = listA[i][j];
                    if (i < 2 || i == rowDownstairs - 1)
                    {
                        pic.Image = imageListSeat.Images[Utilities.Instance._KhongBan];
                        pic.Tag = Utilities.Instance._KhongBan;
                    }
                    else
                    {
                        pic.Image = imageListSeat.Images[Utilities.Instance._Trong];
                        pic.Tag = Utilities.Instance._Trong;
                    }
                }
            }
            for (int i = 0; i < rowUpstairs; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PictureBox pic = listB[i][j];
                    pic.Image = imageListSeat.Images[Utilities.Instance._Trong];
                    pic.Tag = Utilities.Instance._Trong;
                }
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if ((int)pic.Tag == Utilities.Instance._KhongBan)
                MessageBox.Show("Vị trí này không được chọn, vui lòng chọn vị trí khác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if ((int)pic.Tag == Utilities.Instance._Trong)
            {
                pic.Image = imageListSeat.Images[Utilities.Instance._DangChon];
                pic.Tag = Utilities.Instance._DangChon;
                lbResultChooseSeat.Text += pic.Name + " ";
            }    
            else if ((int)pic.Tag == Utilities.Instance._DangChon)
            {
                pic.Image = imageListSeat.Images[Utilities.Instance._Trong];
                pic.Tag = Utilities.Instance._Trong;
                string result = lbResultChooseSeat.Text;
                if(result.Contains(pic.Name))
                {
                    result = result.Replace(pic.Name + " ", "");
                }
                lbResultChooseSeat.Text = result;
            }    
        }

        private void ToolStripLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripInfoAccount_Click(object sender, EventArgs e)
        {
            fAccountInfo accountInfo = new fAccountInfo(_curEmployee);
            accountInfo.ShowDialog();
        }

        private void ToolStripAdmin_Click(object sender, EventArgs e)
        {
            fAdmin admin = new fAdmin(this._curEmployee);
            this.Hide();
            admin.ShowDialog();
            this.Show();
        }

        private void btnFindTrip_Click(object sender, EventArgs e)
        {
            if(cboBusLine.SelectedItem == null)
            {
                MessageBox.Show("Hiện tại hệ thống chưa có chuyến đi phù hợp vào thời gian này. Xin lỗi vì sự cố đã xảy ra !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }    
            if (dateTimePickerChoose.Value >= DateTime.Now.Date)
            {
                DataTable data = ADOHelper.Instance.ExecuteReader("select * from f_GetTripByIDBusLineDepartureday(@para_0,@para_1)", new object[] { cboBusLine.SelectedValue, dateTimePickerChoose.Value });
                dataGridViewTrip.DataSource = data;
                if(data.Rows.Count == 0)
                    MessageBox.Show("Hiện tại hệ thống chưa có chuyến đi phù hợp vào thời gian này. Xin lỗi vì sự cố đã xảy ra !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }    
            else MessageBox.Show("Không tìm thấy chuyến đi phù hợp !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            dataGridViewTrip.ClearSelection();    
        }

        private void btnStartChooseSeat_Click(object sender, EventArgs e)
        {
            panelSeat.Enabled = btnPayment.Enabled = true;
        }

        private void dataGridViewTrip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idTrip;
                if(int.TryParse(dataGridViewTrip.SelectedCells[0].Value.ToString(), out idTrip))
                {
                    loadSeat(idTrip);
                    btnStartChooseSeat.Enabled = true;
                    lbResultChooseSeat.Text = "Số ghế: ";
                }
            }
        }

        private void cboBusLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enable();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            List<Seat> seatsLoad = ADOHelper.Instance.ExecuteReader<Seat>("select * from TBL_SEAT");
            List<Seat> seats = new List<Seat>();
            foreach (List< PictureBox> item in listA)
            {
                foreach (var pic in item)
                {
                    if((int)pic.Tag == Utilities.Instance._DangChon)
                    {
                        seats.Add(seatsLoad.SingleOrDefault(x => x.SEATPOSITION == pic.Name));
                    }    
                }
            }
            foreach (List<PictureBox> item in listB)
            {
                foreach (var pic in item)
                {
                    if ((int)pic.Tag == Utilities.Instance._DangChon)
                    {
                        seats.Add(seatsLoad.SingleOrDefault(x => x.SEATPOSITION == pic.Name));
                    }
                }
            }

            if(seats.Count <= 0)
            {
                MessageBox.Show("Hiện tại chưa chọn vị trí.\nKhông thể thanh toán !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (!string.IsNullOrEmpty(dataGridViewTrip.SelectedCells[0].FormattedValue.ToString()))
                {
                    int idTrip, idEmployee;
                    bool ktIdTrip = int.TryParse(dataGridViewTrip.SelectedCells[0].Value.ToString(), out idTrip);
                    idEmployee = _curEmployee.Id;
                    if(!ktIdTrip)
                    {
                        MessageBox.Show("Vui lòng chọn chuyến xe !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }    
                    fPayment f = new fPayment(idTrip, idEmployee, seats);
                    f.ShowDialog();
                    ResetSeats();
                    dataGridViewTrip.DataSource = null;
                    lbResultChooseSeat.Text = "Số ghế: ";
                    AddHeader();
                    Enable();
                }
            }
        }

    }
}
