﻿namespace App_Coffee.view
{
    partial class Quanlydouong
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
            panel1 = new Panel();
            btnDangxuat = new Button();
            btnNhanvien = new Button();
            btnDoanhthu = new Button();
            btnDatmon = new Button();
            btnDatban = new Button();
            txtUser = new Label();
            btnDouong = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDouong);
            panel1.Controls.Add(btnDangxuat);
            panel1.Controls.Add(btnNhanvien);
            panel1.Controls.Add(btnDoanhthu);
            panel1.Controls.Add(btnDatmon);
            panel1.Controls.Add(btnDatban);
            panel1.Controls.Add(txtUser);
            panel1.Location = new Point(3, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 639);
            panel1.TabIndex = 2;
            // 
            // btnDangxuat
            // 
            btnDangxuat.Location = new Point(76, 607);
            btnDangxuat.Name = "btnDangxuat";
            btnDangxuat.Size = new Size(94, 29);
            btnDangxuat.TabIndex = 5;
            btnDangxuat.Text = "Đăng xuất";
            btnDangxuat.UseVisualStyleBackColor = true;
            // 
            // btnNhanvien
            // 
            btnNhanvien.Location = new Point(0, 388);
            btnNhanvien.Name = "btnNhanvien";
            btnNhanvien.Size = new Size(259, 61);
            btnNhanvien.TabIndex = 4;
            btnNhanvien.Text = "Nhân viên";
            btnNhanvien.UseVisualStyleBackColor = true;
            // 
            // btnDoanhthu
            // 
            btnDoanhthu.Location = new Point(0, 331);
            btnDoanhthu.Name = "btnDoanhthu";
            btnDoanhthu.Size = new Size(259, 61);
            btnDoanhthu.TabIndex = 3;
            btnDoanhthu.Text = "Doanh thu";
            btnDoanhthu.UseVisualStyleBackColor = true;
            // 
            // btnDatmon
            // 
            btnDatmon.Location = new Point(0, 277);
            btnDatmon.Name = "btnDatmon";
            btnDatmon.Size = new Size(259, 58);
            btnDatmon.TabIndex = 2;
            btnDatmon.Text = "Đặt món";
            btnDatmon.UseVisualStyleBackColor = true;
            // 
            // btnDatban
            // 
            btnDatban.Location = new Point(0, 218);
            btnDatban.Name = "btnDatban";
            btnDatban.Size = new Size(259, 63);
            btnDatban.TabIndex = 1;
            btnDatban.Text = "Đặt bàn";
            btnDatban.UseVisualStyleBackColor = true;
            // 
            // txtUser
            // 
            txtUser.AutoSize = true;
            txtUser.Location = new Point(107, 36);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(49, 20);
            txtUser.TabIndex = 0;
            txtUser.Text = "Name";
            // 
            // btnDouong
            // 
            btnDouong.Location = new Point(0, 446);
            btnDouong.Name = "btnDouong";
            btnDouong.Size = new Size(259, 61);
            btnDouong.TabIndex = 6;
            btnDouong.Text = "Đồ uống";
            btnDouong.UseVisualStyleBackColor = true;
            // 
            // Quanlydouong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 649);
            Controls.Add(panel1);
            Name = "Quanlydouong";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnDouong;
        private Button btnDangxuat;
        private Button btnNhanvien;
        private Button btnDoanhthu;
        private Button btnDatmon;
        private Button btnDatban;
        private Label txtUser;
    }
}