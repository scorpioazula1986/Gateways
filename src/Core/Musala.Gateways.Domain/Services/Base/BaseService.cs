using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Musala.Gateways.Data.Database;
using Musala.Gateways.Data.Entity.Base;

namespace Musala.Gateways.Domain.Services.Base
{
    public abstract class BaseService<T, K> : IBaseService<T, K> where T : Entity<K>
    {
        public BaseService(GatewayContext context)
        {
            Context = context;
        }

        protected GatewayContext Context { get; set; }
        protected DbSet<T> DataHolder { get; set; }

        public async Task<T> CreateAsync(T data)
        {
           
            await Context.AddAsync(data);
            await Context.SaveChangesAsync();
            return data;
        }

        public async Task<T> UpdateAsync(T data)
        {
            Context.Update(data);
            await Context.SaveChangesAsync();
            return data;
        }

        public async Task<T> GetByIdAsync(K id)
        {
            return await Context.FindAsync<T>(id);
        }

        public async Task DeleteAsync(T data)
        {
            Context.Remove(data);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DataHolder.ToListAsync();
        }
    }
}
