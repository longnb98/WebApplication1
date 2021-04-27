using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class Ketqua
    {
        public string MaSv { get; set; }
        public string MaMh { get; set; }
        public float? Diem { get; set; }

        public virtual MonHoc MaMhNavigation { get; set; }
        public virtual SinhVien MaSvNavigation { get; set; }
    }
}
