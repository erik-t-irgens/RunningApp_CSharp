using RunningApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RunningApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventUserprofilesController : ControllerBase
    {
        private RunningAppContext _db = new RunningAppContext();

        // DELETE api/Eventuserprofiles/5
        [HttpDelete("{id}")]
        public void DeleteJoin(int id)
        {
            var joinEntry = _db.EventUserprofiles.FirstOrDefault(entry => entry.EventUserprofileId == id);
            _db.EventUserprofiles.Remove(joinEntry);
            _db.SaveChanges();
        }

        // POST api/events/1/userprofiles/3
        [HttpPost("{eventId}/userprofiles/{userprofileId}")]
        public void AddUserprofile(int eventId, int userprofileId)
        {
            var possibleDuplicates = _db.EventUserprofiles
                .Where(x => x.EventId == eventId)
                .Where(x => x.UserprofileId == userprofileId).ToList();
            if (possibleDuplicates.Count() == 0)
            {
                _db.EventUserprofiles.Add(new EventUserprofile() { EventId = eventId, UserprofileId = userprofileId });
                _db.SaveChanges();
            }
        }
    }
}