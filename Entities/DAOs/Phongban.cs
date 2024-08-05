using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public  class Phongban
    {
        public Phongban()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        public Guid Idpb { get; set; }
        public string? Tenpb { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
