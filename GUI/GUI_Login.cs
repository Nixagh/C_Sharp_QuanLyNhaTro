using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace GUI {
    public partial class GUI_Login : Form {
        private static GUI_Login instance;

        public static GUI_Login GetInstance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new GUI_Login();
                }
                instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
                instance.txtusername.Focus();
                return instance;
            }
        }

        private GUI_Login() {
            InitializeComponent();
        }

        BUS_User user = new BUS_User();

        private void btncancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e) {
            if(txtusername.Text == "" || txtpassword.Text == "") {
                MessageBox.Show("Please Enter Values.", "Infomation.");
                txtusername.Focus();
                return;
            }

            if (user.checkLogin(txtusername.Text, txtpassword.Text)) {
                BUS_User.isLogin = true;
                MessageBox.Show("Login success.", "Infomation.");
                this.Close();
            }
            else {
                MessageBox.Show("Login fail. Wrong username or password", "Infomation.");
            }
        }

    }
}
