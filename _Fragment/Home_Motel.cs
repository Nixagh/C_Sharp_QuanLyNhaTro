using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Fragment {
    public partial class Home_Motel : UserControl {
        private _Motel motel;
        public Home_Motel() {
            InitializeComponent();
        }
        public Home_Motel(_Motel motel) {
            InitializeComponent();
            this.motel = motel;
            string host_ = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            picMotel.ImageLocation = Path.Combine(host_, motel.image);
            lblName.Text = motel.name;
            lblLoaiPhong.Text = motel.type;
            lblDienTich.Text = motel.area;
            lblGia.Text = motel.price;
        }
    }
}
