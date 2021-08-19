using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTaskApp.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<List<User>> GetAllAsync();
    }
}
