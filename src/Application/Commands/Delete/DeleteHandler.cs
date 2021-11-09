using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Core.Repositories;

namespace Nandel.StikyNotes.Application.Commands.Delete
{
    public class DeleteHandler : IRequestHandler<DeleteCommand>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger<DeleteHandler> _logger;

        public DeleteHandler(IMediaRepository mediaRepository, ILogger<DeleteHandler> logger)
        {
            _mediaRepository = mediaRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            await _mediaRepository.RemoveAsync(request.Key);
            
            return Unit.Value;
        }
    }
}