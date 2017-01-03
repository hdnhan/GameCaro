using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro {

    // Lớp CaroChess
    // Muc đích: Vẽ bàn cờ, vẽ quân cờ, kiểm tra chiến thắng, AI.
    class CaroChess {


        #region Field & Property

        // Bút vẽ các dòng và cột.
        private static Pen PenDrawLine;

        // Vẽ lại ô cờ khi undo. 
        private static SolidBrush SBGhostWhite;
        
        // Quân cờ O.
        public Image QuanCoO = new Bitmap(Properties.Resources.o);
        
        // Quân cờ X.
        public Image QuanCoX = new Bitmap(Properties.Resources.x);  
        
        // Bàn cờ.      
        private BanCo Board;
        
        // Biến gán trạng thái của bàn cờ.
        private bool _SanSang;
        public bool SanSang {
            get { return _SanSang; }
            set { _SanSang = value; }
        }
        
        // true: Quân cờ X đi trước, false: Quân cờ X đi sau.
        private bool _QuanXDanhTruoc;
        public bool QuanXDanhTruoc {
            get { return _QuanXDanhTruoc; }
            set { _QuanXDanhTruoc = value; }
        }
        
        // True: Máy đi trước, false: Máy đi sau.
        private bool _MayDiTruoc;
        public bool MayDiTruoc {
            get { return _MayDiTruoc; }
            set { _MayDiTruoc = value; }
        }
        
        // Lượt đi của quân cờ nào hoặc của máy hay của người.  
        private string _LuotDi;
        public string LuotDi {
            get { return _LuotDi; }
            set { _LuotDi = value; }
        }
        
        private OCo[,] _MangOCo;
        
        // Các nước đã đi lưu vào stack
        private Stack<OCo> _CacNuocDaDi;
        public OCo[,] MangOCo {
            get { return _MangOCo; }
        }
        
        // Chế độ chơi player vs player hay player vs computer.
        private int _CheDoChoi;
        public int CheDoChoi {
            get { return _CheDoChoi; }
        }
        
        // Tổng điểm của điểm tấn công và điểm phòng ngự.
        private int[,] DiemTong;
        
        // Điểm tính cho quân cờ máy.
        private int[,] DiemTanCong;
        
        // Điểm tính cho quân cờ địch.
        private int[,] DiemPhongNgu;
        
        // Các cấp của trận đấu, có dễ và trung bình.
        private int _Level;
        public int Level {
            get { return _Level; }
        }
        // True: Dựa vào điểm tổng để đi, flase: Dựa vào điểm tấn công và phòng ngự để đi.
        private bool _LevelWar;
        public bool LevelWar {
            get { return _LevelWar; }
        }

        // Quân của máy tính. 
        private string _QuanCuaMay;
        public string QuanCuaMay {
            get { return _QuanCuaMay; }
            set { _QuanCuaMay = value; }
        }

        // Quân của người chơi.
        private string _QuanCuaNguoi;
        public string QuanCuaNguoi {
            get { return _QuanCuaNguoi; }
            set { _QuanCuaNguoi = value; }
        }

        // Hiện thị con trỏ chuột khi di chuyển.
        public int ConTroChuot;

        // Thông báo nếu có nguy hiểm.       
        public bool CoNguyeHiem;

        // Vị trí tọa độ  x quân vừa đánh.
        private int CurrentX;

        // Vị trí tọa độ  x quân vừa đánh.
        private int CurrentY; 

        #endregion



        // Constructor.
        public CaroChess() {
            // Đường kẻ màu xanh.
            PenDrawLine = new Pen(Color.Black);
            // Màu của ô cờ là GhostWhite.
            SBGhostWhite = new SolidBrush(Color.GhostWhite);
            // Bàn cờ (chừa 1 dòng 1 cột)
            Board = new BanCo(CaroConst.LineX, CaroConst.LineY);
            // Mặc định quân X đánh trước.
            _QuanXDanhTruoc = true;
            // Mặc định máy đánh trước.
            _MayDiTruoc = true;
            // Quân cờ X đánh trước.
            _LuotDi = CaroConst.QuanX;
            // Khởi tạo mảng ô cờ tương ứng với bàn cờ.
            _MangOCo = new OCo[Board.LineX, Board.LineY];
            // Khởi tạo stack các nước đã đi.
            _CacNuocDaDi = new Stack<OCo>(); 
            DiemTong = new int[Board.LineX, Board.LineY];
            DiemTanCong = new int[Board.LineX, Board.LineY];
            DiemPhongNgu = new int[Board.LineX, Board.LineY];
            // Mặc định là cấp độ khó.
            _Level = CaroConst.LevelDe;
            // Mặc định là dùng điểm tổng để tính toán nước đi.
            _LevelWar = false;             
            ConTroChuot = CaroConst.ConTroChuotColor;
        }



        #region Các thiết lập cơ bản của bàn cờ.

        // Mục đích: Khởi động chế độ chơi giữa player vs player
        // Input: Graphics g của bàn cờ.
        // Output: Bàn cờ mới, chế độ chơi player vs player.             
        public void StartPlayervsPlayer(Graphics g) {

            // 1. Làm mới bàn cờ.
            StartTranDau(g);

            // 2. Gán chế độ chơi player vs player.
            _CheDoChoi = CaroConst.PlayervsPlayer;
        }


        // Mục đích: Khởi động chế độ chơi player vs computer.
        // Input: Graphics g của bàn cờ.
        // Output: Một bàn cờ mới hoàn toàn đang ở chế độ chơi.     
        public void StartPlayerVsComputer(Graphics g) {

            // 1. Làm mới bàn cờ.
            StartTranDau(g);

            // 2. Gán chế độ chơi player vs computer.
            _CheDoChoi = CaroConst.PlayervsComputer;

            // 3. Quân cờ mà máy đi.
            _QuanCuaMay = _MayDiTruoc == _QuanXDanhTruoc ? CaroConst.QuanX : CaroConst.QuanO;
            _QuanCuaNguoi = _MayDiTruoc == _QuanXDanhTruoc ? CaroConst.QuanO : CaroConst.QuanX;

            // 4. Khởi động bảng điểm của bàn cờ.
            StartScoreBoard();

            // 5. Nước đầu tiên của.
            if (_MayDiTruoc) {
                ComputerPlay(g); // Đánh nước đầu cho computer.                         
            }
        }


        // Mục đích: Đưa bàn cờ về trạng thái ban đầu.
        // Input: Graphics g của bàn cờ.
        // Output: Xóa tất cả quân hiện có, bàn cờ sẵn sàng, làm mới các nước đã đi.   
        public void StartTranDau(Graphics g) {

            // 1. Xóa tất cả các quân cờ hiện có trên bàn cờ.
            XoaTatCaQuanCo(g);

            // 2. Đưa bàn cờ về trạng thái sẵn sàng.
            _SanSang = true;

            // 3. Làm mới các nước đã đi.
            _CacNuocDaDi = new Stack<OCo>();

            // 4. Quân cờ nào đi trước.
            if (_QuanXDanhTruoc) {
                _LuotDi = CaroConst.QuanX;
            } else {
                _LuotDi = CaroConst.QuanO;
            }
        }


        // Mục đích: Kiểm tra việc đánh quân cờ có hợp lệ hay không.
        // Input: Tọa độ quân cờ.
        // Output: 
        //  - false: Không hợp lệ.
        //  - true: hợp lệ.       
        public bool CheckClickMouse(int mouseX, int mouseY) {

            // 1. Bàn cờ chưa sẵn sàng.
            if (!_SanSang) { return false; }

            // 2. Con trỏ chuột nằm ngoài bàn cờ.
            if (mouseX < OCo.DAIX || mouseY < OCo.DAIY || mouseX > OCo.DAIX * Board.LineX || mouseY > OCo.DAIY * Board.LineY) {
                return false;
            }

            // 3. Con trỏ chuột nằm trên đường kẻ.
            if (mouseX % OCo.DAIX == 0 || mouseY % OCo.DAIY == 0) {
                return false;
            }

            // 4. Ô cờ đã được vẽ.
            if (_MangOCo[mouseX / OCo.DAIX, mouseY / OCo.DAIY].SoHuu != CaroConst.KoSoHuu) {
                return false;
            }

            return true;
        }


        // Mục đích: Vẽ quân cờ khi việc đánh cờ là hợp lệ
        // Input: Graphics g của bàn cờ, tọa độ.
        // Output: Quân cờ tương ứng.
        public void VeQuanCo(Graphics g, int mouseX, int mouseY) {

            // 1. Tính tọa độ ô cờ cần vẽ.
            CurrentX = mouseX / OCo.DAIX;
            CurrentY = mouseY / OCo.DAIY;

            // 2. Xem lượt đi của quân nào để vẽ quân đó.
            switch (_LuotDi) {
                case CaroConst.QuanX:
                    _MangOCo[CurrentX, CurrentY].SoHuu = CaroConst.QuanX;
                    g.DrawImage(QuanCoX, CurrentX * OCo.DAIX + 2, CurrentY * OCo.DAIY + 2, OCo.DAIX - 4, OCo.DAIY - 4);
                    break;
                case CaroConst.QuanO:
                    _MangOCo[CurrentX, CurrentY].SoHuu = CaroConst.QuanO;
                    g.DrawImage(QuanCoO, CurrentX * OCo.DAIX + 2, CurrentY * OCo.DAIY + 2, OCo.DAIX - 4, OCo.DAIY - 4);
                    break;
            }

            // 3. Lưu mỗi nước đã đi vào stack (để khi undo)
            _CacNuocDaDi.Push(_MangOCo[CurrentX, CurrentY]);

            // 4. Các ô đã đi thì cho điểm thấp.
            if (_CheDoChoi == CaroConst.PlayervsComputer) {
                DiemTong[CurrentX, CurrentY] = CaroConst.DiemODaDanh;
                DiemTanCong[CurrentX, CurrentY] = CaroConst.DiemODaDanh;
                DiemPhongNgu[CurrentX, CurrentY] = CaroConst.DiemODaDanh;
            }
        }


        // Mục đích: Vẽ quân cờ chạy khi di chuyển chuột trên bàn cờ.
        // Input: Graphics của bàn cờ, tọa độ và ảnh quân cờ muốn vẽ.
        // Output: Vẽ được quân cờ tương ứng.
        public void VeQuanCoChay(Graphics g, int mouseX, int mouseY, Image img) {
            g.DrawImage(img, mouseX + 2, mouseY + 2, OCo.DAIX - 4, OCo.DAIY - 4);
        }


        // Mục đích: Vẽ bàn cờ.
        // Input: Graphics của bàn cờ.
        // Output: Các đường ngang và dọc.    
        public void VeBanCo(Graphics g) {

            // 1. Vẽ các dòng với tọa độ là (x1, y1) và (x2, y2) với x1, x2 cố định.
            for (int i = 1; i <= Board.LineY; i++) {
                g.DrawLine(PenDrawLine, OCo.DAIX, i * OCo.DAIY, Board.LineX * OCo.DAIX, i * OCo.DAIY);
            }

            // 2. Vẽ các cột với tọa độ là (x1, y1) và (x2, y2) với y1, y2 cố định.
            for (int j = 1; j <= Board.LineX; j++) {
                g.DrawLine(PenDrawLine, j * OCo.DAIX, OCo.DAIY, j * OCo.DAIX, Board.LineY * OCo.DAIY);
            }

        }


        // Mục đích: Khởi tạo mảng sở hữu.
        // Input: 
        // Output: Các ô cờ không thuộc sở hữu của quân nào.
        public void KhoiTaoMangSoHuu() {
            // 1. Khởi tạo mảng ô cờ, đưa và trạng thái ban đầu.
            for (int i = 1; i < Board.LineX; i++) {
                for (int j = 1; j < Board.LineY; j++) {
                    _MangOCo[i, j] = new OCo(i, j, new Point(i * OCo.DAIX, j * OCo.DAIY), CaroConst.KoSoHuu);
                }
            }
        }


        // Mục đích: Xóa quân cờ lúc undo hoặc xóa tất cả quân cờ.
        // Input: Graphics bàn cờ, vị trị, màu của bàn cờ (chẳng qua là vẽ đè lên).
        // Output: Được ô cờ đánh được, tức là không có quân cờ và không thuộc sở hữu của quân nào.    
        public void XoaQuanCo(Graphics g, Point ViTri, SolidBrush sb) {

            // 1. +1 hoặc -2 để tránh vẽ lên đường đã vẽ (thực chất là vẽ lại hình chữ nhật).
            g.FillRectangle(sb, ViTri.X + 1, ViTri.Y + 1, OCo.DAIX - 1, OCo.DAIY - 1);
        }


        // Mục đích: Xóa tất cả các quân cờ khi reset lại bàn cờ hoặc chơi ván khác.
        // Input: Graphichs bàn cờ.
        // Output: Bàn cờ mới.
        public void XoaTatCaQuanCo(Graphics g) {

            foreach (OCo oCo in _CacNuocDaDi) {

                // 1. Xóa sở hữu các ô đã đánh
                oCo.SoHuu = CaroConst.KoSoHuu;

                // 2. Xóa từng quân đã đánh
                XoaQuanCo(g, oCo.ViTri, SBGhostWhite);
            }
        }


        // Mục đích: Vẽ lại các quân cờ khi bị che khuất.
        // Input: Graphichs của bàn cờ.
        // Output: Các quân cờ đã đánh.
        public void VeLaiQuanCo(Graphics g) {

            foreach (OCo oCo in _CacNuocDaDi) {
                if (oCo.SoHuu == CaroConst.QuanX)
                    g.DrawImage(QuanCoX, oCo.ViTri.X + 2, oCo.ViTri.Y + 2, OCo.DAIX - 4, OCo.DAIY - 4);
                else if (oCo.SoHuu == CaroConst.QuanO)
                    g.DrawImage(QuanCoO, oCo.ViTri.X + 2, oCo.ViTri.Y + 2, OCo.DAIX - 4, OCo.DAIY - 4);
            }
        }


        // Mục đích: Xóa nước vừa đánh.
        // Input: Graphics bàn cờ.
        // Output: Ô vừa đánh được trả lại trạng thái cũ.      
        public void Undo(Graphics g) {

            // 1. Ở chế độ chơi player vs player (undo lần lượt từng quân 1).
            if (_CacNuocDaDi.Count != 0) {

                // 1.1 Lấy địa chỉ ô muốn undo.
                OCo oCo = _CacNuocDaDi.Pop();

                // 1.2. Xóa quân muốn undo
                XoaQuanCo(g, oCo.ViTri, SBGhostWhite);

                // 1.3. Ô undo phải không thuộc về quân nào cả.
                _MangOCo[oCo.OX, oCo.OY].SoHuu = CaroConst.KoSoHuu;

                // 1.4. Trả đúng lượt đi cho người undo.
                if (_LuotDi == CaroConst.QuanX) {
                    _LuotDi = CaroConst.QuanO;
                } else {
                    _LuotDi = CaroConst.QuanX;
                }
            }

            // 2. Ở chế độ chơi player vs computer (undo 1 lượt 2 quân).
            if (_CheDoChoi == 2 && _CacNuocDaDi.Count != 0) {

                // 1. Undo quân người chơi
                // Ta đã undo quân người chơi ở chế độ chơi player vs player rồi.

                // 2. Undo quân của máy               
                // 2.1. Lấy địa chỉ ô muốn undo.
                OCo oCo = _CacNuocDaDi.Pop();

                // 2.2. Xóa quân muốn undo
                XoaQuanCo(g, oCo.ViTri, SBGhostWhite);

                // 2.3. Ô undo phải không thuộc về quân nào cả.
                _MangOCo[oCo.OX, oCo.OY].SoHuu = CaroConst.KoSoHuu;

                // 2.4. Trả đúng lượt đi cho người undo.
                if (_LuotDi == CaroConst.QuanX) {
                    _LuotDi = CaroConst.QuanO;
                } else {
                    _LuotDi = CaroConst.QuanX;
                }

                // 2.5. Trả lại bản điểm trước khi đánh, rồi undo.
                ResetScoreBoard(1, 1, 30);
            }
        }


        // Mục đích: Thiết lập leve của trận đấu.
        // Input: level, levelWar
        // Output: Level và LevelWar.     
        public void SetLevel(int level, bool levelWar) {
            _Level = level;
            _LevelWar = levelWar;
        }


        // Mục đích: Các thiết lập của người chơi.
        // Input: level, các tính điểm, quân đi trước, vẽ con trỏ chuột
        // Output: Các thiết lập tương ứng.     
        public void SetOptions(int level, bool levelWar, bool quanXDiTruoc, bool mayDiTruoc, int conTroChuot) {
            _Level = level;
            _LevelWar = levelWar;
            _QuanXDanhTruoc = quanXDiTruoc;
            _MayDiTruoc = mayDiTruoc;           
            ConTroChuot = conTroChuot;               
        }


        // Mục đích: Hiện thị thời gian đếm ngược.
        // Input: phút, giây và các label tương ứng.
        // Output: Hiện đúng thời gian.   
        public void HienThiThoiGian(ref int phut, ref int giay, Label lblphut, Label lblgiay) {

            // 1. Khi số giây = 0 thì giảm số phút - 1.
            if (giay < 0) {
                giay = 59;
                phut--;
            }

            // 2. Nhập giây quá 60.
            if (giay > 60) {
                phut = phut + giay / 60;
                giay = giay % 60;
            }

            // 3. Hiện thị giây (2 con số hay 1 con số).
            if (giay < 10) {
                lblgiay.Text = "0" + giay;
            } else {
                lblgiay.Text = giay + "";
            }

            // 4. Hiện thị phút (2 con số hay 1 con số).
            if (phut < 10) {
                lblphut.Text = "0" + phut;
            } else {
                lblphut.Text = phut + "";
            }
        }


        // Mục đích: Thông báo trạng thái nguy hiểm.
        // Input: Tọa độ quân vừa đánh.
        // Output: False: Là không có, true: là có nguy hiểm.
        // Kiểm tra xem có nguy hiểm không, nếu có thì thông báo.
        public bool CoNguyHiem(int currX, int currY, string luotDi) {

            int[,] scoredanger = new int[4, 10];
            for (int i = 0; i < 10; i++) {
                if (Math.Abs(currX + i - 5) > 0 && Math.Abs(currX + i - 5) < Board.LineX) {
                    scoredanger[0, i] = DiemDong(currX + i - 5, currY, luotDi, ScoreAttack);
                }
                if (Math.Abs(currY + i - 5) > 0 && Math.Abs(currY + i - 5) < Board.LineX) {
                    scoredanger[1, i] = DiemCot(currX, currY + i - 5, luotDi, ScoreAttack);
                }
                if (Math.Abs(currX + i - 5) > 0 && Math.Abs(currX + i - 5) < Board.LineX
                    && Math.Abs(currY + i - 5) > 0 && Math.Abs(currY + i - 5) < Board.LineX) {
                    scoredanger[2, i] = DiemCheoChinh(currX + i - 5, currY + i - 5, luotDi, ScoreAttack);
                    scoredanger[3, i] = DiemCheoPhu(currX + i - 5, currY + i - 5, luotDi, ScoreAttack);
                }
            }

            if (scoredanger.Cast<int>().Max() >= (int)(ScoreAttack[2] * 1.21875)) {
                return true;
            }

            return false;
        }    

        #endregion



        #region Kiểm tra chiến thắng

        // Nếu ván cờ đã kết thúc(đã có người chiến thắng hoặc hòa) thì thông báo:
        public void ThongBaoKetQua() {

            // Thông báo kết quả dự vào lượt đi.
            switch (_LuotDi) {
                case CaroConst.KoSoHuu:
                    MessageBox.Show("Hòa cờ!");
                    break;
                case CaroConst.QuanX:
                    if (_CheDoChoi == 1) { MessageBox.Show("Người chơi quân X chiến thắng!"); }
                    if (_CheDoChoi == 2) {
                        if (_QuanXDanhTruoc == _MayDiTruoc) {
                            MessageBox.Show("Computer chiến thắng!");
                        } else {
                            MessageBox.Show("Người chơi chiến thắng");
                        }
                    }
                    break;
                case CaroConst.QuanO:
                    if (_CheDoChoi == 1) { MessageBox.Show("Người chơi quân O chiến thắng!"); }
                    if (_CheDoChoi == 2) {
                        if (_QuanXDanhTruoc != _MayDiTruoc) {
                            MessageBox.Show("Computer chiến thắng!");
                        } else {
                            MessageBox.Show("Người chơi chiến thắng");
                        }
                    }
                    break;
            }
        }


        // Kiểm tra chiến thắng của ván đấu (true: Hòa hoặc có người chiến thắng, false: Chưa kết thúc ván đấu)
        public bool KiemTraChienThang() {

            // 1. Hòa: Khi đi kín bàn cờ
            if (_CacNuocDaDi.Count == (Board.LineX - 1) * (Board.LineY - 1)) {
                _LuotDi = CaroConst.KoSoHuu;
                return true;
            }

            // 2. Có thắng thua:           
            if (DuyetCot(CurrentX, CurrentY, _LuotDi) || DuyetDong(CurrentX, CurrentY, _LuotDi) || 
                DuyetCheoChinh(CurrentX, CurrentY, _LuotDi) || DuyetCheoPhu(CurrentX, CurrentY, _LuotDi)) {
                    return true;
                }
            return false;
        }


        // Duyệt theo ngang (false: chưa chiến thắng, true: chiến thắng rồi).
        private bool DuyetDong(int currX, int currY, string quanTa) {

            // 1. Duyệt dòng đếm số quân ta và địch.
            int[] cntQuanCo = new int[4];
            int[] cntQuanCoTrai = Dong(-currX, currY, quanTa);
            int[] cntQuanCoPhai = Dong(currX, currY, quanTa);
            for (int i = 0; i < 4; i++) {
                cntQuanCo[i] = cntQuanCoTrai[i] + cntQuanCoPhai[i];
            }

            // 2. Nếu có 2 quân địch hoặc số quân ta < 4
            if (cntQuanCo[1] == 2 || cntQuanCo[0] < 4) {
                return false;
            } else {
                return true;
            }
        }


        // Duyệt theo cột (false: chưa chiến thắng, true: chiến thẳng rồi).
        private bool DuyetCot(int currX, int currY, string quanTa) {

            // 1. Đếm số quân địch và quân ta.                     
            int[] cntQuanCo = new int[4];
            int[] cntQuanCoLen = Cot(currX, -currY, quanTa);
            int[] cntQuanCoXuong = Cot(currX, currY, quanTa);
            for (int i = 0; i < 4; i++) {
                cntQuanCo[i] = cntQuanCoLen[i] + cntQuanCoXuong[i];
            }

            // 2. Nếu có 2 quân địch hoặc số quân ta < 4
            if (cntQuanCo[1] == 2 || cntQuanCo[0] < 4) {
                return false;
            } else {
                return true;
            }
        }


        // Duyệt theo đường chéo chính (false: chưa chiến thắng, true: chiến thắng rồi).
        private bool DuyetCheoChinh(int currX, int currY, string quanTa) {

            // 1. Đếm số quân địch và quân ta.                      
            int[] cntQuanCo = new int[4];
            int[] cntQuanCoLen = CheoChinh_CheoPhu(-currX, -currY, quanTa);
            int[] cntQuanCoXuong = CheoChinh_CheoPhu(currX, currY, quanTa);
            for (int i = 0; i < 4; i++) {
                cntQuanCo[i] = cntQuanCoLen[i] + cntQuanCoXuong[i];
            }

            // 2. Nếu có 2 quân địch hoặc số quân ta < 4
            if (cntQuanCo[1] == 2 || cntQuanCo[0] < 4) {
                return false;
            } else {
                return true;
            }
        }


        // Duyệt theo đường chéo phụ (false: chưa chiến thắng, true: chiến thắng rồi)
        private bool DuyetCheoPhu(int currX, int currY, string quanTa) {

            // 1. Đếm số quân địch và quân ta.                     
            int[] cntQuanCo = new int[4];
            int[] cntQuanCoLen = CheoChinh_CheoPhu(currX, -currY, quanTa);
            int[] cntQuanCoXuong = CheoChinh_CheoPhu(-currX, currY, quanTa);
            for (int i = 0; i < 4; i++) {
                cntQuanCo[i] = cntQuanCoLen[i] + cntQuanCoXuong[i];
            }

            // 2. Nếu có 2 quân địch hoặc số quân ta < 4.
            if (cntQuanCo[1] == 2 || cntQuanCo[0] < 4) {
                return false;
            } else {
                return true;
            }
        }

        #endregion



        #region AI computer

        // Có 4 phương nên điểm trước x4 ra điểm sau
        // Điểm phòng ngự bằng 90% điểm tấn công vì ưu tiên kết thúc trận đấu.
        private int[] ScoreAttack = new int[6] { 0, 2, 8, 32, 128, 512 }; // 90%.
        private int[] ScoreDefense = new int[6] { 0, 1, 7, 29, 115, 461 };

        #region Máy đánh cờ

        // Mục đích: Máy đánh vào ô cờ đã được chọn.
        // input: Graphics bàn cờ.
        // output: Quân cờ tương ứng vào ô cờ đã được chọn.
        public void ComputerPlay(Graphics g) {

            // 1. Nếu máy đi trước, thì ramdom một nước
            // 2. Hoặc đánh nước đã được tìm.
            if (_CacNuocDaDi.Count == 0) {
                // 1.1. Tìm nước ramdom bất kỳ ở giữa bàn cờ.
                Random random = new Random();
                int x = random.Next(Board.LineX / 3 + 1, Board.LineX / 2 + 3);
                int y = random.Next(Board.LineX / 3 + 1, Board.LineX / 2 + 3);
                // 1.2. Vẽ nước đó và reset điểm bàn cờ.
                VeQuanCo(g, x * OCo.DAIX, y * OCo.DAIY);
                ResetScoreBoard(x, y, CaroConst.MaxResetXY);
                // 1.3. Nhả lượt đi đầu tiên.
                if (_LuotDi == CaroConst.QuanX) {
                    _LuotDi = CaroConst.QuanO;
                } else {
                    _LuotDi = CaroConst.QuanX;
                }
            } else {
                // 2.1. Tìm ô cờ được cho là tốt nhât.
                OCo oco = TimOCoTot();
                // 2.2. Vẽ quân cờ lên ô cờ đó và reset điểm bàn cờ.
                VeQuanCo(g, oco.ViTri.X, oco.ViTri.Y);
                ResetScoreBoard(oco.ViTri.X / OCo.DAIX, oco.ViTri.Y / OCo.DAIY, CaroConst.MaxResetXY);
                if(CoNguyHiem(oco.ViTri.X / OCo.DAIX, oco.ViTri.Y / OCo.DAIY, _LuotDi)){
                    CoNguyeHiem = true;
                } else { CoNguyeHiem = false; }
            }
        }
 

        // Mục đích: Khởi tạo mảng điểm bàn cờ.
        // Input:
        // Output: Điểm khởi tạo cho từng ôc ờ.
        public void StartScoreBoard() {
            // 1. Mới vào ván đấu thì điểm mỗi ô đều bằng nhau và bằng DiemKhoiTao.
            for (int i = 1; i < Board.LineY; i++) {
                for (int j = 1; j < Board.LineX; j++) {
                    DiemTong[j, i] = DiemTanCong[j, i] = DiemPhongNgu[j, i] = CaroConst.DiemKhoiTao;
                }
            }
            // 2. Các ô nằm ngoài bàn cờ được cho là đã đánh rồi.
            for (int i = 0; i < Board.LineX; i++) {
                DiemTong[i, 0] = DiemTanCong[i, 0] = DiemPhongNgu[i, 0] = CaroConst.DiemODaDanh;
            }
            for (int j = 0; j < Board.LineY; j++) {
                DiemTong[0, j] = DiemTanCong[0, j] = DiemPhongNgu[0, j] = CaroConst.DiemODaDanh;
            }
        }


        // Mục đích: Khi người đánh hay máy đánh xong thì restart mảng điểm bàn cờ.
        // Input: Tọa độ ô cờ vừa đánh và những ô xung quanh (cách ô cờ vừa đánh là maxResetXY ô cờ).
        // Output: Thay đổi điểm ô cờ vừa đánh và những ô cờ xung quanh.
        public void ResetScoreBoard(int x, int y, int maxResetXY) {
            // Chỉ tính reset điểm bàn cờ xung quan ô vừa đánh(vẫn không chặt nhưng sẽ tính toán nhanh hơn).
            // Max(...) & Min(...) để không tính ra ngoài bàn cờ.
            for (int i = Math.Max(1, x - maxResetXY); i < Math.Min(Board.LineX, x + maxResetXY + 1); i++) {
                for (int j = Math.Max(1, y - maxResetXY); j < Math.Min(Board.LineY, y + maxResetXY + 1); j++) {
                    if (_MangOCo[i, j].SoHuu == CaroConst.KoSoHuu) {
                        // Điểm tấn công.
                        DiemTanCong[i, j] = DiemDong(i, j, _QuanCuaMay, ScoreAttack) + DiemCot(i, j, _QuanCuaMay, ScoreAttack) 
                            + DiemCheoChinh(i, j, _QuanCuaMay, ScoreAttack) + DiemCheoPhu(i, j, _QuanCuaMay, ScoreAttack);
                        // Điểm phòng ngự
                        DiemPhongNgu[i, j] = DiemDong(i, j, _QuanCuaNguoi, ScoreDefense) + DiemCot(i, j, _QuanCuaNguoi, ScoreDefense)
                            + DiemCheoChinh(i, j, _QuanCuaNguoi, ScoreDefense) + DiemCheoPhu(i, j, _QuanCuaNguoi, ScoreDefense);
                        // Điểm tổng.
                        DiemTong[i, j] = DiemTanCong[i, j] + DiemPhongNgu[i, j];
                    }
                }
            }
        }

      
        // Mục đích: Hàm tìm chỉ số của những phần tử có giá trị giảm dần.
        // Input: arrayScore là mảng có những phần tử cần tìm. 
        //        m là số phần tử cần tìm.
        // Output: Mảng điểm của những ô cờ có số điểm lớn nhất.
        public int[] FindIndexGreatScore(int[,] arrayScore, int m) {

            int[] indexGreatScore = new int[2 * m];
            int[] GreatScore = new int[m];
            for (int i = 0; i < m; i++) {
                // Phần tử lớn thứ i + 1 (từ trái qua phải, trên xuống dưới).
                GreatScore[i] = arrayScore.Cast<int>().ToArray().OrderByDescending(r => r).Take(i + 1).LastOrDefault();
                int xy = Array.IndexOf(arrayScore.Cast<int>().ToArray(), GreatScore[i]);
                int x = xy / Board.LineX;
                int y = xy % Board.LineY;
                arrayScore[x, y] = CaroConst.DiemODaDanh;
                indexGreatScore[2 * i] = x;
                indexGreatScore[2 * i + 1] = y;
            }
            // Trả lại điểm -->> damn... cái lỗi mất nhiều thời gian mà ko để ý, cứ tưởng gán cho mảng khác là ko bị thay đổi mảng chính.
            for (int i = 0; i < m; i++) {
                arrayScore[indexGreatScore[2 * i], indexGreatScore[2 * i + 1]] = GreatScore[i];
            }

            return indexGreatScore;
        }


        // Mục đích: Sau khi restart mảng điểm bàn cờ thì máy tìm nước thuận lợi nhất.
        // Input:
        // Output: Ô cờ thuận tốt nhất theo thuật toán.
        public OCo TimOCoTot() {

            // 1. Tọa độ của ô cần tìm. 
            int[] PointResult = new int[2];


            // 2. Đùng điểm tổng để tìm nước đi.
            if (!_LevelWar) {
                PointResult = ScorePeace();
            }

            // 3. Dùng điểm tấn công và điểm phòng ngự để tìm nước đi.
            if (_LevelWar) {
                PointResult = ScoreWar();
            }

            // 4. Ô cờ thuận lợi nhất tìm được. 
            int ox = PointResult[0];
            int oy = PointResult[1];
            OCo oCoResult = new OCo(_MangOCo[ox, oy].OX, _MangOCo[ox, oy].OY, _MangOCo[ox, oy].ViTri, _MangOCo[ox, oy].SoHuu);
            return oCoResult;
        }


        // Mục đíchL Dựa vào điểm tổng để tìm nước đi.\
        // Input:
        // Output: ô cờ được cho là tốt nhất.
        private int[] ScorePeace() {

            // 1. Để tính toán nhanh thì ta chỉ cần tìm 6 nước lớn nhất.
            int[] indexGreatScore = FindIndexGreatScore(DiemTong, 6);

            // 2. Mảng lưu lại tọa điểm tổng nhánh của 6 điểm lớn nhất.
            int[] maxScores = new int[6];

            // 3. Tính tổng điểm các điểm lớn nhất của 6 điêm trên.
            for (int i = 0; i < 6; i++) {
                maxScores[i] = TreeChess(indexGreatScore[2 * i], indexGreatScore[2 * i + 1], DiemTong);
            }

            // 4. Tọa độ của ô cần tìm.
            int index = Array.IndexOf(maxScores, maxScores.Max());
            int[] indexGreatestScore = new int[2] { indexGreatScore[2 * index], indexGreatScore[2 * index + 1] };

            return indexGreatestScore;
        }


        // Mục đích Dựa vào điểm tấn công và phòng thủ để tìm ô cờ được cho là tốt nhất.
        // Input:
        // Output: ô cờ được cho là tốt nhất theo thuật toán.
        private int[] ScoreWar() {

            // 1. Để tính toán nhanh thì ta chỉ cần tìm 6 nước lớn nhất.
            int[] indexGreatestScore = new int[2];
            int[] indexGreatScoreTC = FindIndexGreatScore(DiemTanCong, 6);
            int[] indexGreatScorePN = FindIndexGreatScore(DiemPhongNgu, 6);

            // 2. Mảng lưu lại tọa điểm tổng nhánh của 12 điểm lớn nhất (6 điểm tấn công và 6 điểm phòng ngự).
            int[] maxScores = new int[12];

            // 3. Tính tổng điểm các điểm lớn nhất của 6 điêm trên.
            for (int i = 0; i < 6; i++) {
                maxScores[i] = TreeChess(indexGreatScoreTC[2 * i], indexGreatScoreTC[2 * i + 1], DiemTanCong);
                maxScores[i + 6] = TreeChess(indexGreatScorePN[2 * i], indexGreatScorePN[2 * i + 1], DiemPhongNgu);
            }

            // 4. Tọa độ của ô cần tìm.
            int index = Array.IndexOf(maxScores, maxScores.Max());
            if (index < 6) {
                indexGreatestScore = new int[2] { indexGreatScoreTC[2 * index], indexGreatScoreTC[2 * index + 1] };
            } else {
                indexGreatestScore = new int[2] { indexGreatScorePN[2 * (index - 6)], indexGreatScorePN[2 * (index - 6) + 1] };
            }

            return indexGreatestScore;
        }


        // Mục đích: Xét tại một ô cờ, rồi giả định nó thuộc của địch hoặc của mình.
        //           rồi tính tổng các ô cờ lớn nhất.
        // input: Vị trí hiện tại và bảng điểm cần xét
        // outpt: Điểm tổng của vị trí cần xét đó.
        private int TreeChess(int currX, int currY, int[,] scoreBoard) {

            // 1. Cộng điểm của ô đanh xét.
            int sumScore = scoreBoard[currX, currY];

            if (_Level == CaroConst.LevelKho) {
                // 2. Điểm của quyết định của quân tưởng tượng thứ 2.
                double phanTram = 0.6;  // Bằng thêm cách 1 quân cùng loại.

                // 3. Tạo độ 8 ô xung quanh ô cần xét.
                int[] fx = new int[8] { 1, 1, 0, -1, -1, -1, 0, 1 };
                int[] fy = new int[8] { 0, 1, 1, 1, 0, -1, -1, -1 };

                // 4. Giả sử vị trí đang xét là của máy.
                int[] arrayScore = new int[8];
                _MangOCo[currX, currY].SoHuu = _QuanCuaMay;
                ResetScoreBoard(currX, currY, 1);
                for (int i = 0; i < 8; i++) {
                    if (currX + fx[i] > 0 && currX + fx[i] < Board.LineX && currY + fy[i] > 0 && currY + fy[i] < Board.LineY) {
                        arrayScore[i] = scoreBoard[currX + fx[i], currY + fy[i]];
                    }
                }
                sumScore += (int)(arrayScore.Max() * phanTram);

                // 5. Giả sử vị trí đang xét là của địch.
                arrayScore = new int[8];
                _MangOCo[currX, currY].SoHuu = _QuanCuaNguoi;
                ResetScoreBoard(currX, currY, 1);
                for (int i = 0; i < 8; i++) {
                    if (currX + fx[i] > 0 && currX + fx[i] < Board.LineX && currY + fy[i] > 0 && currY + fy[i] < Board.LineY) {
                        arrayScore[i] = scoreBoard[currX + fx[i], currY + fy[i]];
                    }
                }
                sumScore += (int)(arrayScore.Max() * phanTram);

                // 6.Trả lại vết.
                _MangOCo[currX, currY].SoHuu = CaroConst.KoSoHuu;
                ResetScoreBoard(1, 1, 31);
            }

            return sumScore;
        }

        #endregion


        #region Duyệt quân và tính điểm.

        // Mục đích: Duyệt điểm theo hàng dòng, cột, chéo chính, chéo phụ.
        // input: Vị trí hiện tại và sở hưu của quân cần xét.
        // output: Điểm của ô cờ đang xét.

        private int DiemDong(int currX, int currY, string quanTa, int[] arrayScore) {

            // 1. Đếm số quân địch và quân ta.                   
            int[] cntQuanCo = new int[4];
            int[] cntQuanCoTrai = Dong(-currX, currY, quanTa);
            int[] cntQuanCoPhai = Dong(currX, currY, quanTa);
            for (int i = 0; i < 4; i++) {
                cntQuanCo[i] = cntQuanCoTrai[i] + cntQuanCoPhai[i];
            }

            return DanhGiaDiemOCo(cntQuanCo, arrayScore);
        }

        private int DiemCot(int currX, int currY, string quanTa, int[] arrayScore) {

            // 1. Đếm số quân địch và quân ta.                     
            int[] cntQuanCo = new int[4];
            int[] cntQuanCoLen = Cot(currX, -currY, quanTa);
            int[] cntQuanCoXuong = Cot(currX, currY, quanTa);
            for (int i = 0; i < 4; i++) {
                cntQuanCo[i] = cntQuanCoLen[i] + cntQuanCoXuong[i];
            }

            return DanhGiaDiemOCo(cntQuanCo, arrayScore);
        }

        private int DiemCheoChinh(int currX, int currY, string quanTa, int[] arrayScore) {

            // 1. Đếm số quân địch và quân ta.                      
            int[] cntQuanCo = new int[4];
            int[] cntQuanCoLen = CheoChinh_CheoPhu(-currX, -currY, quanTa);
            int[] cntQuanCoXuong = CheoChinh_CheoPhu(currX, currY, quanTa);
            for (int i = 0; i < 4; i++) {
                cntQuanCo[i] = cntQuanCoLen[i] + cntQuanCoXuong[i];
            }

            return DanhGiaDiemOCo(cntQuanCo, arrayScore);
        }

        private int DiemCheoPhu(int currX, int currY, string quanTa, int[] arrayScore) {

            // 1. Đếm số quân địch và quân ta.                     
            int[] cntQuanCo = new int[4];
            int[] cntQuanCoLen = CheoChinh_CheoPhu(currX, -currY, quanTa);
            int[] cntQuanCoXuong = CheoChinh_CheoPhu(-currX, currY, quanTa);
            for (int i = 0; i < 4; i++) {
                cntQuanCo[i] = cntQuanCoLen[i] + cntQuanCoXuong[i];
            }

            return DanhGiaDiemOCo(cntQuanCo, arrayScore);
        }



        // Mục đích: Đánh giá số quân để tính điểm ô cờ.
        // input: Những sổ hữu của các quân theo hàng, cột, chéo chính, chéo phụ.
        // output: Điểm ô cờ đang xét.
        private int DanhGiaDiemOCo(int[] cntQuanCo, int[] arrayScore) {

            // [0] là quân của ta.
            // [1] là quân của địch.
            // [2] là quân của ta cách.
            // [3] là quân của địch cách.

            // 1. Những ô cờ trống theo chiều dòng chắc chắn ko chiến thắng thì cho điểm khởi tạo.
            if (cntQuanCo[1] == 2 || (cntQuanCo[0] <= 3 && cntQuanCo[1] == 1 && cntQuanCo[3] == 1)
                || (cntQuanCo[0] <= 2 && cntQuanCo[3] == 2)) {
                return CaroConst.DiemKhoiTao;
            }

            // 2. Điểm dự vào số quân địch vào ta.
            if (cntQuanCo[0] >= 5) {
                cntQuanCo[0] = 5;
            }
            return (int)(arrayScore[cntQuanCo[0]] * DanhGiaPhanTramOCo(cntQuanCo));
        }



        // Mục đích: Đánh giá những quân chặn quân của mình.
        // input: Mảng số lượng quân chặn.
        // outpt: Phần trăm nhân theo theo điểm ô cờ.
        private double DanhGiaPhanTramOCo(int[] cntQuanCo) {
            double phanTram = 1;
            /*
             * Cách tính:
             * []xx = []xxxo = oxx[] x --> 1 = 4 - 4x = 1 + z - y
             * xxx[] o = xx[] x --> 4 - 4y = 1 + z         
             *  x = 0.75
             *  y = z = 0.6
             * Gọi điểm phần trăm: 
             *  Chặn 1 là x. 
             *  Chặn cách 1 là y. 
             *  Thêm cách 1 là z. 
             *  Các điểm chặn cách hoặc thêm cách 2 thì x 15% điểm 1.
             */
            // Không áp dụng cách tính điểm đối với 4 con liên tiếp trở lên.
            if (cntQuanCo[0] >= 4) { return phanTram; }

            if (cntQuanCo[1] == 1) { phanTram -= 0.75; } 
            if (cntQuanCo[3] == 1) { phanTram -= 0.6; } 
            if (cntQuanCo[3] == 2) { phanTram -= 0.69; } 
            if (cntQuanCo[2] == 1) { phanTram += 0.6; }
            if (cntQuanCo[2] == 2) { phanTram += 0.69; }
            return phanTram;
        }



        // Mục đích: Đếm số quân của địch, ta theo hàng dòng, cột, chéo chính, chéo phụ.
        // input: Vị trị và sở hữu của quân cần đếm.
        // output: Mảng quân cờ chưa số quân cờ theo hàng, cột, chéo chính, chéo phụ

        private int[] Dong(int currX, int currY, string quanTa) {

            // 1. Khởi tạo quân ban đầu trước khi vào đếm.
            int currTa = 0;
            int currDich = 0;
            int currDichCach = 0;
            int currTaCach = 0;
            string quanDich = quanTa == CaroConst.QuanX ? CaroConst.QuanO : CaroConst.QuanX;

            // 2. Duyệt lên xuống, trái phải.
            for (int dem = 1; dem < 6 && Math.Abs(currX + dem) > 0 && Math.Abs(currX + dem) < Board.LineX; dem++) {
                // 1. Gặp quân của mình thì cộng thêm và duyệt tiếp.
                if (_MangOCo[Math.Abs(currX + dem), currY].SoHuu == quanTa) {
                    currTa++;
                }

                // 2. Gặp quân địch thì cộng thêm và thoát.
                if (_MangOCo[Math.Abs(currX + dem), currY].SoHuu == quanDich) {
                    currDich++;
                    break;
                }

                // 3. Gặp ô trống thì thoát, trước khi thoát thì xem ô kế tiếp là ô của quân nào.
                if (_MangOCo[Math.Abs(currX + dem), currY].SoHuu == CaroConst.KoSoHuu) {
                    if (Math.Abs(currX + dem + 1) > 0 && Math.Abs(currX + dem + 1) < Board.LineX) {
                        if (_MangOCo[Math.Abs(currX + dem + 1), currY].SoHuu == quanTa) { currTaCach++; }
                        if (_MangOCo[Math.Abs(currX + dem + 1), currY].SoHuu == quanDich) { currDichCach++; }
                    }
                    break;
                }
            }

            return new int[4] { currTa, currDich, currTaCach, currDichCach };
        }

        private int[] Cot(int currX, int currY, string quanTa) {

            // 1. Khởi tạo quân ban đầu trước khi vào đếm.
            int currTa = 0;
            int currDich = 0;
            int currDichCach = 0;
            int currTaCach = 0;
            string quanDich = quanTa == CaroConst.QuanX ? CaroConst.QuanO : CaroConst.QuanX;

            // 2. Duyệt lên xuống, trái phải.
            for (int dem = 1; dem < 6 && Math.Abs(currY + dem) > 0 && Math.Abs(currY + dem) < Board.LineY; dem++) {
                // 1. Gặp quân của mình thì cộng thêm và duyệt tiếp.
                if (_MangOCo[currX, Math.Abs(currY + dem)].SoHuu == quanTa) {
                    currTa++;
                }

                // 2. Gặp quân địch thì cộng thêm và thoát.
                if (_MangOCo[currX, Math.Abs(currY + dem)].SoHuu == quanDich) {
                    currDich++;
                    break;
                }

                // 3. Gặp ô trống thì thoát, trước khi thoát thì xem ô kế tiếp là ô của quân nào.
                if (_MangOCo[currX, Math.Abs(currY + dem)].SoHuu == CaroConst.KoSoHuu) {
                    if (Math.Abs(currY + dem + 1) > 0 && Math.Abs(currY + dem + 1) < Board.LineY) {
                        if (_MangOCo[currX, Math.Abs(currY + dem + 1)].SoHuu == quanTa) { currTaCach++; }
                        if (_MangOCo[currX, Math.Abs(currY + dem + 1)].SoHuu == quanDich) { currDichCach++; }
                    }
                    break;
                }
            }

            return new int[4] { currTa, currDich, currTaCach, currDichCach };
        }

        private int[] CheoChinh_CheoPhu(int currX, int currY, string quanTa) {

            // 1. Khởi tạo quân ban đầu trước khi vào đếm.
            int currTa = 0;
            int currDich = 0;
            int currDichCach = 0;
            int currTaCach = 0;
            string quanDich = quanTa == CaroConst.QuanX ? CaroConst.QuanO : CaroConst.QuanX;

            // 2. Duyệt lên xuống, trái phải.
            for (int dem = 1; dem < 6 && Math.Abs(currX + dem) > 0 && Math.Abs(currX + dem) < Board.LineX 
                && Math.Abs(currY + dem) > 0 && Math.Abs(currY + dem) < Board.LineY; dem++) {
                // 1. Gặp quân của mình thì cộng thêm và duyệt tiếp.
                    if (_MangOCo[Math.Abs(currX + dem), Math.Abs(currY + dem)].SoHuu == quanTa) {
                    currTa++;
                }

                // 2. Gặp quân địch thì cộng thêm và thoát.
                if (_MangOCo[Math.Abs(currX + dem), Math.Abs(currY + dem)].SoHuu == quanDich) {
                    currDich++;
                    break;
                }

                // 3. Gặp ô trống thì thoát, trước khi thoát thì xem ô kế tiếp là ô của quân nào.
                if (_MangOCo[Math.Abs(currX + dem), Math.Abs(currY + dem)].SoHuu == CaroConst.KoSoHuu) {
                    if (Math.Abs(currX + dem + 1) > 0 && Math.Abs(currX + dem + 1) < Board.LineX 
                        && Math.Abs(currY + dem + 1) > 0 && Math.Abs(currY + dem + 1) < Board.LineY) {
                        if (_MangOCo[Math.Abs(currX + dem + 1), Math.Abs(currY + dem + 1)].SoHuu == quanTa) { currTaCach++; }
                        if (_MangOCo[Math.Abs(currX + dem + 1), Math.Abs(currY + dem + 1)].SoHuu == quanDich) { currDichCach++; }
                    }
                    break;
                }
            }

            return new int[4] { currTa, currDich, currTaCach, currDichCach };
        }

        #endregion

        #endregion
    }
}
