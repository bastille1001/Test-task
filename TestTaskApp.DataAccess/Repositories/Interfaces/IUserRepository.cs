using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SaveAsync();
        Task<bool> AddAsync(User user);
        Task<List<User>> GetAllAsync();
    }
}
