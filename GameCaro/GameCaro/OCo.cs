using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro {

    // Lớp ô cờ.
    // Mục đích: Định nghĩa các ô cờ trong bàn cờ.
    class OCo {
        
        // Kích thước của một ô cờ.
        public const int DAIX = CaroConst.DAIX;
        public const int DAIY = CaroConst.DAIY;

        // Toạ độ của ô cờ (tức là xem ô cờ là 1 điểm trọng bàn cờ).
        private int _OX;
        private int _OY;

        public int OX {
            get {
                return _OX;
            }
            set {
                _OX = value;
            }
        }
        public int OY {
            get {
                return _OY;
            }
            set {
                _OY = value;
            }
        }

        // Tọa độ góc trái trên của ô cờ.
        private Point _ViTri;
        public Point ViTri {
            get {
                return _ViTri;
            }
            set {
                _ViTri = value;
            }
        }

        // Ô cờ thuộc sở hữu của quân nào hay không.
        private string _SoHuu;
        public string SoHuu {
            get {
                return _SoHuu;
            }
            set {
                _SoHuu = value;
            }
        }

        public OCo() {
        }

        public OCo(int Ox, int Oy, Point ViTri, string SoHuu) {
            _OX = Ox;
            _OY = Oy;
            _ViTri = ViTri;
            _SoHuu = SoHuu;
        }
    }
}
