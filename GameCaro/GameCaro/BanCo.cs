using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro {

    // Lớp bàn cờ.
    // Mục đích: Khởi tạo số đường kẻ ngang và dọc.
    class BanCo {

        // Số các đường kẻ ngang và dọc trong bàn cờ.
        private int _LineX;
        private int _LineY;

        public int LineX {
            get {
                return _LineX;
            }
        }
        public int LineY {
            get {
                return _LineY;
            }
        }

        // Constructor.
        public BanCo() {
            _LineX = 0;
            _LineY = 0;
        }

        // Constructor
        public BanCo(int lineX, int lineY) {
            _LineX = lineX;
            _LineY = lineY;
        }
    }
}
