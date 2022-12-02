
namespace GUI.Forms.Host {
    partial class FormChiTietNhaTro_Host {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblDes = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pic_Host = new System.Windows.Forms.PictureBox();
            this.fpanelPhongTro = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnDisPost = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Host)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDes
            // 
            this.lblDes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDes.Location = new System.Drawing.Point(3, 25);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(435, 211);
            this.lblDes.TabIndex = 8;
            this.lblDes.Text = "Thong tin them";
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(12, 539);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(302, 60);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Dia chi";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(17, 468);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(302, 60);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Name";
            // 
            // pic_Host
            // 
            this.pic_Host.Location = new System.Drawing.Point(12, 64);
            this.pic_Host.Name = "pic_Host";
            this.pic_Host.Size = new System.Drawing.Size(446, 387);
            this.pic_Host.TabIndex = 7;
            this.pic_Host.TabStop = false;
            // 
            // fpanelPhongTro
            // 
            this.fpanelPhongTro.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fpanelPhongTro.Location = new System.Drawing.Point(513, 209);
            this.fpanelPhongTro.Name = "fpanelPhongTro";
            this.fpanelPhongTro.Size = new System.Drawing.Size(1281, 859);
            this.fpanelPhongTro.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1777, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 41);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(1603, 150);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(191, 41);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm Phòng Trọ";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnPost
            // 
            this.btnPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.Location = new System.Drawing.Point(513, 150);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(191, 41);
            this.btnPost.TabIndex = 12;
            this.btnPost.Text = "Đăng Bài";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnDisPost
            // 
            this.btnDisPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisPost.Location = new System.Drawing.Point(710, 150);
            this.btnDisPost.Name = "btnDisPost";
            this.btnDisPost.Size = new System.Drawing.Size(191, 41);
            this.btnDisPost.TabIndex = 12;
            this.btnDisPost.Text = "Hủy Đăng Bài";
            this.btnDisPost.UseVisualStyleBackColor = true;
            this.btnDisPost.Click += new System.EventHandler(this.btnDisPost_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 621);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 239);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(513, 103);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(271, 41);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa Thông Tin Nhà Trọ";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // FormChiTietNhaTro_Host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDisPost);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pic_Host);
            this.Controls.Add(this.fpanelPhongTro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChiTietNhaTro_Host";
            this.Text = "FormChiTietNhaTro_Host";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FormChiTietNhaTro_Host_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Host)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pic_Host;
        private System.Windows.Forms.FlowLayoutPanel fpanelPhongTro;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnDisPost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSua;
    }
}