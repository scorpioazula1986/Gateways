namespace Musala.Gateways.Domain.Models
{
    public class DeviceModel
    {
        public string Uid { get; set; }
        public string Vendor { get; set; }
        public int Status { get; set; }
        public long IdGateway { get; set; }
    }
}