using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public partial class Nhanvienphucap
    {
        public Guid Id { get; set; }
        public Guid? Manv { get; set; }
        public Guid? Idpc { get; set; }
        public DateTime? Ngay { get; set; }
        public string? Noidung { get; set; }
        public double? Sotien { get; set; }

        public virtual Phucap? IdpcNavigation { get; set; }
        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
