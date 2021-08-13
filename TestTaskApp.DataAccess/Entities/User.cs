using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.DataAccess
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        
        [Required]
        [Column("registration_dt")]
        public DateTime RegistrationDt { get; set; }
        
        [Required]
        [Column("last_activity_dt")]
        public DateTime LastActivityDt { get; set; }

    }
}
