namespace GameCaro
{
    partial class FrmGameCaro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGameCaro));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnResetGame = new System.Windows.Forms.Button();
            this.btnPlayervsPlayer = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnPlayervsComputer = new System.Windows.Forms.Button();
            this.pnlBanCo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureO = new System.Windows.Forms.PictureBox();
            this.lblThoiGianSuyNghi = new System.Windows.Forms.Label();
            this.pictureX = new System.Windows.Forms.PictureBox();
            this.lblPhutX = new System.Windows.Forms.Label();
            this.lblHaiChamX = new System.Windows.Forms.Label();
            this.timerX = new System.Windows.Forms.Timer(this.components);
            this.timerO = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGiayX = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblHaiChamO = new System.Windows.Forms.Label();
            this.lblGiayO = new System.Windows.Forms.Label();
            this.lblPhutO = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.btnOpitions = new System.Windows.Forms.Button();
            this.btnMusic = new System.Windows.Forms.Button();
            this.lblCoNguyHiem = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureX)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 158);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnResetGame
            // 
            this.btnResetGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnResetGame.BackColor = System.Drawing.SystemColors.Control;
            this.btnResetGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetGame.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetGame.Location = new System.Drawing.Point(11, 436);
            this.btnResetGame.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnResetGame.Name = "btnResetGame";
            this.btnResetGame.Size = new System.Drawing.Size(224, 35);
            this.btnResetGame.TabIndex = 1;
            this.btnResetGame.Text = "Reset Game";
            this.btnResetGame.UseVisualStyleBackColor = false;
            this.btnResetGame.Click += new System.EventHandler(this.btnResetGame_Click);
            // 
            // btnPlayervsPlayer
            // 
            this.btnPlayervsPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlayervsPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayervsPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayervsPlayer.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayervsPlayer.Location = new System.Drawing.Point(11, 477);
            this.btnPlayervsPlayer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPlayervsPlayer.Name = "btnPlayervsPlayer";
            this.btnPlayervsPlayer.Size = new System.Drawing.Size(224, 35);
            this.btnPlayervsPlayer.TabIndex = 1;
            this.btnPlayervsPlayer.Text = "Player vs Player";
            this.btnPlayervsPlayer.UseVisualStyleBackColor = false;
            this.btnPlayervsPlayer.Click += new System.EventHandler(this.btnPlayervsPlayer_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUndo.BackColor = System.Drawing.SystemColors.Control;
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndo.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Location = new System.Drawing.Point(123, 559);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(112, 35);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnPlayervsComputer
            // 
            this.btnPlayervsComputer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlayervsComputer.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayervsComputer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayervsComputer.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayervsComputer.Location = new System.Drawing.Point(11, 518);
            this.btnPlayervsComputer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPlayervsComputer.Name = "btnPlayervsComputer";
            this.btnPlayervsComputer.Size = new System.Drawing.Size(224, 35);
            this.btnPlayervsComputer.TabIndex = 2;
            this.btnPlayervsComputer.Text = "Player vs Computer";
            this.btnPlayervsComputer.UseVisualStyleBackColor = false;
            this.btnPlayervsComputer.Click += new System.EventHandler(this.btnPlayervsComputer_Click);
            // 
            // pnlBanCo
            // 
            this.pnlBanCo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBanCo.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlBanCo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBanCo.ForeColor = System.Drawing.Color.Black;
            this.pnlBanCo.Location = new System.Drawing.Point(249, 8);
            this.pnlBanCo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlBanCo.Name = "pnlBanCo";
            this.pnlBanCo.Size = new System.Drawing.Size(704, 704);
            this.pnlBanCo.TabIndex = 3;
            this.pnlBanCo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBanCo_Paint);
            this.pnlBanCo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBanCo_MouseClick);
            this.pnlBanCo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBanCo_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lblMSSV);
            this.panel2.Controls.Add(this.lblLop);
            this.panel2.Controls.Add(this.lblTacGia);
            this.panel2.Location = new System.Drawing.Point(11, 178);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 77);
            this.panel2.TabIndex = 4;
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSSV.Location = new System.Drawing.Point(35, 51);
            this.lblMSSV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(0, 19);
            this.lblMSSV.TabIndex = 2;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Lucida Calligraphy", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(0, 30);
            this.lblLop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(0, 19);
            this.lblLop.TabIndex = 1;
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTacGia.Location = new System.Drawing.Point(7, 10);
            this.lblTacGia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(207, 57);
            this.lblTacGia.TabIndex = 0;
            this.lblTacGia.Text = "Sinh viên: Hồ Đức Nhân\r\nLớp: KSTN-Toán Tin-K58\r\n    MSSV: 20132843";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(11, 641);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 35);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureO
            // 
            this.pictureO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureO.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureO.BackgroundImage = global::GameCaro.Properties.Resources.o;
            this.pictureO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureO.ErrorImage = null;
            this.pictureO.Location = new System.Drawing.Point(145, 275);
            this.pictureO.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureO.Name = "pictureO";
            this.pictureO.Size = new System.Drawing.Size(40, 40);
            this.pictureO.TabIndex = 5;
            this.pictureO.TabStop = false;
            // 
            // lblThoiGianSuyNghi
            // 
            this.lblThoiGianSuyNghi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblThoiGianSuyNghi.AutoSize = true;
            this.lblThoiGianSuyNghi.BackColor = System.Drawing.SystemColors.Control;
            this.lblThoiGianSuyNghi.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianSuyNghi.Location = new System.Drawing.Point(17, 330);
            this.lblThoiGianSuyNghi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThoiGianSuyNghi.Name = "lblThoiGianSuyNghi";
            this.lblThoiGianSuyNghi.Size = new System.Drawing.Size(208, 17);
            this.lblThoiGianSuyNghi.TabIndex = 6;
            this.lblThoiGianSuyNghi.Text = "   Thời gian suy nghĩ    ";
            // 
            // pictureX
            // 
            this.pictureX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureX.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureX.BackgroundImage = global::GameCaro.Properties.Resources.x;
            this.pictureX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureX.Location = new System.Drawing.Point(55, 275);
            this.pictureX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureX.Name = "pictureX";
            this.pictureX.Size = new System.Drawing.Size(40, 40);
            this.pictureX.TabIndex = 5;
            this.pictureX.TabStop = false;
            // 
            // lblPhutX
            // 
            this.lblPhutX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhutX.AutoSize = true;
            this.lblPhutX.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhutX.Location = new System.Drawing.Point(11, 7);
            this.lblPhutX.Name = "lblPhutX";
            this.lblPhutX.Size = new System.Drawing.Size(36, 26);
            this.lblPhutX.TabIndex = 7;
            this.lblPhutX.Text = "00";
            // 
            // lblHaiChamX
            // 
            this.lblHaiChamX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHaiChamX.AutoSize = true;
            this.lblHaiChamX.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaiChamX.Location = new System.Drawing.Point(40, 6);
            this.lblHaiChamX.Name = "lblHaiChamX";
            this.lblHaiChamX.Size = new System.Drawing.Size(22, 24);
            this.lblHaiChamX.TabIndex = 7;
            this.lblHaiChamX.Text = ":";
            // 
            // timerX
            // 
            this.timerX.Interval = 1000;
            this.timerX.Tick += new System.EventHandler(this.timerX_Tick);
            // 
            // timerO
            // 
            this.timerO.Interval = 1000;
            this.timerO.Tick += new System.EventHandler(this.timerO_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblHaiChamX);
            this.panel1.Controls.Add(this.lblGiayX);
            this.panel1.Controls.Add(this.lblPhutX);
            this.panel1.Location = new System.Drawing.Point(20, 360);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 40);
            this.panel1.TabIndex = 9;
            // 
            // lblGiayX
            // 
            this.lblGiayX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGiayX.AutoSize = true;
            this.lblGiayX.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiayX.Location = new System.Drawing.Point(56, 7);
            this.lblGiayX.Name = "lblGiayX";
            this.lblGiayX.Size = new System.Drawing.Size(36, 26);
            this.lblGiayX.TabIndex = 7;
            this.lblGiayX.Text = "00";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.lblHaiChamO);
            this.panel3.Controls.Add(this.lblGiayO);
            this.panel3.Controls.Add(this.lblPhutO);
            this.panel3.Location = new System.Drawing.Point(123, 360);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 40);
            this.panel3.TabIndex = 9;
            // 
            // lblHaiChamO
            // 
            this.lblHaiChamO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHaiChamO.AutoSize = true;
            this.lblHaiChamO.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaiChamO.Location = new System.Drawing.Point(40, 6);
            this.lblHaiChamO.Name = "lblHaiChamO";
            this.lblHaiChamO.Size = new System.Drawing.Size(22, 24);
            this.lblHaiChamO.TabIndex = 7;
            this.lblHaiChamO.Text = ":";
            // 
            // lblGiayO
            // 
            this.lblGiayO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGiayO.AutoSize = true;
            this.lblGiayO.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiayO.Location = new System.Drawing.Point(56, 7);
            this.lblGiayO.Name = "lblGiayO";
            this.lblGiayO.Size = new System.Drawing.Size(36, 26);
            this.lblGiayO.TabIndex = 7;
            this.lblGiayO.Text = "00";
            // 
            // lblPhutO
            // 
            this.lblPhutO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPhutO.AutoSize = true;
            this.lblPhutO.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhutO.Location = new System.Drawing.Point(11, 7);
            this.lblPhutO.Name = "lblPhutO";
            this.lblPhutO.Size = new System.Drawing.Size(36, 26);
            this.lblPhutO.TabIndex = 7;
            this.lblPhutO.Text = "00";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHelp.BackColor = System.Drawing.SystemColors.Control;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(127, 641);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(112, 35);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblY
            // 
            this.lblY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(199, 686);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(18, 19);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "y";
            // 
            // lblX
            // 
            this.lblX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.Location = new System.Drawing.Point(149, 686);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(18, 19);
            this.lblX.TabIndex = 7;
            this.lblX.Text = "x";
            // 
            // btnOpitions
            // 
            this.btnOpitions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpitions.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpitions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpitions.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpitions.Location = new System.Drawing.Point(11, 559);
            this.btnOpitions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOpitions.Name = "btnOpitions";
            this.btnOpitions.Size = new System.Drawing.Size(112, 35);
            this.btnOpitions.TabIndex = 1;
            this.btnOpitions.Text = "Options";
            this.btnOpitions.UseVisualStyleBackColor = false;
            this.btnOpitions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnMusic
            // 
            this.btnMusic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMusic.BackColor = System.Drawing.SystemColors.Control;
            this.btnMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMusic.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusic.Location = new System.Drawing.Point(11, 600);
            this.btnMusic.Name = "btnMusic";
            this.btnMusic.Size = new System.Drawing.Size(224, 35);
            this.btnMusic.TabIndex = 10;
            this.btnMusic.Text = "Play Music";
            this.btnMusic.UseVisualStyleBackColor = false;
            this.btnMusic.Click += new System.EventHandler(this.btnMusic_Click);
            // 
            // lblCoNguyHiem
            // 
            this.lblCoNguyHiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCoNguyHiem.AutoSize = true;
            this.lblCoNguyHiem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoNguyHiem.Location = new System.Drawing.Point(18, 686);
            this.lblCoNguyHiem.Name = "lblCoNguyHiem";
            this.lblCoNguyHiem.Size = new System.Drawing.Size(0, 19);
            this.lblCoNguyHiem.TabIndex = 7;
            // 
            // FrmGameCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(966, 721);
            this.Controls.Add(this.btnMusic);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblCoNguyHiem);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblThoiGianSuyNghi);
            this.Controls.Add(this.pictureX);
            this.Controls.Add(this.pictureO);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlBanCo);
            this.Controls.Add(this.btnPlayervsComputer);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpitions);
            this.Controls.Add(this.btnPlayervsPlayer);
            this.Controls.Add(this.btnResetGame);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FrmGameCaro";
            this.Text = "Game Caro";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureX)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnResetGame;
        private System.Windows.Forms.Button btnPlayervsPlayer;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnPlayervsComputer;
        private System.Windows.Forms.Panel pnlBanCo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureO;
        private System.Windows.Forms.Label lblThoiGianSuyNghi;
        private System.Windows.Forms.PictureBox pictureX;
        private System.Windows.Forms.Label lblHaiChamX;
        private System.Windows.Forms.Timer timerX;
        private System.Windows.Forms.Timer timerO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblHaiChamO;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnOpitions;
        public System.Windows.Forms.Label lblPhutX;
        public System.Windows.Forms.Label lblGiayX;
        public System.Windows.Forms.Label lblGiayO;
        public System.Windows.Forms.Label lblPhutO;
        private System.Windows.Forms.Button btnMusic;
        private System.Windows.Forms.Label lblCoNguyHiem;
    }
}

