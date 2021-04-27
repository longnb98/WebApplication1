using System;
using System.Collections.Generic;

namespace WebApplication1.Model
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            Ketqua = new HashSet<Ketqua>();
        }

        public string MaMh { get; set; }
        public string TenMh { get; set; }
        public byte? Sotiet { get; set; }

        public virtual ICollection<Ketqua> Ketqua { get; set; }
    }
}
