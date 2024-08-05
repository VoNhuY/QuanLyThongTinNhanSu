using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{ 
    public partial class Ungluong
    {
        public Guid Id { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? Ngay { get; set; }
        public double? Sotien { get; set; }
        public int? Trangthai { get; set; }
        public Guid? Manv { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
