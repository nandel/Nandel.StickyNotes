namespace Nandel.StikyNotes.Core.Services
{
    public class UserContext : IUserContext
    {
        public ulong TenantId { get; set; }
    }
}