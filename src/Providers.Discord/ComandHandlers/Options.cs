using System;
using System.IO;
using System.Threading.Tasks;
using Discord.Commands;

namespace Nandel.StikyNotes.Providers.Discord.ComandHandlers
{
    public class Options : ModuleBase<SocketCommandContext>
    {
        private static readonly string OptionsText = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "options.txt"));

        [Command("options")]
        [Alias("help")]
        public async Task OptionsAsync()
        {
            await ReplyAsync(OptionsText);
        }
    }
}