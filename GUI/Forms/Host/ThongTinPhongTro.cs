using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI.Forms.Host {
    public partial class ThongTinPhongTro : Form {
        private static ThongTinPhongTro _instance;
        private _Motel curMotel;
        BUS_Booking booking = new BUS_Booking();
        BUS_Motel motel = new BUS_Motel();

        public static ThongTinPhongTro getInstance {
                get {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new ThongTinPhongTro();
                return _instance;
                }
        }

        public ThongTinPhongTro() {
            InitializeComponent();
        }
        public ThongTinPhongTro(_Motel m) {
            InitializeComponent();
            grName.Text = m.name;
            curMotel = m;
            _Booking result = booking.getByMotel_IdAndStatus(m._id, false);
            check(result);
        }

        private void check(_Booking result) {
            // tìm xem có đơn đặt trong data không
            if (result != null) {
                btnSave.Visible = false;
                btnTraPhong.Visible = true;
                txtName.Text = result.customerName;
                txtSoDienThoai.Text = result.sodienthoai;
                dtpStart.Text = result.startDate;
                dtpEnd.Text = result.endDate;
            }
            else {
                btnSave.Visible = true;
                btnTraPhong.Visible = false;
            }

        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string name = txtName.Text;
            string sdt = txtSoDienThoai.Text;

            string start = dtpStart.Text;
            string end = dtpEnd.Text;

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sdt)) {
                MessageBox.Show("Vui lòng điền thông tin", "Informations.");
                return;
            }

            //lưu đơn
            Task result = booking.save(new _Booking(name, sdt,curMotel.name, curMotel._id, false, start, end, ""));
            motel.updateStatus(curMotel._id);
            MessageBox.Show("Lưu Đơn Thành Công.", "Informations");
            this.Close();
        }

        private void dtpEnd_Enter(object sender, EventArgs e) {
            if (dtpEnd.Value < dtpStart.Value) {
                MessageBox.Show("Vui lòng chọn lại ngày đi.", "Warning");
                dtpEnd.Value = dtpStart.Value.AddDays(1);
            }
        }

        private void btnTraPhong_Click(object sender, EventArgs e) {
            _Booking result = booking.getByMotel_IdAndStatus(curMotel._id, false);
            Task update = booking.updateStatus(result._id);
            if(Task.CompletedTask != null) { 
                MessageBox.Show("Trả Phòng Thành Công", "informations.");
                this.Close();
            } else
                MessageBox.Show("Trả Phòng Thất Bại", "informations.");
        }
    }
    }
