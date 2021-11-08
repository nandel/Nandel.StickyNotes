using System;
using System.Threading.Tasks;
using Application.Commands.SetHttpGet;
using Application.Commands.SetText;
using Core.Entities;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Discord.Modules
{
    public class PutMedia : ModuleBase<SocketCommandContext>
    {
        private readonly ISender _sender;
        private readonly ILogger<PutMedia> _logger;

        public PutMedia(ISender sender, ILogger<PutMedia> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [Command("put")]
        [Summary("`!put text key-name \"Text Value\"")]
        public async Task PutAsync(string type, string key, string tail)
        {
            _logger.LogTrace("put {Type} {Key} {Tail}", type, key, tail);
            
            try
            {
                var cmd = type switch
                {
                    Text.MediaType => CreateSetTextCommand(key, tail),
                    HttpGet.MediaType => CreateSetHttpGetCommand(key, tail),
                    _ => throw new InvalidOperationException($"{type} não é um tipo de media aceita")
                };
                
                await _sender.Send(cmd);
                await ReplyAsync($"Media cadastrada utilize `!get {key}` para ler seu conteudo");
            }
            catch (InvalidOperationException ex)
            {
                await ReplyAsync(ex.Message);
            }
        }

        private static IRequest CreateSetTextCommand(string key, string tail)
        {
            return new SetTextCommand(key, tail);
        }

        private static IRequest CreateSetHttpGetCommand(string key, string tail)
        {
            var (address, fieldToDisplay) = ParseHttpGetArgs(tail);
            return new SetHttpGetCommand(key, address, fieldToDisplay);
        }

        private static (Uri Address, string FieldToDisplay) ParseHttpGetArgs(string tail)
        {
            const string fieldToken = " -f ";
            var fieldTokenStart = tail.IndexOf(fieldToken, StringComparison.CurrentCultureIgnoreCase);
            if (fieldTokenStart > 0)
            {
                var address = new Uri(tail.Substring(0, fieldTokenStart));
                var fieldToDisplay = tail.Substring(fieldTokenStart + fieldToken.Length);

                return (address, fieldToDisplay);
            }

            return (new Uri(tail), null);
        }
    }
}