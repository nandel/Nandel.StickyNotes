using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Commands.SetText
{
    public class SetTextHandler : IRequestHandler<SetTextCommand>
    {
        private readonly IMediaRepository _mediaRepository;
    
        public SetTextHandler(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }
    
        public async Task<Unit> Handle(SetTextCommand request, CancellationToken cancellationToken)
        {
            ValidadeKey(request.Key);
            ValidateContent(request.Content);
            
            var entity = new Text()
            {
                Content = request.Content,
                Key = request.Key
            };
    
            await _mediaRepository.AddAsync(entity);
    
            return Unit.Value;
        }
    
        private void ValidateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidOperationException("O conteudo deve ser informado");
            }
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