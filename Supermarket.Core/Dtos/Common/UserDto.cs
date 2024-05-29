﻿using Supermarket.Core.Entities;
using System;

namespace Supermarket.Core.Dtos.Common
{
    public class UserDto : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleId { get; set; }
    }
}