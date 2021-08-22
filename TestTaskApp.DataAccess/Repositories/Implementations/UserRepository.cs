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
            try
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new CustomError("Something went wrong");
            }
        } 

        public async Task<List<User>> GetAllAsync() => await _context.Users.AsNoTracking().ToListAsync();

        public async Task DeleteById(int id)
        {
            User user = await _context.Users.AsNoTracking().FirstAsync(x => x.UserId == id);
            if (user == null) throw new CustomError("user not found");
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
