using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskApp.DataAccess;
using TestTaskApp.DataAccess.Errors;
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

        public async Task<List<double>> CalculateAsync(int xDay)
        {
            List<User> users = await dbRepository.GetAllAsync();

            double returnedUsersDatesCount = 0, downloadedUsersDatesCount = 0, percentage = 0;

            List<double> rollingRetention = new();
            

            for (int i = xDay; i >= 1; i--)
            {
                returnedUsersDatesCount = users.Where(u => u.ReturnedUsersDatesCount(i)).Count();
                downloadedUsersDatesCount = users.Where(u => u.DownloadedUsersDatesCount(i)).Count();

                if (downloadedUsersDatesCount != 0)
                    percentage = (returnedUsersDatesCount / downloadedUsersDatesCount) * 100;
                else
                    percentage = 0;

                rollingRetention.Add(percentage);
            }
            
            return rollingRetention;
        }

        public async Task<List<User>> GetAllAsync() =>
            await dbRepository.GetAllAsync();

        public async Task SaveAsync(UserDto userDto)
        {
            if (userDto.LastActivityDt < userDto.RegistrationDt)
                throw new CustomError("registration date can`t be greater than last activity date");
            var user = mapper.Map<User>(userDto);
            await dbRepository.AddAsync(user);
        }
    }
}
