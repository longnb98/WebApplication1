using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class Khoa
    {
        public Khoa()
        {
            SinhVien = new HashSet<SinhVien>();
        }

        public string MaKh { get; set; }
        public string TenKh { get; set; }

        public virtual ICollection<SinhVien> SinhVien { get; set; }
    }
}
