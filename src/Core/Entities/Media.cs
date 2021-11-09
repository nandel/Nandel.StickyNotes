using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Nandel.StikyNotes.Core.Entities
{
    public abstract class Media : IMustHaveTenant
    {
        [Required]
        public string Key { get; set; }
        
        [Required]
        public ulong TenantId { get; set; }

        public abstract Task<string> GetContentAsync();
    }
}