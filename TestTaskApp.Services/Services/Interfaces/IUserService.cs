using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskApp.DataAccess;
using TestTaskApp.Services.Model;

namespace TestTaskApp.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<List<double>> CalculateAsync(int xDay);
        Task SaveAsync(UserDto user);
    }
}
