using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningApp.Models
{
    [Table("events")]
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string ApplicationUserId { get; set; }
        public int TrackId { get; set; }

        public ICollection<EventUserprofile> Userprofiles { get; set; }
        // public virtual ApplicationUser Creator { get; set; }
    }
}