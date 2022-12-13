
namespace CoachTicketManagement
{
    partial class fManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fManagement));
            this.lbResultChooseSeat = new System.Windows.Forms.Label();
            this.picBoxEmpty = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picBoxNo = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picBoxChoose = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanelA = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelB = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelSeat = new System.Windows.Forms.Panel();
            this.btnStartChooseSeat = new System.Windows.Forms.Button();
            this.imageListSeat = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewTrip = new System.Windows.Forms.DataGridView();
            this.ToolStripAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripInfoAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripManagement = new System.Windows.Forms.MenuStrip();
            this.cboBusLine = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerChoose = new System.Windows.Forms.DateTimePicker();
            this.btnFindTrip = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxChoose)).BeginInit();
            this.panelSeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrip)).BeginInit();
            this.menuStripManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbResultChooseSeat
            // 
            this.lbResultChooseSeat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lbResultChooseSeat.Location = new System.Drawing.Point(789, 718);
            this.lbResultChooseSeat.Name = "lbResultChooseSeat";
            this.lbResultChooseSeat.Size = new System.Drawing.Size(737, 69);
            this.lbResultChooseSeat.TabIndex = 15;
            this.lbResultChooseSeat.Text = "Số ghế: ";
            // 
            // picBoxEmpty
            // 
            this.picBoxEmpty.Location = new System.Drawing.Point(28, 9);
            this.picBoxEmpty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxEmpty.Name = "picBoxEmpty";
            this.picBoxEmpty.Size = new System.Drawing.Size(45, 46);
            this.picBoxEmpty.TabIndex = 21;
            this.picBoxEmpty.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "Còn trống";
            // 
            // picBoxNo
            // 
            this.picBoxNo.Location = new System.Drawing.Point(188, 9);
            this.picBoxNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxNo.Name = "picBoxNo";
            this.picBoxNo.Size = new System.Drawing.Size(45, 46);
            this.picBoxNo.TabIndex = 20;
            this.picBoxNo.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Không bán";
            // 
            // picBoxChoose
            // 
            this.picBoxChoose.Location = new System.Drawing.Point(352, 9);
            this.picBoxChoose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxChoose.Name = "picBoxChoose";
            this.picBoxChoose.Size = new System.Drawing.Size(45, 46);
            this.picBoxChoose.TabIndex = 19;
            this.picBoxChoose.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(404, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 23);
            this.label6.TabIndex = 22;
            this.label6.Text = "Đang chọn";
            // 
            // flowLayoutPanelA
            // 
            this.flowLayoutPanelA.AutoScroll = true;
            this.flowLayoutPanelA.Location = new System.Drawing.Point(41, 110);
            this.flowLayoutPanelA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelA.Name = "flowLayoutPanelA";
            this.flowLayoutPanelA.Size = new System.Drawing.Size(180, 440);
            this.flowLayoutPanelA.TabIndex = 6;
            // 
            // flowLayoutPanelB
            // 
            this.flowLayoutPanelB.AutoScroll = true;
            this.flowLayoutPanelB.Location = new System.Drawing.Point(306, 110);
            this.flowLayoutPanelB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelB.Name = "flowLayoutPanelB";
            this.flowLayoutPanelB.Size = new System.Drawing.Size(180, 440);
            this.flowLayoutPanelB.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tầng dưới";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(340, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 23);
            this.label8.TabIndex = 27;
            this.label8.Text = "Tầng trên";
            // 
            // panelSeat
            // 
            this.panelSeat.Controls.Add(this.label8);
            this.panelSeat.Controls.Add(this.label7);
            this.panelSeat.Controls.Add(this.flowLayoutPanelB);
            this.panelSeat.Controls.Add(this.flowLayoutPanelA);
            this.panelSeat.Controls.Add(this.label6);
            this.panelSeat.Controls.Add(this.picBoxChoose);
            this.panelSeat.Controls.Add(this.label5);
            this.panelSeat.Controls.Add(this.picBoxNo);
            this.panelSeat.Controls.Add(this.label4);
            this.panelSeat.Controls.Add(this.picBoxEmpty);
            this.panelSeat.Location = new System.Drawing.Point(787, 141);
            this.panelSeat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSeat.Name = "panelSeat";
            this.panelSeat.Size = new System.Drawing.Size(522, 560);
            this.panelSeat.TabIndex = 14;
            // 
            // btnStartChooseSeat
            // 
            this.btnStartChooseSeat.AutoSize = true;
            this.btnStartChooseSeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.btnStartChooseSeat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartChooseSeat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStartChooseSeat.ForeColor = System.Drawing.Color.White;
            this.btnStartChooseSeat.Location = new System.Drawing.Point(1313, 141);
            this.btnStartChooseSeat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartChooseSeat.Name = "btnStartChooseSeat";
            this.btnStartChooseSeat.Size = new System.Drawing.Size(213, 58);
            this.btnStartChooseSeat.TabIndex = 5;
            this.btnStartChooseSeat.Text = "Bắt đầu chọn ghế";
            this.btnStartChooseSeat.UseVisualStyleBackColor = false;
            this.btnStartChooseSeat.Click += new System.EventHandler(this.btnStartChooseSeat_Click);
            // 
            // imageListSeat
            // 
            this.imageListSeat.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSeat.ImageStream")));
            this.imageListSeat.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSeat.Images.SetKeyName(0, "Trong.png");
            this.imageListSeat.Images.SetKeyName(1, "Co.png");
            this.imageListSeat.Images.SetKeyName(2, "DangChon.png");
            // 
            // dataGridViewTrip
            // 
            this.dataGridViewTrip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewTrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrip.Location = new System.Drawing.Point(8, 141);
            this.dataGridViewTrip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewTrip.Name = "dataGridViewTrip";
            this.dataGridViewTrip.ReadOnly = true;
            this.dataGridViewTrip.RowHeadersWidth = 51;
            this.dataGridViewTrip.RowTemplate.Height = 29;
            this.dataGridViewTrip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTrip.Size = new System.Drawing.Size(774, 646);
            this.dataGridViewTrip.TabIndex = 4;
            this.dataGridViewTrip.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTrip_CellClick);
            // 
            // ToolStripAdmin
            // 
            this.ToolStripAdmin.Name = "ToolStripAdmin";
            this.ToolStripAdmin.Size = new System.Drawing.Size(68, 24);
            this.ToolStripAdmin.Text = "Admin";
            this.ToolStripAdmin.Click += new System.EventHandler(this.ToolStripAdmin_Click);
            // 
            // ToolStripAccount
            // 
            this.ToolStripAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripInfoAccount,
            this.ToolStripLogOut});
            this.ToolStripAccount.Name = "ToolStripAccount";
            this.ToolStripAccount.Size = new System.Drawing.Size(89, 24);
            this.ToolStripAccount.Text = "Tài khoản";
            // 
            // ToolStripInfoAccount
            // 
            this.ToolStripInfoAccount.Name = "ToolStripInfoAccount";
            this.ToolStripInfoAccount.Size = new System.Drawing.Size(226, 26);
            this.ToolStripInfoAccount.Text = "Thông tin tài khoản";
            this.ToolStripInfoAccount.Click += new System.EventHandler(this.ToolStripInfoAccount_Click);
            // 
            // ToolStripLogOut
            // 
            this.ToolStripLogOut.Name = "ToolStripLogOut";
            this.ToolStripLogOut.Size = new System.Drawing.Size(226, 26);
            this.ToolStripLogOut.Text = "Đăng xuất";
            this.ToolStripLogOut.Click += new System.EventHandler(this.ToolStripLogOut_Click);
            // 
            // menuStripManagement
            // 
            this.menuStripManagement.BackColor = System.Drawing.Color.DarkGray;
            this.menuStripManagement.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.menuStripManagement.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripAdmin,
            this.ToolStripAccount});
            this.menuStripManagement.Location = new System.Drawing.Point(0, 0);
            this.menuStripManagement.Name = "menuStripManagement";
            this.menuStripManagement.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStripManagement.Size = new System.Drawing.Size(1605, 28);
            this.menuStripManagement.TabIndex = 0;
            this.menuStripManagement.Text = "menuStrip1";
            // 
            // cboBusLine
            // 
            this.cboBusLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusLine.FormattingEnabled = true;
            this.cboBusLine.Location = new System.Drawing.Point(250, 84);
            this.cboBusLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboBusLine.Name = "cboBusLine";
            this.cboBusLine.Size = new System.Drawing.Size(426, 31);
            this.cboBusLine.TabIndex = 0;
            this.cboBusLine.SelectedIndexChanged += new System.EventHandler(this.cboBusLine_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tuyến";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(759, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chọn ngày";
            // 
            // dateTimePickerChoose
            // 
            this.dateTimePickerChoose.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerChoose.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerChoose.Location = new System.Drawing.Point(793, 82);
            this.dateTimePickerChoose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerChoose.Name = "dateTimePickerChoose";
            this.dateTimePickerChoose.Size = new System.Drawing.Size(243, 30);
            this.dateTimePickerChoose.TabIndex = 1;
            // 
            // btnFindTrip
            // 
            this.btnFindTrip.AutoSize = true;
            this.btnFindTrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.btnFindTrip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindTrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFindTrip.ForeColor = System.Drawing.Color.White;
            this.btnFindTrip.Location = new System.Drawing.Point(1114, 68);
            this.btnFindTrip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFindTrip.Name = "btnFindTrip";
            this.btnFindTrip.Size = new System.Drawing.Size(168, 58);
            this.btnFindTrip.TabIndex = 3;
            this.btnFindTrip.Text = "Tìm chuyến";
            this.btnFindTrip.UseVisualStyleBackColor = false;
            this.btnFindTrip.Click += new System.EventHandler(this.btnFindTrip_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.AutoSize = true;
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(92)))), ((int)(((byte)(101)))));
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Location = new System.Drawing.Point(1313, 215);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(213, 58);
            this.btnPayment.TabIndex = 5;
            this.btnPayment.Text = "Thanh toán";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // fManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1605, 801);
            this.Controls.Add(this.lbResultChooseSeat);
            this.Controls.Add(this.panelSeat);
            this.Controls.Add(this.dataGridViewTrip);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnStartChooseSeat);
            this.Controls.Add(this.btnFindTrip);
            this.Controls.Add(this.dateTimePickerChoose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboBusLine);
            this.Controls.Add(this.menuStripManagement);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripManagement;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán vé";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxChoose)).EndInit();
            this.panelSeat.ResumeLayout(false);
            this.panelSeat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrip)).EndInit();
            this.menuStripManagement.ResumeLayout(false);
            this.menuStripManagement.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbResultChooseSeat;
        private System.Windows.Forms.PictureBox picBoxEmpty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBoxNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picBoxChoose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelA;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelSeat;
        private System.Windows.Forms.Button btnStartChooseSeat;
        private System.Windows.Forms.ImageList imageListSeat;
        private System.Windows.Forms.DataGridView dataGridViewTrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem ToolStripAccount;
        private System.Windows.Forms.ToolStripMenuItem ToolStripInfoAccount;
        private System.Windows.Forms.ToolStripMenuItem ToolStripLogOut;
        private System.Windows.Forms.MenuStrip menuStripManagement;
        private System.Windows.Forms.ComboBox cboBusLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerChoose;
        private System.Windows.Forms.Button btnFindTrip;
        private System.Windows.Forms.Button btnPayment;
    }
}