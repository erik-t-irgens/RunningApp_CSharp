
namespace RunningApp.Models
{
    public class EventUserprofile
    {
        public int EventUserprofileId { get; set; }
        public int EventId { get; set; }
        public int UserprofileId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Userprofile Userprofile { get; set; }
    }
}