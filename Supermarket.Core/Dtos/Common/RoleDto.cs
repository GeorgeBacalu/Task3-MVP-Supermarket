using Supermarket.Core.Entities;

namespace Supermarket.Core.Dtos.Common
{
    public class RoleDto : BaseEntity
    {
        public int Id { get; set; }
        public RoleType Type { get; set; }
    }
}