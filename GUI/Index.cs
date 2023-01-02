using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using FontAwesome.Sharp;
using GUI.Forms;
using RestSharp;
using Newtonsoft.Json;
using DTO;
using _Fragment;
using GUI.Forms.Host;
using System.IO;

namespace GUI {
    public partial class Index : Form {

        private BUS_Host host = new BUS_Host();
        public Index() {
            InitializeComponent();
            lock_Unlock(BUS_User.isLogin);
            addTinh();
            loadHostItems();
            
        }
        //add address into combobox
        dynamic json;
        dynamic Tinh;
        dynamic Huyen;

        private void addTinh() {
            var client = new RestClient("https://raw.githubusercontent.com/kenzouno1/DiaGioiHanhChinhVN/master/data.json");
            var request = new RestRequest(Method.GET);

            var aqq = client.Execute(request).Content;
            json = JsonConvert.DeserializeObject(aqq);
            foreach (var doc in json) {
                cmbTinh.Items.Add(doc["Name"].ToString());
            }
        }

        private void cmbTinh_SelectedValueChanged(object sender, EventArgs e) {
            foreach (var doc in json) {
                if (doc["Name"].ToString() == cmbTinh.Text) {
                    Tinh = doc;
                    break;
                }
            }
            foreach (var doc in Tinh["Districts"]) {
                cmbHuyen.Items.Add(doc["Name"].ToString());
            }
        }

        private void cmbHuyen_SelectedValueChanged(object sender, EventArgs e) {
            foreach (var doc in Tinh["Districts"]) {
                if (doc["Name"].ToString() == cmbHuyen.Text) {
                    Huyen = doc;
                    break;
                }
            }
            foreach (var doc in Huyen["Wards"]) {
                cmbXa.Items.Add(doc["Name"].ToString());
            }
        }

        private void loadHostItems() {
            fPanelHome.Controls.Clear();
            List<Host> hosts = host.getAllByPost();
            foreach (Host h in hosts) {
                Home_Host hh = new Home_Host(h);
                    hh.B.Click += (s, e) => {
                        FormChiTietNhaTro f = new FormChiTietNhaTro(h);
                        f.Show();
                    };
                fPanelHome.Controls.Add(hh);
            }
        }

      
        private void btnHome_Click(object sender, EventArgs e) {
        }

        private void btnDangKyTro_Click(object sender, EventArgs e) {
            if(BUS_User.UserAuth == null) {
                GUI_Login.GetInstance.Show();
            }
            else FormDangKyTro.GetInstance.Show();
        }

        //Close-Maximize-Minimize
        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        private void btnMaximize_Click(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Normal) {
                WindowState = FormWindowState.Maximized;
                btnMaximize.IconChar = IconChar.Minimize;
            }
            else {
                WindowState = FormWindowState.Normal;
                btnMaximize.IconChar = IconChar.Maximize;
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }
       
        private void btnClose_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            GUI_Login.GetInstance.Show();
        }

        private void lock_Unlock(bool isLogin) {
            btnLogout.Visible = isLogin;

            if (BUS_User.UserAuth != null) {
                if (BUS_User.UserAuth.Role.Equals("Host")) {
                    panelHost.Visible = isLogin;
                    btnDangKyTro.Visible = !isLogin;
                }
            }
            else { 
                panelHost.Visible = isLogin;
                btnDangKyTro.Visible = !isLogin;
            }
        }

        private void Index_Activated(object sender, EventArgs e) {
            loadHostItems();
            lock_Unlock(BUS_User.isLogin);
            if (BUS_User.UserAuth != null) {
                btnLogin.Text = BUS_User.UserAuth.name;
                btnLogin.Click -= btnLogin_Click;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            BUS_User.isLogin = false;
            BUS_User.UserAuth = null;
            lblTitleChildForm.Text = "Home";
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            lock_Unlock(BUS_User.isLogin);
        }

        private void home_Host1_Click(object sender, EventArgs e) {
            FormChiTietNhaTro f = new FormChiTietNhaTro();
            f.Show();
        }

        private void btnQuanLyTro_Click(object sender, EventArgs e) {

        }

        private void btnQuanLyTro_Click_1(object sender, EventArgs e) {
            Host result = host.findByUserId(BUS_User.UserAuth._id);
            FormChiTietNhaTro_Host f = new FormChiTietNhaTro_Host(result);
            f.Show();
        }

        private void btnDonDatPhong_Click(object sender, EventArgs e) {
            DonDatPhong f = new DonDatPhong();
            f.Show();
        }

        private void loadHomeItemsWithSearch(Address address, String key) {
            fPanelHome.Controls.Clear();
            List<Host> hosts = new List<Host>();
            if (address != null)
                hosts = host.getByPostAndAddress(address);
            if (!string.IsNullOrEmpty(key))
                hosts = host.getByPostAndSearch(key);

            foreach (Host h in hosts) {
                    Home_Host hh = new Home_Host(h);
                    hh.B.Click += (s, e) => {
                        FormChiTietNhaTro f = new FormChiTietNhaTro(h);
                        f.Show();
                    };
                    fPanelHome.Controls.Add(hh);
            }
        }

        private void btnFiltersAddress_Click(object sender, EventArgs e) {
            loadHomeItemsWithSearch(new Address(cmbTinh.Text, cmbHuyen.Text, cmbXa.Text), "");    
        }

        private void btnFind_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtSearch.Text)) 
                loadHostItems();
            else
                loadHomeItemsWithSearch(null, txtSearch.Text);
        }
    }
}
