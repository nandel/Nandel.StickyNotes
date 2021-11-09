using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        bool IsApplicableTo(T instance);
        Task<bool> IsSatisfiedByAsync(T instance);
        string GetErrorMessage(T instance);
    }
}