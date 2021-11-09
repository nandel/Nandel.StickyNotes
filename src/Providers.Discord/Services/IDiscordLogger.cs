using System.Threading.Tasks;
using Discord;

namespace Nandel.StikyNotes.Providers.Discord.Services
{
    public interface IDiscordLogger
    {
        Task LogAsync(LogMessage message);
    }
}