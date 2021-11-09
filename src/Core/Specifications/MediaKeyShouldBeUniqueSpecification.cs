using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;

namespace Core.Specifications
{
    public class MediaKeyShouldBeUniqueSpecification<T> : ISpecification<T> where T: Media
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaKeyShouldBeUniqueSpecification(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public bool IsApplicableTo(T instance) => true;

        public async Task<bool> IsSatisfiedByAsync(T instance)
        {
            return ! await _mediaRepository.ExistsAsync(instance.Key);
        }

        public string GetErrorMessage(T instance)
        {
            return $"A chave informada `{instance.Key}` já existe";
        }
    }
}