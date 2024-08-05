using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public partial class Khenthuongkyluat
    {
        public Guid Id { get; set; }
        public int? Soktlt { get; set; }
        public string? Noidung { get; set; }
        public DateTime? Ngay { get; set; }
        public Guid? Manv { get; set; }
        public int? Loai { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
