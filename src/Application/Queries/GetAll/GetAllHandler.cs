using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Nandel.StikyNotes.Core.Entities;
using Nandel.StikyNotes.Core.Repositories;

namespace Nandel.StikyNotes.Application.Queries.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<Media>>
    {
        private readonly IMediaRepository _mediaRepository;

        public GetAllHandler(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<Media>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await _mediaRepository.GetAllAsync();
        }
    }
}