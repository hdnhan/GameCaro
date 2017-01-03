using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro {
    public partial class frmOptions : Form {
        public delegate void ReceiveSetTime(int minute, int second, bool setTime, bool setNoti);
        public delegate void ReceiveOptions(int level, bool levelWar, bool quanXDiTruoc, bool mayDiTruoc, int conTroChuot);
        public ReceiveSetTime mySetTime;
        public ReceiveOptions myOptions;
        private int level;
        private bool levelWar;
        private bool quanXDiTruoc;
        private bool mayDiTruoc;
        private int minute;
        private int second;
        private bool setTime;
        private int conTroChuot;
        private bool setNoti;
        public frmOptions(int level, bool levelWar, bool quanXDiTruoc, bool mayDiTruoc, int minute, int second, bool setTime, int conTroChuot, bool setNoti) {
            InitializeComponent();
            this.level = level;
            this.levelWar = levelWar;
            this.quanXDiTruoc = quanXDiTruoc;
            this.mayDiTruoc = mayDiTruoc;
            this.minute = minute;
            this.second = second;
            this.setTime = setTime;
            this.conTroChuot = conTroChuot;
            this.setNoti = setNoti;
        }

        private void btnOK_Click(object sender, EventArgs e) {

            // 1. Thiết lập cấp độ chơi.
            if (rbtnDe.Checked == true) { level = CaroConst.LevelDe; }
            if (rbtnTrungBinh.Checked == true) { level = CaroConst.LevelTrungBinh; }

            // 2. Thiết lập chế độ tính điểm. 
            if (rbtnHoabinh.Checked == true) { levelWar = false; }
            if (rbtnChientranh.Checked == true) { levelWar = true; }

            // 3. Thiết lập thời gian.
            if (rbtnCoTime.Checked == true && txtboxPhut.Text != "" && txtBoxGiay.Text != "") {
                minute = Convert.ToInt32(txtboxPhut.Text);
                second = Convert.ToInt32(txtBoxGiay.Text);
                setTime = true;
            } else if (rbtnKoTime.Checked == true) {
                minute = second = 0;
                setTime = false;
            }

            // 4. Thiết lập chọn quân cờ đi trước.
            if (rbtnQuanX.Checked == true) {
                quanXDiTruoc = true;
            }
            if (rbtnQuanO.Checked == true) {
                quanXDiTruoc = false;
            }

            // 5. Thiết lập chọn người hay máy đi trước.
            if (rbtnMay.Checked == true) {
                mayDiTruoc = true;
            }
            if (rbtnNguoi.Checked == true) {
                mayDiTruoc = false;
            }

            // 6. Thiết lập con trỏ chuột.
            if (rbtnColor.Checked == true) { conTroChuot = CaroConst.ConTroChuotColor; }
            if (rbtnNothing.Checked == true) { conTroChuot = CaroConst.ConTroChuotNothing; }
            if (rbtnAll.Checked == true) { conTroChuot = CaroConst.ConTroChuotAll; }

            // 7. Thiết lập thông báo nếu có nguy hiểm
            if (rbtnKoNoti.Checked == true) { setNoti = false; }
            if (rbtnCoNoti.Checked == true) { setNoti = true; }

            mySetTime(minute, second, setTime, setNoti);
            myOptions(level, levelWar, quanXDiTruoc, mayDiTruoc, conTroChuot);
            this.Close();
        }

        // Để load lại những thiết lập trước đó gần nhất.
        private void frmOptions_Load(object sender, EventArgs e) {

            // 1. Load lại cấp độ chơi thiết lập trước đó.
            if (level == CaroConst.LevelDe) {
                rbtnDe.Checked = true;
            } else {
                rbtnTrungBinh.Checked = true;
            }

            // 2. Load lại thiết lập chế độ tính điểm trước đó.
            if (levelWar == false) { rbtnHoabinh.Checked = true; } else {
                rbtnChientranh.Checked = true;
            }

            // 3. Load lại thiết lập thời gian trước đó.
            if (setTime) {
                rbtnCoTime.Checked = true;
                txtboxPhut.Text = minute.ToString();
                txtBoxGiay.Text = second.ToString();
            } else {
                rbtnKoTime.Checked = true;
                txtboxPhut.Text = "00";
                txtBoxGiay.Text = "00";
            }

            // 4. Load lại thiết lập chọn quân cờ đi trước trước đó.
            if (quanXDiTruoc) {
                rbtnQuanX.Checked = true;
            } else {
                rbtnQuanO.Checked = true;
            }

            // 5. Load lại thiết lập chọn người hay máy đi trước trước đó.
            if (mayDiTruoc) {
                rbtnMay.Checked = true;
            } else {
                rbtnNguoi.Checked = true;
            }

            // 6. Load lại thiết lập con trỏ chuột trước đó. 
            if (conTroChuot == CaroConst.ConTroChuotColor) { rbtnColor.Checked = true; }
            if (conTroChuot == CaroConst.ConTroChuotNothing) { rbtnNothing.Checked = true; }
            if (conTroChuot == CaroConst.ConTroChuotAll) { rbtnAll.Checked = true; }

            // 7. Load lại thiết lập thông báo nếu có nguy hiểm trước đó.
            if (setNoti) {
                rbtnCoNoti.Checked = true;
            } else {
                rbtnKoNoti.Checked = true;
            }

        }
    }
}
