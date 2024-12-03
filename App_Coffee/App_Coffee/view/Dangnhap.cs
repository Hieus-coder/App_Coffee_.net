﻿using App_Coffee.Controller;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App_Coffee.view
{
    public partial class Dangnhap : Form
    {
        private AccountController accController;
        public static string userRole = ""; // Biến tĩnh lưu role của người dùng (Admin hay User)

        public Dangnhap()
        {
            InitializeComponent();
            accController = new AccountController();
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txtTaikhoan.Text.Trim();
            string password = txtMatkhau.Text.Trim();

            // Kiểm tra tài khoản và mật khẩu
            if (accController.CheckUserCredentials(username, password))
            {
                // Lưu role của người dùng (Admin hay User) vào biến tĩnh
                userRole = accController.IsAdmin(username) ? "Admin" : "User";

                // Hiển thị thông báo và chuyển đến form Datban
                MessageBox.Show("Đăng nhập thành công!");

                Datban frm = new Datban(); // Chuyển sang form Datban
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
        }

        private void btnDangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangki dangki = new Dangki();
            dangki.Show();
        }
    }
}
