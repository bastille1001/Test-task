using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskApp.DataAccess;
using TestTaskApp.DataAccess.Repositories;
using TestTaskApp.DataAccess.Repositories.Interfaces;
using TestTaskApp.Services.Model;
using TestTaskApp.Services.Services.Interfaces;

namespace TestTaskApp.Services.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository dbRepository;
        public UserService(IUserRepository dbRepository) =>
            this.dbRepository = dbRepository;

        public async Task<double> CalculateAsync(int xDay)
        {
            List<User> users = await dbRepository.GetAllAsync();
            
            int returnedUsersDatesCount = users.Where(x => x.LastActivityDt.Day >= xDay).Count();
            int downloadedUsersDatesCount = users.Where(x => x.RegistrationDt.Day <= xDay).Count();

            double rollingRetentionXDay = (returnedUsersDatesCount / downloadedUsersDatesCount) * 100;
            return rollingRetentionXDay;
        }

        public async Task SaveAsync(UserDto userDto)
        {
            User user = new()
            {
                RegistrationDt = userDto.RegistrationDt,
                LastActivityDt = userDto.LastActivityDt
            };
            await dbRepository.AddAsync(user);
        }
    }
}
