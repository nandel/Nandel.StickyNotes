using System;
using System.Text;
using System.Threading.Tasks;
using Application.Queries.GetAllKeys;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Discord.Modules
{
    public class List : ModuleBase<SocketCommandContext>
    {
        private readonly ISender _sender;
        private readonly ILogger<List> _logger;

        public List(ISender sender, ILogger<List> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [Command("list")]
        public async Task ListKeysAsync()
        {
            _logger.LogTrace("!list");
            
            var qry = new GetAllKeysQuery();
            var keys = await _sender.Send(qry);
            
            var response = new StringBuilder();
            foreach (var key in keys)
            {
                response.Append(Environment.NewLine);
                response.Append($"!{key}");
            }

            await ReplyAsync(response.ToString());
        }
    }
}