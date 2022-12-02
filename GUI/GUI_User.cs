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
using DTO;

namespace GUI {
    public partial class GUI_User : Form {
        private static GUI_User instance;

        public static GUI_User GetInstance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new GUI_User();
                }
                return instance;
            }
        }

        private GUI_User() {
            InitializeComponent();
        }
        BUS_User user = new BUS_User();

        private void frmUser_Load(object sender, EventArgs e) {
            dgvUser.DataSource = user.findAll().ToList<_User>();
            /*user.insert(new _User("nghia", "123", "nghiapro", "nghia@gmail.com", "01234", null, "User"));*/
        }
    }
}

