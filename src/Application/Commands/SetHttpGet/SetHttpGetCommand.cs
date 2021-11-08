using System;
using MediatR;

namespace Application.Commands.SetHttpGet
{
    public class SetHttpGetCommand : IRequest
    {
        public string Key { get; set; }
        public Uri Address { get; set; }
        public string FieldToDisplay { get; set; }

        public SetHttpGetCommand()
        { }

        public SetHttpGetCommand(string key, Uri address)
        {
            Key = key;
            Address = address;
        }

        public SetHttpGetCommand(string key, Uri address, string fieldToDisplay)
        {
            Key = key;
            Address = address;
            FieldToDisplay = fieldToDisplay;
        }
    }
}