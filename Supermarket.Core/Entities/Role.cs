namespace Supermarket.Core.Entities
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public RoleType Type { get; set; }
    }

    public enum RoleType { Admin, Cashier }
}