using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nandel.StikyNotes.Core.Entities;
using Nandel.StikyNotes.Core.Repositories;
using Nandel.StikyNotes.Core.Services;
using Nandel.StikyNotes.Provider.EntityFramework.Context;

namespace Nandel.StikyNotes.Provider.EntityFramework.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly IUserContext _user;
        private readonly SitkyNotesDbContext _db;

        public MediaRepository(IUserContext user, SitkyNotesDbContext db)
        {
            _user = user;
            _db = db;
        }

        private DbSet<Media> Collection => _db.Set<Media>();

        public async Task<bool> ExistsAsync(string key)
        {
            return await Collection.FindAsync(_user.TenantId, key) != null;
        }

        public async Task<Media> GetAsync(string key)
        {
            return await Collection.FindAsync(_user.TenantId, key);
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