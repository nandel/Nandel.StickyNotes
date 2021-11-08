using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.SetHttpGet
{
    public class SetHttpGetHandler : IRequestHandler<SetHttpGetCommand>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger<SetHttpGetHandler> _logger;

        public SetHttpGetHandler(IMediaRepository mediaRepository, ILogger<SetHttpGetHandler> logger)
        {
            _mediaRepository = mediaRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(SetHttpGetCommand request, CancellationToken cancellationToken)
        {
            ValidadeKey(request.Key);
            ValidateAddress(request.Address);
            
            var entity = new HttpGet()
            {
                Key = request.Key,
                Address = request.Address,
                FieldToDisplay = request.FieldToDisplay
            };
    
            await _mediaRepository.AddAsync(entity);
    
            return Unit.Value;
        }
    
        private void ValidateAddress(Uri address)
        {
            
        }
    
        private void ValidadeKey(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidOperationException("O nome deve ser informado");
            }
        }
    }
}