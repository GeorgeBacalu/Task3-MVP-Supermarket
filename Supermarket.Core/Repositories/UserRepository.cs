using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SupermarketDbContext _context;

        public UserRepository(SupermarketDbContext context) => _context = context;

        public IList<User> GetAll() => _context.Users
            .Include(user => user.Role)
            .Where(user => user.DeletedAt == null)
            .OrderBy(user => user.CreatedAt)
            .ToList();

        public User GetById(Guid id) => _context.Users
            .Include(user => user.Role)
            .Where(user => user.DeletedAt == null)
            .FirstOrDefault(user => user.Id == id)
            ?? throw new Exception($"User with id {id} not found");

        public User GetByEmail(string email) => _context.Users
            .Include(user => user.Role)
            .Where(user => user.DeletedAt == null)
            .FirstOrDefault(user => user.Email == email)
            ?? throw new Exception($"User with email {email} not found");

        public User Add(User user)
        {
            if (user.Id == Guid.Empty) user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.Now;
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateById(User user, Guid id)
        {
            User userToUpdate = GetById(id);
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.Role = user.Role;
            userToUpdate.PasswordHash = user.PasswordHash;
            userToUpdate.PasswordSalt = user.PasswordSalt;
            if (_context.Entry(userToUpdate).State == EntityState.Modified)
                userToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return userToUpdate;
        }

        public User DeleteById(Guid id)
        {
            User userToDelete = GetById(id);
            userToDelete.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return userToDelete;
        }
    }
}