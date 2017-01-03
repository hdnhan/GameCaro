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
    public partial class frmExit : Form {
        FrmGameCaro fGC = new FrmGameCaro();
        bool checkReady; // Kiểm tra xem trận đấu đang diễn ra hay ko?
        public frmExit(FrmGameCaro fc, bool ready) {
            InitializeComponent();
            fGC = fc;
            checkReady = ready;
        }

        // Thông báo trước khi thoát.
        private void frmExit_Load(object sender, EventArgs e) {
            if (!checkReady) {
                lblCanhBao2.Text = "Bạn có thật sự muốn thoát không?";
            } else {
                lblCanhBao1.Text = "      Ván cờ chưa kết thúc\nBạn có thật sự muốn thoát không?";
            }

        }

        // Click button Yes.
        private void btnYes_Click(object sender, EventArgs e) {
            this.Close();
            fGC.Close();
        }

        // Click button No.
        private void btnNo_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
