using System.Threading.Tasks;
using Discord;
using Microsoft.Extensions.Logging;

namespace Application.Discord.Services
{
    public class DiscordLogger : IDiscordLogger
    {
        private readonly ILogger<DiscordLogger> _logger;

        public DiscordLogger(ILogger<DiscordLogger> logger)
        {
            _logger = logger;
        }

        public Task LogAsync(LogMessage message)
        {
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                    _logger.LogCritical(message.Exception, message.Message);
                    break;

                case LogSeverity.Error:
                    _logger.LogError(message.Exception, message.Message);
                    break;

                case LogSeverity.Warning:
                    _logger.LogWarning(message.Exception, message.Message);
                    break;

                case LogSeverity.Info:
                    _logger.LogInformation(message.Exception, message.Message);
                    break;

                case LogSeverity.Verbose:
                    _logger.LogTrace(message.Exception, message.Message);
                    break;

                case LogSeverity.Debug:
                default:
                    _logger.LogDebug(message.Exception, message.Message);
                    break;
            }

            return Task.CompletedTask;
        }
    }
}