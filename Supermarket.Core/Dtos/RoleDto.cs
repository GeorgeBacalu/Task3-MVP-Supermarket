using Supermarket.Core.Entities;

namespace Supermarket.Core.Dtos
{
    public class RoleDto : BaseEntity
    {
        public int Id { get; set; }
        public RoleType Type { get; set; }
    }
}