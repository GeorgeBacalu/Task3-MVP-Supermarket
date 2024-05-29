using System;

namespace Supermarket.Core.Entities
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Role Role { get; set; }
    }
}