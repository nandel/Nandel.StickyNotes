using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Repositories;
using MediatR;

namespace Application.Queries.GetText
{
    public class GetContentHandler : IRequestHandler<GetContentQuery, string>
    {
        private readonly IMediaRepository _mediaRepository;

        public GetContentHandler(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<string> Handle(GetContentQuery request, CancellationToken cancellationToken)
        {
            var media = await _mediaRepository.GetAsync(request.Key);
            if (media is null)
            {
                throw new InvalidOperationException($"Não existe uma media com chave {request.Key}");
            }

            return await media.GetContentAsync();
        }
    }
}