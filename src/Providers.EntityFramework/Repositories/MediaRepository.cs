using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Provider.EntityFramework.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly SitkyNotesDbContext _db;

        public MediaRepository(SitkyNotesDbContext db)
        {
            _db = db;
        }

        private DbSet<Media> Collection => _db.Set<Media>();

        public async Task<bool> ExistsAsync(string key)
        {
            return await Collection.AnyAsync(x => x.Key == key);
        }

        public async Task<Media> GetAsync(string key)
        {
            return await Collection.FindAsync(key);
        }

        public async Task<IEnumerable<Media>> GetAllAsync()
        {
            return await Collection.ToListAsync();
        }

        public async Task AddAsync(Media instance)
        {
            await Collection.AddAsync(instance);
            
            // TODO: Mover o salvar do dbcontext para o conceito de uow
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(string key)
        {
            var instance = await GetAsync(key);
            if (instance is not null)
            {
                Collection.Remove(instance);
                
                // TODO: Mover o salvar do dbcontext para o conceito de uow
                await _db.SaveChangesAsync();
            }
        }
    }
}