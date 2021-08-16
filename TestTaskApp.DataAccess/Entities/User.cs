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
        
        [Column("registration_dt")]
        public DateTime RegistrationDt { get; set; }
        
        [Column("last_activity_dt")]
        public DateTime LastActivityDt { get; set; }

        [NotMapped]
        public double LifeTime { get => (LastActivityDt - RegistrationDt).TotalDays; }

        public bool ReturnedUsersDatesCount(int xDay) =>
            (LastActivityDt - RegistrationDt).TotalDays >= xDay;

        public bool DownloadedUsersDatesCount(int xDay) =>
            DateTime.Now.AddDays(-xDay) >= RegistrationDt;
    }
}
