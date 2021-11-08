using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class Media
    {
        [Required]
        public string Key { get; set; }

        public abstract Task<string> GetContentAsync();
    }
}