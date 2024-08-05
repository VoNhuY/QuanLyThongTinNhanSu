namespace Entities.RequestFeatures
{
    public class PhongBanParameters : RequestParameters
    {
        public PhongBanParameters() => OrderBy = "name";

        public string? SearchTerm { get; set; }
    }
}
