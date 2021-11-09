using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.SetText
{
    public class SetTextHandler : IRequestHandler<SetTextCommand>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IValidator<Text> _validator;
        private readonly ILogger<SetTextHandler> _logger;

        public SetTextHandler(IMediaRepository mediaRepository, IValidator<Text> validator, ILogger<SetTextHandler> logger)
        {
            _mediaRepository = mediaRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Unit> Handle(SetTextCommand request, CancellationToken cancellationToken)
        {
            var entity = new Text()
            {
                Content = request.Content,
                Key = request.Key
            };

            await _validator.ValidateAsync(entity);
            await _mediaRepository.AddAsync(entity);
    
            return Unit.Value;
        }
    }
}