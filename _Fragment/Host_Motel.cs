﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace _Fragment {
    public partial class Host_Motel : UserControl {
        BUS_Motel Bmotel = new BUS_Motel();
        private _Motel motel;
        public Host_Motel() {
            InitializeComponent();
        }

        public Host_Motel(_Motel motel) {
            InitializeComponent();
            this.motel = motel;

            picMotel.ImageLocation = motel.image;
            lblName.Text = motel.name;
            lblLoaiPhong.Text = motel.type;
            lblStatus.Text = motel.status;
            lblDienTich.Text = motel.area;
            lblGia.Text = motel.price;
        }

        private void btnXoa_Click(object sender, EventArgs e) {
            var result = Bmotel.delete(motel._id);
            if(result != null) {
                MessageBox.Show("Xóa Thành Công.", "Infomation.");
            }
        }
    }
}