namespace Warehouse.Domain
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}