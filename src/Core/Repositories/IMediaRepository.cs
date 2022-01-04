using System.Collections.Generic;
using System.Threading.Tasks;
using Nandel.StikyNotes.Core.Entities;

namespace Nandel.StikyNotes.Core.Repositories
{
    public interface IMediaRepository
    {
        Task<bool> ExistsAsync(string key);
        Task<Media> GetAsync(string key);
        Task<IEnumerable<Media>> GetAllAsync();
        Task AddAsync(Media instance);
        Task RemoveAsync(string key);
        Task RenameAsync(string key, string newKey);
    }
}