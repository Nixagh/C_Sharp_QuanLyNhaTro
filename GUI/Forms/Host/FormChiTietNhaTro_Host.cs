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
using _Fragment;
using BUS;
using DTO;


namespace GUI.Forms.Host {
    public partial class FormChiTietNhaTro_Host : Form {
        BUS_Host host = new BUS_Host();
        BUS_Motel motel = new BUS_Motel();
        _Host curHost;

        public FormChiTietNhaTro_Host(_Host host) {
            InitializeComponent();
            curHost = host;
            string host_ = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            pic_Host.ImageLocation = Path.Combine(host_, host.image);
            lblName.Text = host.name;
            lblAddress.Text = host.address.Tinh;
            addMotels();
        }

        private void addMotels() {
            fpanelPhongTro.Controls.Clear();
            List<_Motel> motels = motel.getByHostId(curHost._id);
            foreach (_Motel m in motels) {
                Host_Motel hm = new Host_Motel(m);
                hm.B.Click += (s, e) => {
                    ThongTinPhongTro f = new ThongTinPhongTro(m);
                    f.Show();
                };
                fpanelPhongTro.Controls.Add(hm);
            }

        }



        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e) {
            CreateMotel.getInstance(curHost._id).Show();
        }

        private void FormChiTietNhaTro_Host_Activated(object sender, EventArgs e) {
            curHost = host.findByUserId(BUS_User.UserAuth._id);
            lock_Unlock(curHost.isPost);
            addMotels();
        }

        private void btnPost_Click(object sender, EventArgs e) {
            var result = host.changePost(curHost._id, true);
            if (result != null) {
                curHost.isPost = true;

                MessageBox.Show("Đăng Bài Thành Công.", "Infomation.");
            }
            lock_Unlock(curHost.isPost);
        }

        private void btnDisPost_Click(object sender, EventArgs e) {
            var result = host.changePost(curHost._id, false);
            if (result != null) { 
                curHost.isPost = false; 
                MessageBox.Show("Hủy Đăng Bài Thành Công.", "Infomation.");
            }
            lock_Unlock(curHost.isPost);
        }

        private void lock_Unlock(bool status) {
            btnPost.Visible = !status;
            btnDisPost.Visible = status;
        }

        private void btnSua_Click(object sender, EventArgs e) {
            FromSuaThongTin g = new FromSuaThongTin(curHost);
            g.Show();
        }
    }
}
