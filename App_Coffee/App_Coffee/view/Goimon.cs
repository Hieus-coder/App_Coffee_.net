﻿using App_Coffee.controller;
using App_Coffee.model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Coffee.view
{
    public partial class Goimon : Form
    {
        private Douongcontroller controller;
        private Bancontroller bancontroller;
        private Ordercontroller ordercontroller;

        private string maBan = "";
        public Goimon()
        {
            InitializeComponent();
            bancontroller = new Bancontroller();
            controller = new Douongcontroller();
            ordercontroller = new Ordercontroller();
            loadDouong();
            LoadDataDouongdagoi(maBan);
            UpdateStatus("B01");
            UpdateStatus("B02");
            UpdateStatus("B03");
            UpdateStatus("B04");
            UpdateStatus("B05");
            UpdateStatus("B06");
        }

        public void UpdateStatus(string maBan)
        {
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);

            switch (maBan)
            {
                case "B01":
                    UpdateLabelColor(maBan, lbBan1);
                    break;
                case "B02":
                    UpdateLabelColor(maBan, lbBan2);
                    break;
                case "B03":
                    UpdateLabelColor(maBan, lbBan3);
                    break;
                case "B04":
                    UpdateLabelColor(maBan, lbBan4);
                    break;
                case "B05":
                    UpdateLabelColor(maBan, lbBan5);
                    break;
                case "B06":
                    UpdateLabelColor(maBan, lbBan6);
                    break;
                default:
                    break;
            }
        }
        private void DeleteSelectedRow()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Lấy model của DataGridView
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                string maban = maBan; // Biến selectedTable được khai báo từ trước
                string maDoUong = selectedRow.Cells[0].Value?.ToString(); // Lấy giá trị cột đầu tiên (giả sử là Mã Đồ Uống)

                if (!string.IsNullOrEmpty(maBan) && !string.IsNullOrEmpty(maDoUong))
                {
                    // Gọi hàm xóa trong database
                    bool isDeleted = ordercontroller.DeleteFromDatabase(maBan, maDoUong);
                    if (isDeleted)
                    {
                        // Xóa dòng khỏi DataGridView
                        dataGridView2.Rows.Remove(selectedRow);

                        // Tải lại dữ liệu
                        LoadDataDouongdagoi(maBan);

                        // Cập nhật tổng số tiền
                        UpdateTotalAmountLabel();

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa dữ liệu từ cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ, không thể xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateLabelColor(string maBan, Label lbl)
        {
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);

            if (trangThaiBan)
            {
                lbl.ForeColor = Color.Red;
            }
            else
            {
                lbl.ForeColor = Color.Green;
            }
        }
        public void UpdateLabels()
        {

            Label[] lbBans = { lbBan1, lbBan2, lbBan3, lbBan4, lbBan5, lbBan6 };


            bool[] trangthaiBans = bancontroller.Trangthai();


            for (int i = 0; i < lbBans.Length; i++)
            {
                if (trangthaiBans[i])
                {
                    lbBans[i].ForeColor = Color.Green;
                }
                else
                {
                    lbBans[i].ForeColor = Color.Red;
                }
            }
        }


        public void loadDouong()
        {
            List<Douong> douongList = controller.GetAllDouong();

            dataGridView1.DataSource = douongList;

            dataGridView1.ReadOnly = true;

            // Đổi tên tiêu đề cột

            dataGridView1.Columns["MaDouong"].HeaderText = "Mã Đồ Uống";

            dataGridView1.Columns["TenDouong"].HeaderText = "Tên Đồ Uống";

            dataGridView1.Columns["Gia"].HeaderText = "Giá (VND)";

            dataGridView1.Columns["Chiphi"].HeaderText = "Chi Phí (VND)";
            // ẩn
            dataGridView1.Columns["Chiphi"].Visible = false;
        }
        private void HandleBanSelection(string maban)
        {
            maBan = maban;
            LoadDataDouongdagoi(maBan);
        }

        private void LoadDataDouongdagoi(string maBan)
        {
            // Reset DataGridView
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            // Lấy danh sách món đã gọi từ cơ sở dữ liệu
            List<object[]> danhSachMon = ordercontroller.GetDanhSachMonCuaBan(maBan);

            // Đặt header cho DataGridView
            dataGridView2.Columns.Add("MaDouong", "Mã Đồ Uống");
            dataGridView2.Columns.Add("TenDouong", "Tên Đồ Uống");
            dataGridView2.Columns.Add("SoLuong", "Số Lượng");
            dataGridView2.Columns.Add("TongTien", "Tổng Tiền");

            // Thêm dữ liệu vào DataGridView
            foreach (var mon in danhSachMon)
            {
                dataGridView2.Rows.Add(mon);
            }

            // Cập nhật tổng tiền
            UpdateTotalAmountLabel();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
        public void UpdateTotalAmountLabel()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["TongTien"].Value != null)
                {
                    totalAmount += Convert.ToDecimal(row.Cells["TongTien"].Value);
                }
            }

            lbThanhtien.Text = "Tổng tiền: " + totalAmount.ToString("C");
        }
        private void btnBan1_Click(object sender, EventArgs e)
        {
            maBan = "B01";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);

            }
        }

        private void btnBan2_Click(object sender, EventArgs e)
        {
            maBan = "B02";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnBan3_Click(object sender, EventArgs e)
        {
            maBan = "B03";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnBan4_Click(object sender, EventArgs e)
        {
            maBan = "B04";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {

                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnBan5_Click(object sender, EventArgs e)
        {
            maBan = "B05";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnBan6_Click(object sender, EventArgs e)
        {
            maBan = "B06";
            bool trangThaiBan = bancontroller.GetTrangThai(maBan);
            if (!trangThaiBan)
            {
                MessageBox.Show("Vui lòng đặt bàn trước khi đặt món");
                this.Close();
                Datban frm = new Datban();
                frm.Show();
            }
            else
            {
                HandleBanSelection(maBan);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {


            int selectedRow = dataGridView1.SelectedRows.Count > 0 ? dataGridView1.SelectedRows[0].Index : -1;
            if (selectedRow != -1)
            {
                string tendouong = dataGridView1.Rows[selectedRow].Cells[1].Value.ToString();
                string madouong = dataGridView1.Rows[selectedRow].Cells[0].Value.ToString();
                double gia = 0;
                if (dataGridView1.Rows[selectedRow].Cells[2].Value != null)
                {
                    gia = Convert.ToDouble(dataGridView1.Rows[selectedRow].Cells[2].Value);
                }
                int soluong = 1;
                double tongtien = gia * soluong;
                string maban = maBan;
                double chiphi = controller.getChiphi(madouong);

                bool isUpdated = ordercontroller.AddDrinkToTable(maban, madouong, tendouong, soluong, gia, chiphi);

                LoadDataDouongdagoi(maBan);
                if (isUpdated)
                {
                    MessageBox.Show("Số lượng món đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            this.Close();
            Hoadon frm = new Hoadon(maBan);
            frm.Show();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Selected = true;
        }

        private void btnDatban_Click(object sender, EventArgs e)
        {
            this.Close();
            Datban form = new Datban();
            form.Show();
        }

        private void btnDoanhthu_Click(object sender, EventArgs e)
        {
            this.Close();
            Doanhthu form = new Doanhthu();
            form.Show();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            this.Close();
            QuanlyNhansu form = new QuanlyNhansu();
            form.Show();
        }

        private void btnDouong_Click(object sender, EventArgs e)
        {
            this.Close();
            Quanlydouong form = new Quanlydouong();
            form.Show();
        }
    }
}
