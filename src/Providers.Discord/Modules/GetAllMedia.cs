using System;
using System.Text;
using System.Threading.Tasks;
using Application.Queries.GetAllKeys;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Discord.Modules
{
    public class GetAllMedia : ModuleBase<SocketCommandContext>
    {
        private readonly ISender _sender;
        private readonly ILogger<GetAllMedia> _logger;

        public GetAllMedia(ISender sender, ILogger<GetAllMedia> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [Command("list-keys")]
        public async Task ListKeysAsync()
        {
            var qry = new GetAllKeysQuery();
            var keys = await _sender.Send(qry);
            
            var response = new StringBuilder("Abaixo segue a lista de operações. Para utilizar qualquer uma basta chamar `!get {chave}` ou `!{chave}` ");
            foreach (var key in keys)
            {
                response.Append(Environment.NewLine);
                response.Append(key);
            }

            await ReplyAsync(response.ToString());
        }
    }
}