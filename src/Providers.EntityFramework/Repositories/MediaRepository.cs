﻿using System.Collections.Generic;
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
    }
}