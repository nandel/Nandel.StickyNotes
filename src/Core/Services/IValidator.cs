using System.Threading.Tasks;

namespace Nandel.StikyNotes.Core.Services
{
    public interface IValidator<T>
    {
        Task ValidateAsync(T instance);
    }
}