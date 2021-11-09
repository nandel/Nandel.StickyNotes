using System.Threading.Tasks;
using Application.Commands.Delete;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Discord.Modules
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