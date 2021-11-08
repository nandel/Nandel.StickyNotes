using System.Threading.Tasks;

namespace Application.Discord.Services
{
    public interface IDiscordMessageHandler
    {
        Task InstallCommandsAsync();
    }
}