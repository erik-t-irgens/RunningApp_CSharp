using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningApp.Models
{
    [Table("userprofiles")]
    public class Userprofile
    {
        [Key]
        public int UserprofileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public int Pace { get; set; }
        public string Photo { get; set; }
        public string Location { get; set; }
        // public string Instagram { get; set; }
        // public string Facebook { get; set; }
        public string ApplicationUserId { get; set; }
    }
}