using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Application.Queries.GetAllKeys;

namespace Nandel.StikyNotes.Providers.Discord.ComandHandlers
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

            var grouping = keys.GroupBy(x => x.Split("-").First());
            
            var response = new StringBuilder();
            foreach (var group in grouping)
            {
                response.AppendLine();
                response.AppendLine($"**{group.Key}**");
                response.AppendLine();
                
                foreach (var key in group)
                {
                    response.AppendLine($"!{key}");
                }
            }

            await ReplyAsync(response.ToString());
        }
    }
}