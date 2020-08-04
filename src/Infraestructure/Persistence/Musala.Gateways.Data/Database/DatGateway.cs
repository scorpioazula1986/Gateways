using System;
using System.Collections.Generic;

namespace Musala.Gateways.Data.Database
{
    public partial class DatGateway:Entity.Base.Entity<long>
    {
        public DatGateway()
        {
            DatDevice = new HashSet<DatDevice>();
        }

        public string DesSerialNumber { get; set; }
        public string DesName { get; set; }
        public string DesIpv4 { get; set; }

        public virtual ICollection<DatDevice> DatDevice { get; set; }
    }
}
