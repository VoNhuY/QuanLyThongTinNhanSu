using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public partial class Phucap : BaseEntity
    {
        public Phucap()
        {
            Nhanvienphucaps = new HashSet<Nhanvienphucap>();
        }

        public Guid Idpc { get; set; }
        public string? Tenpc { get; set; }
        public double? Sotien { get; set; }

        public virtual ICollection<Nhanvienphucap> Nhanvienphucaps { get; set; }
    }
}
