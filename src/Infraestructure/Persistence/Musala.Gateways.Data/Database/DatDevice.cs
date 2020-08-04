using System;
using System.Collections.Generic;

namespace Musala.Gateways.Data.Database
{
    public partial class DatDevice:Entity.Base.Entity<long>
    {
        public long NumUid { get; set; }
        public long FkGateway { get; set; }
        public string DesVendor { get; set; }
        public int FlgStatus { get; set; }

        public virtual DatGateway FkGatewayNavigation { get; set; }
    }
}
