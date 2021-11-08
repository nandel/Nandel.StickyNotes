using MediatR;

namespace Application.Commands.SetText
{
    public record SetTextCommand : IRequest
    {
        public string Key { get; set; }
        public string Content { get; set; }
    
        public SetTextCommand()
        { }
    
        public SetTextCommand(string key, string content)
        {
            Key = key;
            Content = content;
        }
    }
}