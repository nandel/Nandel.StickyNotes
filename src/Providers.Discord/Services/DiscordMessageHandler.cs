using System;
using System.Threading.Tasks;
using Application.Queries.GetText;
using Discord.Commands;
using Discord.WebSocket;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Discord.Services
{
    public class DiscordMessageHandler : IDiscordMessageHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceScope _servicesScope;
        private readonly IServiceProvider _services;

        public DiscordMessageHandler(DiscordSocketClient client, CommandService commands, IServiceProvider services)
        {
            _client = client;
            _commands = commands;
            _servicesScope = services.CreateScope();
            _services = _servicesScope.ServiceProvider;
        }

        public async Task InstallCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            _client.MessageReceived += HandleCustomReadAsync;
                
            await _commands.AddModulesAsync(assembly: typeof(DiscordProviderModule).Assembly, services: _services);
        }

        private async Task HandleCustomReadAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a system message
            if (messageParam is not SocketUserMessage message) return;
                
            // Create a number to track where the prefix ends and the command begins
            var argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!(message.HasCharPrefix('!', ref argPos) || 
                  message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            try
            {
                var query = new GetContentQuery(message.Content[1..]);
                var response = await _services.GetRequiredService<ISender>().Send(query);
                await context.Channel.SendMessageAsync(response);
            }
            catch
            {
                // ignora...
            }
        } 

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a system message
            if (messageParam is not SocketUserMessage message) return;
                
            // Create a number to track where the prefix ends and the command begins
            var argPos = 0;

            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
            if (!(message.HasCharPrefix('!', ref argPos) || 
                  message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await _commands.ExecuteAsync(
                context: context, 
                argPos: argPos,
                services: _services);
        }
    }
}