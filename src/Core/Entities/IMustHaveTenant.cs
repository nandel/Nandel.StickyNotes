namespace Nandel.StikyNotes.Core.Entities
{
    public interface IMustHaveTenant
    {
        ulong TenantId { get; set; }
    }
}