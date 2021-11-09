using System.Threading.Tasks;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Application.Commands.Delete;

namespace Nandel.StikyNotes.Providers.Discord.ComandHandlers
{
    public class Delete : ModuleBase<SocketCommandContext>
    {
        private readonly ISender _sender;
        private readonly ILogger<Delete> _logger;

        public Delete(ISender sender, ILogger<Delete> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [Command("delete")]
        public async Task DeleteAsync(string key)
        {
            _logger.LogTrace("!delete {Key}", key);
            
            var cmd = new DeleteCommand(key);
            await _sender.Send(cmd);
            await ReplyAsync($"`{key}` removida");
        }
    }
}