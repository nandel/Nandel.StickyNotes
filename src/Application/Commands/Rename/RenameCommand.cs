using MediatR;

namespace Nandel.StikyNotes.Application.Commands.Rename
{
    public class RenameCommand : IRequest
    {
        public string From { get; set; }
        public string To { get; set; }

        public RenameCommand(string @from, string to)
        {
            From = @from;
            To = to;
        }
    }
}