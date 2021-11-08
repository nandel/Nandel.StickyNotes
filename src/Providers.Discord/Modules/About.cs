using System.Threading.Tasks;
using Discord.Commands;

namespace Application.Discord.Modules
{
    public class About : ModuleBase<SocketCommandContext>
    {
        [Command("github")]
        public async Task GithubAsync()
        {
            await ReplyAsync("https://github.com/nandel/Nandel.DiscordStickyNotes");
        }
    }
}