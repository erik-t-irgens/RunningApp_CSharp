using RunningApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RunningApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private RunningAppContext _db = new RunningAppContext();
        private static int _currentPage = 1;    // Must be 1
        private static int _entriesPerPage = 4;     // This can be changed
        private static int _totalNumEntries;
        private static int _totalPages;
        private static int _prevPage;
        private static int _nextPage;

        // GET api/tracks
        [HttpGet]
        public ActionResult<IEnumerable<Track>> GetAllFiltered()
        {
            return _db.Tracks.OrderBy(x => x.Location).ToList();
        }

        // GET api/tracks/first (first page)
        [HttpGet("first")]
        public ActionResult<IEnumerable<Track>> GetFirstPage()
        {
            var allTracks = _db.Tracks.ToList();
            _totalNumEntries = allTracks.Count();
            _totalPages = (int)Math.Ceiling(_totalNumEntries / (float)_entriesPerPage);
            return _db.Tracks
                .OrderBy(x => x.TrackName)
                .Take(_entriesPerPage).ToList();
        }

        // GET api/tracks/next (next page)
        [HttpGet("next")]
        public ActionResult<IEnumerable<Track>> GetNextPage()
        {
            _nextPage = _currentPage < _totalPages ? _currentPage + 1 : _totalPages;
            var output = _db.Tracks
                .OrderBy(x => x.TrackName)
                .Skip((_nextPage - 1) * _entriesPerPage)
                .Take(_entriesPerPage)
                .ToList();
            if (_currentPage < _totalPages)
            {
                _currentPage += 1;
            }
            return output;
        }

        // GET api/tracks/prev (previous page)
        [HttpGet("prev")]
        public ActionResult<IEnumerable<Track>> GetPrevPage()
        {
            _prevPage = _currentPage > 1 ? _currentPage - 1 : 1;
            var output = _db.Tracks
                .OrderBy(x => x.TrackName)
                .Skip((_prevPage - 1) * _entriesPerPage)
                .Take(_entriesPerPage)
                .ToList();
            if (_currentPage > 1)
            {
                _currentPage -= 1;
            }
            return output;
        }

        // GET api/tracks/5 (retrieve a specific track)
        [HttpGet("{id}")]
        public ActionResult<Track> Get(int id)
        {
            return _db.Tracks
                .FirstOrDefault(x => x.TrackId == id);
        }

        // POST api/tracks
        [HttpPost]
        public void Post([FromBody] Track track)
        {
            _db.Tracks.Add(track);
            _db.SaveChanges();
        }

        // PUT api/tracks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Track track)
        {
            track.TrackId = id;
            _db.Entry(track).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/tracks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var trackToDelete = _db.Tracks.FirstOrDefault(x => x.TrackId == id);
            _db.Tracks.Remove(trackToDelete);
            _db.SaveChanges();
        }
    }
}