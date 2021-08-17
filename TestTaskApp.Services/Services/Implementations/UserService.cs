
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

        public async Task<double[]> CalculateAsync(int xDay = 7)
        {
            List<User> users = await dbRepository.GetAllAsync();

            double returnedUsersDatesCount = 0;
            double downloadedUsersDatesCount = 0;
            double percentage = 0;

            double[] rollingRetention = new double[xDay];
            
            for (int i = 0; i < rollingRetention.Length; i++)
            {
                returnedUsersDatesCount = users.Where(u => u.ReturnedUsersDatesCount(i)).Count();
                downloadedUsersDatesCount = users.Where(u => u.DownloadedUsersDatesCount(i)).Count();
                percentage = (returnedUsersDatesCount / downloadedUsersDatesCount) * 100;

                if (downloadedUsersDatesCount == 0) percentage = 0;
                
                rollingRetention[i] = percentage;
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
