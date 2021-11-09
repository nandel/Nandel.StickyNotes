using System.Threading.Tasks;
using Discord.Commands;

namespace Nandel.StikyNotes.Providers.Discord.ComandHandlers
{
    public class About : ModuleBase<SocketCommandContext>
    {
        [Command("about")]
        public async Task AboutAsync()
        {
            await ReplyAsync("Um projeto open source criado por Fernando Souza (https://github.com/nandel)");
        }
        
        [Command("github")]
        public async Task GithubAsync()
        {
            await ReplyAsync("https://github.com/nandel/Nandel.StickyNotes");
        }
    }
}