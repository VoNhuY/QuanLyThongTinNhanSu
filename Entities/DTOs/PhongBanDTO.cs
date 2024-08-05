using Entities.Common;

namespace Entities.DTOs.CRUD
{
    public record PhongBanDTO
    { 
        public Guid Idpb { get; set; }
        public string? Tenpb { get; set; }
    };
}
