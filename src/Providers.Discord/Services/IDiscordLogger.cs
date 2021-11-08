using System.Threading.Tasks;
using Discord;

namespace Application.Discord.Services
{
    public interface IDiscordLogger
    {
        Task LogAsync(LogMessage message);
    }
}