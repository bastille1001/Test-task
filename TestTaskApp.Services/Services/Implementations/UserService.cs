
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskApp.DataAccess;
using TestTaskApp.DataAccess.Errors;
using TestTaskApp.DataAccess.Repositories;
using TestTaskApp.DataAccess.Repositories.Interfaces;
using TestTaskApp.Services.Model;
using TestTaskApp.Services.Services.Interfaces;

namespace TestTaskApp.Services.Services.Implementations
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository dbRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository dbRepository,
            IMapper mapper)
        {
            this.dbRepository = dbRepository;
            this.mapper = mapper;
        }

        public async Task<double> CalculateAsync(int xDay = 7)
        {
            if (xDay < 1 || xDay > 31) throw new CustomError("must be in 1-31 range");
            List<User> users = await dbRepository.GetAllAsync();
            
            double returnedUsersDatesCount = users.Where(u => u.ReturnedUsersDatesCount(xDay)).Count();
            double downloadedUsersDatesCount = users.Where(u => u.DownloadedUsersDatesCount(xDay)).Count();

            return (returnedUsersDatesCount / downloadedUsersDatesCount) * 100;
        }

        public async Task<List<User>> GetAllAsync() =>
            await dbRepository.GetAllAsync();

        public async Task SaveAsync(UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            await dbRepository.AddAsync(user);
        }
    }
}
