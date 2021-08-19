using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [JsonIgnore]
        public double LifeTime { get => (LastActivityDt - RegistrationDt).TotalDays; }

        public bool ReturnedUsersDatesCount(int xDay) =>
            (LastActivityDt - RegistrationDt).TotalDays >= xDay;

        public bool DownloadedUsersDatesCount(int xDay) =>
            DateTime.Now.AddDays(-xDay) >= RegistrationDt;
    }
}
