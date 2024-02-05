using SurveyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLitePCL;


namespace SurveyAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SurveyContext _context;

        public UserRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(int id)
        {
            var UserToDelete = await _context.User.FindAsync(id);
            _context.User.Remove(UserToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
