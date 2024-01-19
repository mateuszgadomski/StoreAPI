using Microsoft.EntityFrameworkCore;
using Store.Domain.Interfaces;
using Store.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _dbContext;

        public StoreRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.Store store)
        {
            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Store>> GetAll()
            => await _dbContext.Stores.ToListAsync();

        public async Task<Domain.Entities.Store> GetByName(string encodedName)
        {
            var store = await _dbContext.Stores
                .FirstOrDefaultAsync(s => s.Name == encodedName.ToLower());

            return store!;
        }
    }
}