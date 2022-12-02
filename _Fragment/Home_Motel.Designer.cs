
namespace _Fragment {
    partial class Home_Motel {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home_Motel));
            this.picMotel = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDienTich = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picMotel)).BeginInit();
            this.SuspendLayout();
            // 
            // picMotel
            // 
            this.picMotel.Dock = System.Windows.Forms.DockStyle.Top;
            this.picMotel.Image = ((System.Drawing.Image)(resources.GetObject("picMotel.Image")));
            this.picMotel.Location = new System.Drawing.Point(0, 0);
            this.picMotel.Margin = new System.Windows.Forms.Padding(0);
            this.picMotel.Name = "picMotel";
            this.picMotel.Padding = new System.Windows.Forms.Padding(15);
            this.picMotel.Size = new System.Drawing.Size(300, 179);
            this.picMotel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMotel.TabIndex = 0;
            this.picMotel.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 200);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(152, 36);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên Phòng Trọ";
            // 
            // lblDienTich
            // 
            this.lblDienTich.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDienTich.Location = new System.Drawing.Point(101, 247);
            this.lblDienTich.Name = "lblDienTich";
            this.lblDienTich.Size = new System.Drawing.Size(132, 30);
            this.lblDienTich.TabIndex = 1;
            this.lblDienTich.Text = "Diện Tích";
            // 
            // lblGia
            // 
            this.lblGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGia.Location = new System.Drawing.Point(101, 289);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(132, 30);
            this.lblGia.TabIndex = 1;
            this.lblGia.Text = "Giá";
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiPhong.Location = new System.Drawing.Point(170, 200);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(127, 24);
            this.lblLoaiPhong.TabIndex = 1;
            this.lblLoaiPhong.Text = "Loại Phòng";
            this.lblLoaiPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Diện Tích: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giá";
            // 
            // Home_Motel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLoaiPhong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDienTich);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picMotel);
            this.Margin = new System.Windows.Forms.Padding(15);
            this.Name = "Home_Motel";
            this.Size = new System.Drawing.Size(300, 350);
            ((System.ComponentModel.ISupportInitialize)(this.picMotel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMotel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDienTich;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
