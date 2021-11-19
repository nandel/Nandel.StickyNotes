using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nandel.StikyNotes.Core.Repositories;

namespace Nandel.StikyNotes.Application.Queries.GetAllKeys
{
    public class GetAllKeysHandler : IRequestHandler<GetAllKeysQuery, IEnumerable<string>>
    {
        private readonly IMediaRepository _mediaRepository;

        public GetAllKeysHandler(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetAllKeysQuery request, CancellationToken cancellationToken)
        {
            var medias = await _mediaRepository.GetAllAsync();
            var result = medias.Select(x => x.Key)
                .OrderBy(x => x)
                .ToArray();

            return result;
        }
    }
}