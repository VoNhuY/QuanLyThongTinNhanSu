using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public partial class Baohiem
    {
        public Guid Idbh { get; set; }
        public string? Sobh { get; set; }
        public DateTime? Ngaycap { get; set; }
        public string? Noicap { get; set; }
        public string? Noidkikhambenh { get; set; }
        public Guid? Manv { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
