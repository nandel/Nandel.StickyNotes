using System.Collections.Generic;
using MediatR;
using Nandel.StikyNotes.Core.Entities;

namespace Nandel.StikyNotes.Application.Queries.GetAll
{
    public record GetAllQuery : IRequest<IEnumerable<Media>>
    {
        
    }
}