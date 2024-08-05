using Entities.Exceptions.BaseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PhongBanNotFoundException : NotFoundException
    {
        public PhongBanNotFoundException(Guid classId) : base($"Department {classId}.")
        {
        }
    }
}
