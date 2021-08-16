using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskApp.DataAccess.Errors;
using TestTaskApp.DataAccess.Repositories.Interfaces;


namespace TestTaskApp.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskAppContext _context;

        public UserRepository(TaskAppContext context) =>
            _context = context;

        public async Task AddAsync(User user)
        {   
            if (user != null)
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            throw new CustomError("some error occured while adding");
        }

        public async Task<List<User>> GetAllAsync() =>
            await _context.Users.AsNoTracking().ToListAsync();

    }
}
