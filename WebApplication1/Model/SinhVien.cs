using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            Ketqua = new HashSet<Ketqua>();
        }

        public string MaSv { get; set; }
        public string HoSv { get; set; }
        public string TenSv { get; set; }
        public bool Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string MaKh { get; set; }
        public double? HocBong { get; set; }

        public virtual Khoa MaKhNavigation { get; set; }
        public virtual ICollection<Ketqua> Ketqua { get; set; }
    }
}
