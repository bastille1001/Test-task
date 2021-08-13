using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskApp.DataAccess.Repositories.Interfaces;
using TestTaskApp.ExceptionHandler;

namespace TestTaskApp.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskAppContext _context;

        public UserRepository(TaskAppContext context) =>
            _context = context;

        public async Task<bool> AddAsync(User user)
        {   
            if (user != null)
            {
                await _context.AddAsync(user);
                return await SaveAsync();
            }
            throw new CustomError("some error occured while adding");
        }

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        public async Task<bool> SaveAsync() => 
            await _context.SaveChangesAsync() > 0;
    }
}
