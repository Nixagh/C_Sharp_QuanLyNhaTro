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

namespace GUI {
    public partial class Index : Form {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private BUS_Host host;
        //Constructor
        public Index() {
            InitializeComponent();
            host = new BUS_Host();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            lock_Unlock(BUS_User.isLogin);
            btnMaximize.Visible = false;
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
            List<_Host> hosts = host.getAllByPost();
            foreach (_Host h in hosts) {
                Home_Host hh = new Home_Host(h);
                    hh.B.Click += (s, e) => {
                        FormChiTietNhaTro f = new FormChiTietNhaTro(h);
                        f.Show();
                    };
                fPanelHome.Controls.Add(hh);
            }
        }

        //Structs
        private struct RGBColors {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color) {
            if (senderBtn != null) {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton() {
            if (currentBtn != null) {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm) {
            //open only form
            if (currentChildForm != null) {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }
        private void Reset() {
            DisableButton();
            if (currentChildForm != null) {
                currentChildForm.Close();
            }
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }
        //Events
        //Reset
        private void btnHome_Click(object sender, EventArgs e) {
            Reset();
        }

        private void btnDangKyTro_Click(object sender, EventArgs e) {
            if(BUS_User.UserAuth == null) {
                OpenChildForm(GUI_Login.GetInstance);
            }
            else FormDangKyTro.GetInstance.Show();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                FormBorderStyle = FormBorderStyle.None;
                btnMaximize.IconChar = IconChar.Minimize;
            }
            else {
                FormBorderStyle = FormBorderStyle.Sizable;
                btnMaximize.IconChar = IconChar.Maximize;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            Reset();
            if(currentChildForm == null || currentChildForm.Text != "Login")
                OpenChildForm(GUI_Login.GetInstance);
        }

        private void lock_Unlock(bool isLogin) {
            btnLogout.Visible = isLogin;

            if (BUS_User.UserAuth != null) {
                if (BUS_User.UserAuth.Role.Equals("Host")) {
                    panelHost.Visible = isLogin;
                    btnDangKyTro.Visible = !isLogin;
                } else
                    btnLichSuDatPhong.Visible = isLogin;
            }
            else { 
                panelHost.Visible = isLogin;
                btnLichSuDatPhong.Visible = isLogin;
                btnDangKyTro.Visible = !isLogin;
            }
        }

        private void Index_Activated(object sender, EventArgs e) {
            loadHostItems();
            lock_Unlock(BUS_User.isLogin);
            if (BUS_User.UserAuth != null) {
                btnLogin.Text = BUS_User.UserAuth.name;
                btnLogin.Click -= btnLogin_Click;
                Reset();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            BUS_User.isLogin = false;
            BUS_User.UserAuth = null;
            lblTitleChildForm.Text = "Home";
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            lock_Unlock(BUS_User.isLogin);
            Reset();
        }

        private void home_Host1_Click(object sender, EventArgs e) {
            FormChiTietNhaTro f = new FormChiTietNhaTro();
            f.Show();
        }

        private void btnQuanLyTro_Click(object sender, EventArgs e) {

        }

        private void btnQuanLyTro_Click_1(object sender, EventArgs e) {
            _Host result = host.findByUserId(BUS_User.UserAuth._id);
            FormChiTietNhaTro_Host f = new FormChiTietNhaTro_Host(result);
            f.Show();
        }
    }
}
