using System.Threading.Tasks;
using Nandel.StikyNotes.Core.Entities;

namespace Nandel.StikyNotes.Core.Specifications
{
    public class MediaKeyIsRequiredSpecification<T> : ISpecification<T> where T: Media
    {
        public bool IsApplicableTo(T instance) => true;

        public Task<bool> IsSatisfiedByAsync(T instance)
        {
            var resultValue = !string.IsNullOrWhiteSpace(instance.Key);
            var result = Task.FromResult(resultValue);
            
            return result;
        }

        public string GetErrorMessage(T instance)
        {
            return "O preenchimento da chave é obrigatório";
        }
    }
}