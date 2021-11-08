using System;
using System.Threading;
using System.Threading.Tasks;
using Application;
using Application.Discord;
using Application.Discord.Services;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebServer.Services
{
    public class DiscordBot : IHostedService
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IDiscordMessageHandler _messageHandler;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DiscordBot> _logger;

        public DiscordBot(DiscordSocketClient client, CommandService commands, IDiscordMessageHandler messageHandler, IConfiguration configuration, ILogger<DiscordBot> logger)
        {
            _client = client;
            _commands = commands;
            _messageHandler = messageHandler;
            _configuration = configuration;
            _logger = logger;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _messageHandler.InstallCommandsAsync();
            
            await _client.LoginAsync(TokenType.Bot, _configuration.GetValue<string>("Discord:Token"));
            await _client.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.StopAsync();
        }
    }
}