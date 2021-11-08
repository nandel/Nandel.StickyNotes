using MediatR;

namespace Application.Queries.GetText
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