using Newtonsoft.Json;
using RestSharp;
using System;
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
using System.Drawing.Imaging;
using System.IO;

namespace GUI.Forms {
    public partial class FormDangKyTro : Form {
        private static FormDangKyTro instance;
        private BUS_Host host = new BUS_Host();

        public static FormDangKyTro GetInstance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new FormDangKyTro();
                }
                instance.BringToFront();
                return instance;
            }
        }
        private FormDangKyTro() {
            InitializeComponent();
            addTinh();
        }

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
            cmbXa.Items.Clear();
            cmbHuyen.Items.Clear();
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
            cmbXa.Items.Clear();
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
        String imageLocation = "";

        private void btnChooseFile_Click(object sender, EventArgs e) {           
            try {            
                openFileDialog1.Filter = "JPG files(*.jpg)|*.jpg|PNG files(*.png)|*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    imageLocation = openFileDialog1.FileName;
                    picImage.Image = Image.FromFile(openFileDialog1.FileName);
                }   
            } catch (Exception) {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e) {
            if(txtname.Text == "") {
                MessageBox.Show("Vui lòng điền Tên nhà trọ.", "Infomation.");
                txtname.Focus();
                return;
            }
            if (cmbTinh.Text == "") {
                MessageBox.Show("Vui lòng chọn Tỉnh.", "Infomation.");
                cmbTinh.Focus();
                return;
            }
            if (cmbHuyen.Text == "") {
                MessageBox.Show("Vui lòng chọn Huyện.", "Infomation.");
                cmbHuyen.Focus();
                return;
            }
            if (cmbXa.Text == "") {
                MessageBox.Show("Vui lòng chọn Xã.", "Infomation.");
                cmbXa.Focus();
                return;
            }
            if (txtPhoneNumber.Text == "") {
                MessageBox.Show("Vui lòng điền Số điện thoại liên hệ.", "Infomation.");
                txtPhoneNumber.Focus();
                return;
            }
            if (imageLocation == "") {
                MessageBox.Show("Vui lòng chọn Ảnh trọ.", "Infomation.");
                return;
            }
            string host_ = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string location = Path.Combine(host_, @"Images\Hosts");
            DirectoryInfo di = Directory.CreateDirectory(location);
            string path = Path.Combine(location, Path.GetFileName(imageLocation));

            string saveImage = Path.Combine(@"Images\Hosts", Path.GetFileName(imageLocation));

            var result = host.insert(new DTO.Host(txtname.Text, saveImage,
                                        new Address(cmbTinh.Text, cmbHuyen.Text, cmbXa.Text),
                                        txtPhoneNumber.Text, txtAddress.Text, txtFaceBook.Text,
                                        BUS_User.UserAuth._id));
            BUS_User user = new BUS_User();
            user.updateRole(BUS_User.UserAuth._id, "Host");
            if (result != null) {
                File.Copy(imageLocation, path, true);
                MessageBox.Show("Đăng ký thành công, Vui lòng logout và đăng nhập lại", "Infomation.");
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
