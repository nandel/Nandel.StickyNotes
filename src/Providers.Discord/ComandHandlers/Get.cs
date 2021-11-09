using System;
using System.Threading.Tasks;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Application.Queries.GetContent;

namespace Nandel.StikyNotes.Providers.Discord.ComandHandlers
{
    public class Get : ModuleBase<SocketCommandContext>
    {
        private readonly ISender _sender;
        private readonly ILogger<Get> _logger;

        public Get(ISender sender, ILogger<Get> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [Command("get")]
        public async Task ReadAsync(string name)
        {
            _logger.LogTrace("!get {Name}", name);

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