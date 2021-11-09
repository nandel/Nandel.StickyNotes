using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Nandel.StikyNotes.Core.Entities
{
    public class Text : Media
    {
        public const string MediaType = "text";
        
        [Required]
        public string Content { get; set; }
        
        public override Task<string> GetContentAsync()
        {
            return Task.FromResult(Content);
        }
    }
}