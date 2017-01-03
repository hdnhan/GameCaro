namespace GameCaro
{
    partial class frmExit
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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.lblCanhBao1 = new System.Windows.Forms.Label();
            this.lblCanhBao2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(53, 70);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(80, 30);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Location = new System.Drawing.Point(139, 70);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(80, 30);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblCanhBao1
            // 
            this.lblCanhBao1.AutoSize = true;
            this.lblCanhBao1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanhBao1.Location = new System.Drawing.Point(12, 19);
            this.lblCanhBao1.Name = "lblCanhBao1";
            this.lblCanhBao1.Size = new System.Drawing.Size(0, 17);
            this.lblCanhBao1.TabIndex = 2;
            // 
            // lblCanhBao2
            // 
            this.lblCanhBao2.AutoSize = true;
            this.lblCanhBao2.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanhBao2.Location = new System.Drawing.Point(10, 35);
            this.lblCanhBao2.Name = "lblCanhBao2";
            this.lblCanhBao2.Size = new System.Drawing.Size(0, 17);
            this.lblCanhBao2.TabIndex = 3;
            // 
            // frmExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(277, 119);
            this.ControlBox = false;
            this.Controls.Add(this.lblCanhBao2);
            this.Controls.Add(this.lblCanhBao1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Name = "frmExit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exit";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmExit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Label lblCanhBao1;
        private System.Windows.Forms.Label lblCanhBao2;
    }
}