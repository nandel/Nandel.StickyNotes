using System.Collections.Generic;
using MediatR;

namespace Nandel.StikyNotes.Application.Queries.GetAllKeys
{
    public record GetAllKeysQuery : IRequest<IEnumerable<string>>
    {
        
    }
}