using System.Threading.Tasks;

namespace Nandel.StikyNotes.Core.Specifications
{
    public interface ISpecification<T>
    {
        bool IsApplicableTo(T instance);
        Task<bool> IsSatisfiedByAsync(T instance);
        string GetErrorMessage(T instance);
    }
}