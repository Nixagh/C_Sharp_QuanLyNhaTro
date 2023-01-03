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
using RestSharp;
using Newtonsoft.Json;
using System.IO;

namespace GUI.Forms.Host {
    public partial class FromSuaThongTin : Form {
        private DTO.Host host;
        private BUS_Host Bus_Host = new BUS_Host();

        public FromSuaThongTin() {
            InitializeComponent();
        }
        public FromSuaThongTin(DTO.Host host) {
            InitializeComponent();

            this.host = host;
            imageLocation = host.image;

            picImage.ImageLocation = host.image;
            txtname.Text = host.name;
            txtAddress.Text = host.addressDetail;
            txtFaceBook.Text = host.facebook;
            txtPhoneNumber.Text = host.phoneNumber;

            txtHuyen.Text =  host.address.Huyen;
            txtTinh.Text = host.address.Tinh;
            txtXa.Text = host.address.Xa;

            addTinh();
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
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPG files(*.jpg)|*.jpg|PNG files(*.png)|*.png";
                if (dialog.ShowDialog() == DialogResult.OK) {
                    imageLocation = dialog.FileName;
                    picImage.Image = Image.FromFile(dialog.FileName);
                }
            } catch (Exception) {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnDangKy_Click(object sender, EventArgs e) {
            Address saveAddress = new Address(txtTinh.Text, txtHuyen.Text, txtXa.Text);
            if (!string.IsNullOrEmpty(cmbXa.Text))
                saveAddress = new Address(cmbTinh.Text, cmbHuyen.Text, cmbXa.Text);

            string host_ = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string location = Path.Combine(host_, @"Images\Hosts");
            string path = Path.Combine(location, Path.GetFileName(imageLocation));
            string saveImage = Path.Combine(@"Images\Hosts", Path.GetFileName(imageLocation));

            var result = Bus_Host.update(host._id, txtname.Text, saveAddress,
                txtAddress.Text, txtFaceBook.Text, saveImage, txtPhoneNumber.Text);
            if (result != null) {
                File.Copy(imageLocation, path, true);
                MessageBox.Show("Cập nhật thành công", "Infomation.");
                this.Close();
            }

        }
    }
}
