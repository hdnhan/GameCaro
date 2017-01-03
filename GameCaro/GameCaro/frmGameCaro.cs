using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GameCaro {
    public partial class FrmGameCaro : Form {

        private CaroChess Caro;
        private Graphics Grap;
        public int Second; // Nhận số giây được người dùng thiết lập.
        public int Minute; // Nhận số phút được người dùng thiết lập.
        public bool SetTime; // Xem bàn cờ có đặt thời gian không (true: có cài đặt, false: không cài đặt).
        private int RunSecond; // Nhận số giây khi chạy đồng hồ đếm ngược.
        private int RunMinute; // Nhận số phút khi chạy đồng hồ đếm ngược.     
        private Stack<int> OldPoint; // Lưu tọa độ điểm cũ khi di chuyển chuột.
        private bool CheckClickMouse; // Khi click hợp lệ, tức là vẽ được quân cờ, mục đích để vẽ lại quân cờ.
        private bool ChangeTextMusic; // Thay đổi tên ở button music.
        private bool SetThongBaoNguyHiem; // Ván đấu có thông báo nếu có nguy hiểm ko?
        SoundPlayer Sound = new SoundPlayer(Properties.Resources.KissTheRain);

        public FrmGameCaro() {
            InitializeComponent();
            Caro = new CaroChess();
            Caro.KhoiTaoMangSoHuu();
            Grap = pnlBanCo.CreateGraphics(); // Tạo graphics trên bàn cờ.     
            Minute = Second = 0; // Mặc định là ko tính, cái này để hiện 00 trên bàn cờ.
            SetTime = false; // Mặc định là không đặt thời gian ván chơi.
            OldPoint = new Stack<int>();
            CheckClickMouse = false; // Mới vào trận đấu nên biến này bằng false. 
            ChangeTextMusic = true;
            SetThongBaoNguyHiem = false; // Mặc định là không thông báo.
        }


        // Vẽ bàn cờ.
        private void pnlBanCo_Paint(object sender, PaintEventArgs e) {
            try {
                // 1. Vẽ các đường tạo thành ô cờ.
                Caro.VeBanCo(Grap);

                // 2. Vẽ lại quân cờ khi bàn cờ bị che khuất.
                Caro.VeLaiQuanCo(Grap);
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }

        }


        // Chế độ chơi player vs player.
        private void btnPlayervsPlayer_Click(object sender, EventArgs e) {
            try {
                // 1. Đưa về trạng thái ban đầu             
                RunMinute = Minute;
                RunSecond = Second;

                // 2. Xem quân nào đi trước thì đếm người quân đó.
                if (SetTime) {
                    if (Caro.QuanXDanhTruoc) {
                        timerX.Start();
                    } else {
                        timerO.Start();
                    }
                }

                // 3. Khởi động bàn cờ player vs player
                Caro.StartPlayervsPlayer(Grap);
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        //  Chế độ chời player vs computer.
        private void btnPlayervsComputer_Click(object sender, EventArgs e) {
            try {
                // 1. Đưa về trạng thái ban đầu
                ChangeTime(CaroConst.KoSoHuu);

                Caro.StartPlayerVsComputer(Grap);

                // Trận đấu có tính thời gian không.
                if (SetTime) {
                    // Xem quân nào đi trước thì đếm người quân đó.         
                    if (Caro.QuanCuaMay == CaroConst.QuanO) {
                        ChangeTime(CaroConst.QuanX);
                    } else {
                        ChangeTime(CaroConst.QuanO);
                    }
                }
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Khi click chuột vào bàn cờ thì:
        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e) {
            try {
                // 1. Kiểm tra việc click đó có hợp lệ hay không (false: không hợp lệ, true: hợp lệ).
                if (!Caro.CheckClickMouse(e.X, e.Y)) { return; }

                // 2. Vẽ quân cờ và trạng thái click mouse.
                Caro.VeQuanCo(Grap, e.X, e.Y);
                CheckClickMouse = true;

                // 3. Dừng thơi gian đếm ngược
                ChangeTime(CaroConst.KoSoHuu);

                // 4. Kiêm tra trạng thái chiến thắng(kiểm tra thời gian(kiểm tra chỗ khác vì phải click nữa mới kiểm tra), kiểm tra quân cờ).
                if (Caro.KiemTraChienThang()) {

                    // Dừng đếm ngược thời gian
                    timerX.Stop();
                    timerO.Stop();

                    // Thông báo kết quả.
                    Caro.ThongBaoKetQua();

                    // Đưa bàn cờ về trạng thái chưa sẵn sàng.
                    Caro.SanSang = false;
         
                    return;
                }

                // 5. Tính lại điểm bàn cờ nếu ở chế độ chơi người với máy (CheDoChoi = 2).
                if (Caro.CheDoChoi == CaroConst.PlayervsComputer || SetThongBaoNguyHiem) {
                    Caro.ResetScoreBoard(e.X / OCo.DAIX, e.Y / OCo.DAIY, CaroConst.MaxResetXY);
                }


                // 6. Thông báo nguy hiểm nếu có.
                if (Caro.CoNguyHiem(e.X / OCo.DAIX, e.Y / OCo.DAIY, Caro.LuotDi) && SetThongBaoNguyHiem) {
                    lblCoNguyHiem.Text = "Có nguy hiểm!";
                } else {
                    lblCoNguyHiem.Text = "";
                }


                // 7. Chuyển lượt đi (cho máy hoặc là cho người) và chuyển đếm ngược thời gian (nếu có)
                ChangeMove(Caro.LuotDi);

            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Đi lại nước cờ khi đi nhầm
        private void btnUndo_Click(object sender, EventArgs e) {
            try {
                // 1. Khi bàn cờ chưa sẵn sàng (vừa kết thúc hoặc mới mở,....) thì không được undo
                if (!Caro.SanSang) {
                    MessageBox.Show("    Ván đấu chưa diễn ra!");
                }

                // 2. Ngược lại thì đi lại
                if (Caro.SanSang) {
                    Caro.Undo(Grap);
                }

            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Đưa bàn cờ về trạng thái bàn cờ như lúc mới mở.
        private void btnResetGame_Click(object sender, EventArgs e) {
            try {

                // 1. Dừng tất cả đồng hồ đếm ngược và hiện thị thời gian mặc định.
                timerX.Stop();
                timerO.Stop();
                Caro.HienThiThoiGian(ref Minute, ref Second, lblPhutX, lblGiayX);
                Caro.HienThiThoiGian(ref Minute, ref Second, lblPhutO, lblGiayO);


                // 2. Chuyển bàn sang trạng thái chưa sẵn sàng.
                Caro.SanSang = false;

                // 3. Xóa tất cả các quân (nếu có) trên bàn cờ.
                Caro.XoaTatCaQuanCo(Grap);

            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Thoát ứng dụng.
        private void btnExit_Click(object sender, EventArgs e) {
            try {
                // Truyền biến theo constructor
                frmExit exit = new frmExit(this, Caro.SanSang);
                exit.ShowDialog();
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Trợ giúp người chơi.
        private void btnHelp_Click(object sender, EventArgs e) {
            try {
                frmHelp help = new frmHelp();
                help.ShowDialog();
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Thay đổi thứ tự đi của quân cờ và máy.
        private void btnOptions_Click(object sender, EventArgs e) {
            try {
                // Nếu trận đấu đang diễn ra thì không cho thay đổi
                if (!Caro.SanSang) {
                    // Truyền biến theo constructor (mục đích để xem sự thay đổi trước đó) và nhận giá trị của biến theo con delegate
                    frmOptions options = new frmOptions(Caro.Level, Caro.LevelWar, Caro.QuanXDanhTruoc, Caro.MayDiTruoc, Minute, Second, SetTime, Caro.ConTroChuot, SetThongBaoNguyHiem);
                    options.myOptions = new frmOptions.ReceiveOptions(Caro.SetOptions);
                    options.mySetTime = new frmOptions.ReceiveSetTime(setTime);
                    options.ShowDialog();
                } else {
                    MessageBox.Show("\t             Ván đấu chưa kết thúc!\n\n    Để thiết lập hãy chơi hết ván hoặc bấm Reset Game");
                }
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Nhận thời gian thiết lập của trận đấu
        public void setTime(int minute, int second, bool setTime, bool setNoti) {
            Minute = minute;
            Second = second;
            SetTime = setTime;
            SetThongBaoNguyHiem = setNoti;

            if (minute == 0 && second == 0) {
                SetTime = false;
            }

            Caro.HienThiThoiGian(ref minute, ref second, lblPhutX, lblGiayX);
            Caro.HienThiThoiGian(ref minute, ref second, lblPhutO, lblGiayO);
        }


        // Hiện tọa độ ô con trỏ chuột và tô màu ô đó nếu đủ điều kiện
        private void pnlBanCo_MouseMove(object sender, MouseEventArgs e) {
            try {
                // 1. Hiện thị tọa độ ô của con trỏ chuột đang nằm.
                int x = e.X / OCo.DAIX;
                int y = e.Y / OCo.DAIY;

                if (e.X % OCo.DAIX == 0 || x <= 0 || x >= 31) { lblX.Text = "x"; } else { lblX.Text = x.ToString(); }
                if (e.Y % OCo.DAIY == 0 || y <= 0 || y >= 31) { lblY.Text = "y"; } else { lblY.Text = y.ToString(); }
                if (Caro.ConTroChuot > 0) {
                    int oldX;
                    int oldY;
                    // 2. Xóa ô cũ vừa đi qua (nhưng nếu click rồi thì vẽ lại)
                    if (OldPoint.Count > 0 && Caro.SanSang) {
                        oldX = OldPoint.Pop();
                        oldY = OldPoint.Pop();
                        Caro.XoaQuanCo(Grap, new Point(oldX, oldY), new SolidBrush(Color.GhostWhite));
                        // 2.1. Nếu click mouse (tức là đánh thì vẽ hẳn luôn)
                        if (CheckClickMouse && Caro.MangOCo[oldX / OCo.DAIX, oldY / OCo.DAIY].SoHuu != CaroConst.KoSoHuu) {
                            if (Caro.CheDoChoi == 1) {
                                if (Caro.LuotDi == "x") {
                                    Caro.VeQuanCoChay(Grap, oldX, oldY, Caro.QuanCoO);
                                } else {
                                    Caro.VeQuanCoChay(Grap, oldX, oldY, Caro.QuanCoX);
                                }
                            }
                            if (Caro.CheDoChoi == 2) {
                                if (Caro.QuanCuaMay == "x") {
                                    Caro.VeQuanCoChay(Grap, oldX, oldY, Caro.QuanCoO);
                                } else {
                                    Caro.VeQuanCoChay(Grap, oldX, oldY, Caro.QuanCoX);
                                }
                            }
                            CheckClickMouse = false;
                        }
                    }

                    // 3. Hiện màu mè ô đang đi qua (Hiện quân chuẩn bị đánh).
                    if (x > 0 && x < 31 && y > 0 && y < 31 && Caro.MangOCo[x, y].SoHuu == "" && Caro.SanSang) {

                        // 2.1. Tọa độ góc trên trái  của ô cờ.
                        int newX = x * OCo.DAIX;
                        int newY = y * OCo.DAIY;

                        // 2.2. Vẽ lại ô vừa mà con trỏ chuột đang nằm.
                        Caro.XoaQuanCo(Grap, new Point(newX, newY), new SolidBrush(Color.DodgerBlue));

                        // 2.3. Thêm tọa độ vừa đi qua.
                        OldPoint.Push(newY);
                        OldPoint.Push(newX);
                        if (Caro.ConTroChuot > 1) {
                            // 2.4. Hình quân hiện tại đang đánh.
                            if (Caro.LuotDi == "x") {
                                Caro.VeQuanCoChay(Grap, newX, newY, Caro.QuanCoX);
                            } else {
                                Caro.VeQuanCoChay(Grap, newX, newY, Caro.QuanCoO);
                            }
                        }
                    }
                }
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Chơi nhạc.
        private void btnMusic_Click(object sender, EventArgs e) {
            if (ChangeTextMusic) {
                btnMusic.Text = "Stop Music";
                Sound.Play();
                ChangeTextMusic = false;
            } else {
                btnMusic.Text = "Play Music";
                Sound.Stop();
                ChangeTextMusic = true;
            }
        }


        // Đồng hồ đếm ngược của quân X.
        private void timerX_Tick(object sender, EventArgs e) {
            try {
                // 1. Hết thời gian suy nghĩ và gười vừa đi thua vì hết thời gian suy nghĩ.
                if (RunMinute == 0 && RunSecond == 0) {

                    // Dừng thời gian đếm ngược.
                    timerX.Stop();

                    // Người chơi x suy nghĩ hết thời gian nên người chơi o thắng.
                    Caro.LuotDi = "o";

                    // Thông báo kết quả
                    Caro.ThongBaoKetQua();

                    // Đưa bàn cờ về trạng thái chưa sẵn sàng(tránh undo, ...).
                    Caro.SanSang = false;

                    return;
                }
                RunSecond--;
                // 2. Nếu chưa hết thời gian suy nghĩ thì đếm ngược tiếp.
                Caro.HienThiThoiGian(ref RunMinute, ref RunSecond, lblPhutX, lblGiayX);
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Đồng hồ đếm ngược của quân O.
        private void timerO_Tick(object sender, EventArgs e) {
            try {
                // 1. Hết thời gian suy nghĩ và gười vừa đi thua vì hết thời gian suy nghĩ.
                if (RunMinute == 0 && RunSecond == 0) {

                    // Dừng thời gian đếm ngược.
                    timerO.Stop();

                    // Người chơi o suy nghĩ hết thời gian nên người chơi x chiến thắng.
                    Caro.LuotDi = "x";

                    // Thông báo kết quả
                    Caro.ThongBaoKetQua();

                    // Đưa bàn cờ về trạng thái chưa sẵn sàng(tránh undo, ...).
                    Caro.SanSang = false;
                    return;
                }
                RunSecond--;
                // 2. Nếu chưa hết thời gian suy nghĩ thì đếm ngược tiếp.
                Caro.HienThiThoiGian(ref RunMinute, ref RunSecond, lblPhutO, lblGiayO);
            } catch (Exception) {
                MessageBox.Show("Có lỗi!!!");
                throw;
            }
        }


        // Chuyển lượt đi cho đối thủ khi mình đánh thành công.
        private void ChangeMove(string luotDi) {

            // 1. Luợt đi cần chuyển vào quân.
            string noLuotDi = luotDi == CaroConst.QuanX ? CaroConst.QuanO : CaroConst.QuanX;

            // 2. Chuyển lượt đi và đảo thời gian đếm ngược
            Caro.LuotDi = noLuotDi;

            // Ở chế độ chơi người với máy.
            if (Caro.CheDoChoi == CaroConst.PlayervsComputer) {
                Caro.ComputerPlay(Grap);
                // Kiểm tra chiến thắng.
                if (Caro.KiemTraChienThang()) {

                    // Dừng đếm ngược thời gian
                    timerX.Stop();
                    timerO.Stop();

                    // Thông báo kết quả.
                    Caro.ThongBaoKetQua();

                    // Đưa bàn cờ về trạng thái chưa sẵn sàng.
                    Caro.SanSang = false;                   

                    return;

                }

                // Thông báo nếu có nguyên hiểm.
                if (Caro.CoNguyeHiem && SetThongBaoNguyHiem) {
                    lblCoNguyHiem.Text = "Có nguy hiểm!";
                } else {
                    lblCoNguyHiem.Text = "";
                }

                // Chuyển lượt đi và đảo thời gian đếm ngược.
                Caro.LuotDi = luotDi;
                if (SetTime) {
                    ChangeTime(luotDi);
                }
            }
            // Ở chế độ chơi người chơi với người chơi.
            if (Caro.CheDoChoi == CaroConst.PlayervsPlayer && SetTime) {
                ChangeTime(noLuotDi);
            }

        }


        // Chạy đếm ngược thời gian của mình và hiện thời gian của đối thủ về trạng thái đầu.
        private void ChangeTime(string luotDi) {
            timerX.Stop();
            timerO.Stop();
            RunMinute = Minute;
            RunSecond = Second;
            if (Caro.LuotDi == CaroConst.QuanX && SetTime) {
                Caro.HienThiThoiGian(ref Minute, ref Second, lblPhutX, lblGiayX);
                timerX.Start();
                Caro.HienThiThoiGian(ref Minute, ref Second, lblPhutO, lblGiayO);
            } else if (Caro.LuotDi == CaroConst.QuanO && SetTime) {
                Caro.HienThiThoiGian(ref Minute, ref Second, lblPhutO, lblGiayO);
                timerO.Start();
                Caro.HienThiThoiGian(ref Minute, ref Second, lblPhutX, lblGiayX);
            } else {
                Caro.HienThiThoiGian(ref Minute, ref Second, lblPhutO, lblGiayO);
                Caro.HienThiThoiGian(ref Minute, ref Second, lblPhutX, lblGiayX);

            }
        }
    }
}
