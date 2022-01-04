using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using Nandel.StikyNotes.Application.Queries.GetAll;
using Nandel.StikyNotes.Core.Entities;

namespace Nandel.StikyNotes.Providers.Discord.ComandHandlers
{
    public class List : ModuleBase<SocketCommandContext>
    {
        private readonly ISender _sender;
        private readonly ILogger<List> _logger;

        public List(ISender sender, ILogger<List> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        [Command("list")]
        public async Task ListKeysAsync()
        {
            _logger.LogTrace("!list");
            
            var qry = new GetAllQuery();
            var keys = await _sender.Send(qry);

            var groups = GetGroups(keys);
            
            var response = new StringBuilder();
            foreach (var (groupName, groupMedias) in groups)
            {
                response.AppendLine();
                response.AppendLine($"**{groupName}**");
                response.AppendLine();
                
                foreach (var media in groupMedias)
                {
                    var icon = media switch
                    {
                        HttpGet => ":globe_with_meridians:",
                        _ => ":pencil:"
                    };
                    
                    response.AppendLine($"{icon} !{media.Key}");
                }
            }

            await ReplyAsync(response.ToString());
        }

        protected string GetGroupSpliter(IEnumerable<Media> collection)
        {
            return collection.Any(x => x.Key.Contains(".")) ? "." : "-";
        }

        protected IDictionary<string, ICollection<Media>> GetGroups(IEnumerable<Media> medias)
        {
            var spliter = GetGroupSpliter(medias);
            var groups = medias.OrderBy(x => x.Key).GroupBy(x => x.Key.Split(spliter).First());
            
            var result = new Dictionary<string, ICollection<Media>>();
            foreach (var group in groups)
            {
                var groupName = group.Count() > 1
                    ? PretifyName(group.Key)
                    : "Outros";

                if (!result.ContainsKey(groupName))
                {
                    result.Add(groupName, new List<Media>());
                }

                foreach (var item in group)
                {
                    result[groupName].Add(item);
                }
            }

            return result;
        }

        protected string PretifyName(string input)
        {
            const string splitToken = "$*-split-token-*$";
            var nodes = input.Replace(".", splitToken)
                .Replace("-", splitToken)
                .Replace("_", splitToken)
                .Split(splitToken)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray()
                ;

            for (var i = 0; i < nodes.Length; i++)
            {
                nodes[i] = char.ToUpper(nodes[i][0]) + nodes[i].Substring(1);
            }

            return string.Join(" ", nodes);
        }
    }
}