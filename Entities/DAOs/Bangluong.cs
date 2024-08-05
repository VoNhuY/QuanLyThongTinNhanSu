using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public partial class Bangluong
    {
        public Guid Idbangluong { get; set; }
        public Guid? Manv { get; set; }
        public string? Hoten { get; set; }
        public double? Luongcoban { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
