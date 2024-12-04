﻿using System;

namespace Model
{
   
    public class Nhansumodel
    {
        // Properties
        public int Id { get; set; }
        public string HoVaTen { get; set; }
        public string GioiTinh { get; set; }
        public int NamSinh { get; set; }
        public string ChucVu { get; set; }
        public string QueQuan { get; set; }
        public string SoDienThoai { get; set; }

        // Default Constructor
        public Nhansumodel() { }

        // Parameterized Constructor
        public Nhansumodel(int id, string hoVaTen, string gioiTinh, int namSinh, string chucVu, string queQuan, string soDienThoai)
        {
            Id = id;
            HoVaTen = hoVaTen;
            GioiTinh = gioiTinh;
            NamSinh = namSinh;
            ChucVu = chucVu;
            QueQuan = queQuan;
            SoDienThoai = soDienThoai;
        }

        // ToString Method
        public override string ToString()
        {
            return $"NhanSuModel{{ Id={Id}, HoVaTen='{HoVaTen}', GioiTinh='{GioiTinh}', NamSinh={NamSinh}, ChucVu='{ChucVu}', QueQuan='{QueQuan}', SoDienThoai='{SoDienThoai}' }}";
        }
    }
}
