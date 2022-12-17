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
using BUS;
using DTO;
using MongoDB.Bson;

namespace GUI.Forms.Host {
    public partial class CreateMotel : Form {
        private static CreateMotel _instance;
        private BUS_Motel motel = new BUS.BUS_Motel();
        private static ObjectId hostId;
        string imageLocation;

        public static CreateMotel getInstance(ObjectId id) {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new CreateMotel();
                _instance.BringToFront();
                hostId = id;
                return _instance;
        }


        private CreateMotel() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            string host_ = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string location = Path.Combine(host_, @"Images\Motels");
            DirectoryInfo di = Directory.CreateDirectory(location);
            string path = Path.Combine(location, Path.GetFileName(imageLocation));

            string saveImage = Path.Combine(@"Images\Motels", Path.GetFileName(imageLocation));

            var result = motel.insert(new _Motel(txtName.Text, cmbLoaiPhong.Text, txtDienTich.Text, 
                                        txtGia.Text, txtGiaDien.Text, txtGiaNuoc.Text, saveImage, hostId));

            if(result != null) {
                File.Copy(imageLocation, path, true);
                MessageBox.Show("Tạo Phòng thành công", "Infomation.");
                this.Close();
            }

        }

        private void btnChooseFile_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPG files(*.jpg)|*.jpg|PNG files(*.png)|*.png";
                if (dialog.ShowDialog() == DialogResult.OK) {
                    imageLocation = dialog.FileName;
                    picMotel.Image = Image.FromFile(dialog.FileName);
                }
            } catch (Exception) {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
