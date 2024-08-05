using Entities.Common;
using System;
using System.Collections.Generic;

namespace Entities.DAOs
{
    public partial class Loaicong
    {
        public Loaicong()
        {
            Bangcongs = new HashSet<Bangcong>();
        }

        public Guid Idloaicong { get; set; }
        public string? Tenloaicong { get; set; }
        public double? Heso { get; set; }

        public virtual ICollection<Bangcong> Bangcongs { get; set; }
    }
}
