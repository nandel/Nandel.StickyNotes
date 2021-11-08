using System;
using System.Threading.Tasks;
using Application.Queries.GetText;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Discord.Modules
{
    public class GetMedia : ModuleBase<SocketCommandContext>
    {
        private readonly ISender _sender;
        private readonly ILogger<GetMedia> _logger;

        public GetMedia(ISender sender, ILogger<GetMedia> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [Command("get")]
        public async Task ReadAsync(string name)
        {
            _logger.LogTrace("get {Name}", name);

            try
            {
                var query = new GetContentQuery(name);
                var response = await _sender.Send(query);

                await ReplyAsync(response);
            }
            catch (InvalidOperationException ex)
            {
                await ReplyAsync(ex.Message);
            }
        }
    }
}