using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public partial class Tangca 
    {
        public Guid Id { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? Ngay { get; set; }
        public double? Sogio { get; set; }
        public Guid? Manv { get; set; }
        public Guid? Idloaica { get; set; }

        public virtual Loaica? IdloaicaNavigation { get; set; }
        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
