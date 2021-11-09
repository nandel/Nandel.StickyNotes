using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Nandel.StikyNotes.Core.Services;

namespace Nandel.StikyNotes.Providers.Discord.Services
{
    public class DiscordMessageHandler : IDiscordMessageHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;

        public DiscordMessageHandler(DiscordSocketClient client, CommandService commands, IServiceProvider services)
        {
            _client = client;
            _commands = commands;
            _services = services;
        }

        public async Task InstallCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
                
            await _commands.AddModulesAsync(assembly: typeof(DiscordProviderModule).Assembly, services: _services);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            if (messageParam is not SocketUserMessage message) return;
            if (!IsCommandMessage(message, out var cmd)) return;

            var context = new SocketCommandContext(_client, message);
            using var services = CreateMessageServiceScope(context);

            var isDefaultCommand = _commands.Search(context: context, input: cmd).IsSuccess;
            var input = isDefaultCommand
                ? cmd
                : $"get {cmd}"
                ;
                    
            await _commands.ExecuteAsync(
                context: context, 
                input: input,
                services: services.ServiceProvider);
        }
        
        private IServiceScope CreateMessageServiceScope(SocketCommandContext context)
        {
            var scope = _services.CreateScope();
            
            var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
            userContext.TenantId = context.Guild.Id;

            return scope;
        }

        private bool IsCommandMessage(SocketUserMessage message, out string cmdLine)
        {
            var argPos = 0;
            var isCommand = (message.HasCharPrefix('!', ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos)) 
                        && !message.Author.IsBot;

            cmdLine = isCommand ? message.Content.Substring(argPos) : null;

            return isCommand;
        }
        
    }
}