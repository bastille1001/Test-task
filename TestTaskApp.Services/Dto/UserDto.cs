using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
