using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Repositories;
namespace MyApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository

    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) {
            _context = context;
        
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
            throw new NotImplementedException();
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user != null) {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

            }

            
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            IEnumerable<User> user = await _context.Users.ToListAsync();
            return user;
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            User user = await _context.Users.FindAsync(id);
            _context.Users.FindAsync(id);
            return user;
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUserAsyn(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
            throw new NotImplementedException();
        }
    }
}
