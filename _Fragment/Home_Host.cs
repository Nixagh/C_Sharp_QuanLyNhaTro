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
    public partial class Home_Host : UserControl {
        public _Host host { get; set; }

        public Button B {
            get {
                return btnXemChiTiet;
            }
            set {
                btnXemChiTiet = value;
            }
        }

        public Home_Host() {
            InitializeComponent();
        }
        public Home_Host(_Host host) {
            InitializeComponent();
            this.host = host;
            string host_ = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            pic_Host.ImageLocation = Path.Combine(host_, host.image);
            lblName.Text = this.host.name;
            lblAddress.Text = this.host.address.Tinh;
        }
    }
}
