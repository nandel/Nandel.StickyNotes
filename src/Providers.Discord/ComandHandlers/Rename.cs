using System.Threading.Tasks;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Application.Commands.Rename;

namespace Nandel.StikyNotes.Providers.Discord.ComandHandlers
{
    public class Rename : ModuleBase<SocketCommandContext>
    {
        private readonly ISender _sender;
        private readonly ILogger<Rename> _logger;

        public Rename(ISender sender, ILogger<Rename> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [Command("rename")]
        public async Task RenameAsync(string from, string to)
        {
            var cmd = new RenameCommand(from, to);
            await _sender.Send(cmd);
            
            await ReplyAsync($"`{from}` foi renomeada para `{to}`");
        }
    }
}