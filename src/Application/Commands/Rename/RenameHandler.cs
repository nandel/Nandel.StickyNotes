using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Core.Entities;
using Nandel.StikyNotes.Core.Repositories;
using Nandel.StikyNotes.Core.Services;

namespace Nandel.StikyNotes.Application.Commands.Rename
{
    public class RenameHandler : IRequestHandler<RenameCommand>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IValidator<Text> _validator;
        private readonly ILogger<RenameHandler> _logger;

        public RenameHandler(IMediaRepository mediaRepository, IValidator<Text> validator, ILogger<RenameHandler> logger)
        {
            _mediaRepository = mediaRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<Unit> Handle(RenameCommand request, CancellationToken cancellationToken)
        {
            var media = await _mediaRepository.GetAsync(request.From);
            if (media is null)
            {
                throw new InvalidOperationException($"Não existe uma media com chave {request.From}");
            }
            
            var keyValidation = new Text()
            {
                Key = request.To,
                Content = "Fake valid text",
            };

            await _validator.ValidateAsync(keyValidation);
            await _mediaRepository.RenameAsync(request.From, request.To);
            
            return Unit.Value;
        }
    }
}