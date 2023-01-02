using _Fragment;
using BUS;
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

namespace GUI.Forms {
    public partial class FormChiTietNhaTro : Form {
        BUS_Host host = new BUS_Host();
        BUS_Motel motel = new BUS_Motel();
        DTO.Host curHost;

        public FormChiTietNhaTro() {
            InitializeComponent();
        }

        public FormChiTietNhaTro(DTO.Host host) {
            InitializeComponent();
            this.curHost = host;
            string host_ = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            pic_Host.ImageLocation = Path.Combine(host_, host.image);

            lblName.Text = host.name;
            lblAddress.Text = host.address.Tinh;
            addMotels();
        }

        private void addMotels() {
            flowLayoutPanel1.Controls.Clear();
            List<Motel> motels = motel.getByHostIdAndStatus(curHost._id);
            foreach (Motel m in motels)
                flowLayoutPanel1.Controls.Add(new Home_Motel(m));
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
