using MediatR;

namespace Nandel.StikyNotes.Application.Queries.GetContent
{
    public record GetContentQuery : IRequest<string>
    {
        public string Key { get; set; }
        
        public GetContentQuery()
        { }

        public GetContentQuery(string key)
        {
            Key = key;
        }
    }
}