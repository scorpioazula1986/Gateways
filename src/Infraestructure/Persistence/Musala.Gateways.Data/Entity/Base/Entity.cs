using System;

namespace Musala.Gateways.Data.Entity.Base
{
    public abstract class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
       
    }
}
