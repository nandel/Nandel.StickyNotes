using System.Threading.Tasks;
using Core.Entities;

namespace Core.Services
{
    public interface IValidator<T>
    {
        Task ValidateAsync(T instance);
    }
}