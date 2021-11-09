namespace Core.Entities
{
    public interface IMustHaveTenant
    {
        ulong TenantId { get; set; }
    }
}