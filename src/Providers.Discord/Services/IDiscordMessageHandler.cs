using System.Threading.Tasks;

namespace Nandel.StikyNotes.Providers.Discord.Services
{
    public interface IDiscordMessageHandler
    {
        Task InstallCommandsAsync();
    }
}