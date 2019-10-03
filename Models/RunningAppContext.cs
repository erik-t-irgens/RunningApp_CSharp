using Microsoft.EntityFrameworkCore;


namespace RunningApp.Models
{
    public class RunningAppContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Userprofile> Userprofiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventUserprofile> EventUserprofiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"server=127.0.0.1;user id=root;password=epicodus;port=3306;database=runningapp;");

        public RunningAppContext(DbContextOptions options) : base(options)
        {

        }
        public RunningAppContext()
        {

        }
    }
}