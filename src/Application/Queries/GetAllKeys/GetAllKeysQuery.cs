using System.Collections.Generic;
using MediatR;

namespace Application.Queries.GetAllKeys
{
    public record GetAllKeysQuery : IRequest<IEnumerable<string>>
    {
        
    }
}