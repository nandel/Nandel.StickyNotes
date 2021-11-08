﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IMediaRepository
    {
        Task<Media> GetAsync(string key);
        Task<IEnumerable<Media>> GetAllAsync();
        Task AddAsync(Media instance);
    }
}