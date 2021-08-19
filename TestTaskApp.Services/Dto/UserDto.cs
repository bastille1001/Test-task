using System;
using System.ComponentModel.DataAnnotations;

namespace TestTaskApp.Services.Model
{
    public class UserDto
    {
        [Required]
        public DateTime RegistrationDt { get; set; }
        
        [Required]
        public DateTime LastActivityDt { get; set; }
    }
}
