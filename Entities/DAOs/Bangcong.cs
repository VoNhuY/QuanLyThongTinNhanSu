using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public partial class Bangcong
    {
        public Guid Idbc { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? Ngay { get; set; }
        public int? Giovao { get; set; }
        public int? Giora { get; set; }
        public int? Phutra { get; set; }
        public Guid? Manv { get; set; }
        public Guid? LDloaicong { get; set; }

        public virtual Loaicong? LDloaicongNavigation { get; set; }
        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
