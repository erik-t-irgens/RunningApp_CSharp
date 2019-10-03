using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningApp.Models
{
    [Table("tracks")]
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        public string TrackName { get; set; }

        public string Description { get; set; }

        public string Waypoints { get; set; }

        public string Location { get; set; }

        public string ApplicationUserId { get; set; }

    }
}
