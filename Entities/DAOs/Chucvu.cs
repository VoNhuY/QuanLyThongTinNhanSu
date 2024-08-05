using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{ 
    public partial class Chucvu
    {
        public Chucvu()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        public Guid Idcv { get; set; }
        public string? Tenchucvu { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
