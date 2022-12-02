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

namespace _Fragment {
    public partial class Home_Host : UserControl {
        public _Host host { get; set; }
        private Button button;

        public Button B {
            get {
                return button;
            }
            set {
                button = value;
                btnXemChiTiet = button;
            }
        }

        public Home_Host() {
            InitializeComponent();
            button = btnXemChiTiet;
        }
        public Home_Host(_Host host) {
            InitializeComponent();
            this.host = host;
            button = btnXemChiTiet;
            pic_Host.ImageLocation = this.host.image;
            lblName.Text = this.host.name;
            lblAddress.Text = this.host.address.Tinh;
        }
        private void button1_Click(object sender, EventArgs e) {
        }
    }
}
