using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCaro {

    // Lớp CaroConst.
    // Mục đích: Lưu và định nghĩa các hằng số trong game.
    class CaroConst {

        /// <summary>
        /// Chiều dài của một ô cờ.
        /// </summary>
        public const int DAIX = 22;
        
        /// <summary>
        /// Chiều rộng của một ô cờ.
        /// </summary>
        public const int DAIY = 22;

        /// <summary>
        /// Số cột của bàn cờ
        /// </summary>
        public const int LineX = 31;

        /// <summary>
        /// Số hàng của bàn cờ.
        /// </summary>
        public const int LineY = 31;

        /// <summary>
        /// Quân cờ X.
        /// </summary>
        public const string QuanX = "x";

        /// <summary>
        /// Quân cờ O.
        /// </summary>
        public const string QuanO = "o";

        /// <summary>
        /// Số ô cách ô vừa đánh, mục đích để reset lại điểm bảng điểm.
        /// </summary>
        public const int MaxResetXY = 6;

        /// <summary>
        /// Level dễ là 1.
        /// </summary>
        public const int LevelDe = 1;

        /// <summary>
        /// Level trung bình là 2.
        /// </summary>
        public const int LevelTrungBinh = 2;

        /// <summary>
        /// Level khó là 3.
        /// </summary>
        public const int LevelKho = 3;

        /// <summary>
        /// Chế độ chơi người với người là 1.
        /// </summary>
        public const int PlayervsPlayer = 1;

        /// <summary>
        /// Chế độ chơi người với máy là 2.
        /// </summary>
        public const int PlayervsComputer = 2;

        /// <summary>
        /// Điểm của mỗi ô khi khởi tạo mảng điểm của ô cờ.
        /// </summary>
        public const int DiemKhoiTao = -2;

        /// <summary>
        /// Điểm của ô cờ đã được đánh.
        /// </summary>
        public const int DiemODaDanh = -9999;

        /// <summary>
        /// Ô cờ không thuộc về X hoặc O.
        /// </summary>
        public const string KoSoHuu = "";

        /// <summary>
        /// Con trỏ chuột chỉ đến đâu thì không có gì cả.
        /// </summary>
        public const int ConTroChuotNothing = 0;

        /// <summary>
        /// Con trỏ chuột chỉ đến đâu thì tô màu ô đó.
        /// </summary>
        public const int ConTroChuotColor = 1;

        /// <summary>
        /// Con trỏ chuột chỉ đến đâu thì tô màu ô đó và hiện quân được phép đánh.
        /// </summary>
        public const int ConTroChuotAll = 2;

    }
}
