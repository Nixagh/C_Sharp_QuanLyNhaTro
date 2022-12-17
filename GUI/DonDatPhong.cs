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

namespace GUI {
    public partial class DonDatPhong : Form {
        BUS_Booking booking = new BUS_Booking();

        public DonDatPhong() {
            InitializeComponent();
            dgvBooking.DataSource = booking.getAll();
        }

        private void loadBooking(bool status) {
            dgvBooking.DataSource = booking.getByStatus(status);
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbStatus.Text == "Tất Cả")
                dgvBooking.DataSource = booking.getAll();
            else if (cmbStatus.Text == "Đã Trả Phòng")
                loadBooking(true);
            else
                loadBooking(false);
        }
    }
}
