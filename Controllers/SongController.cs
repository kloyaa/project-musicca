using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of SongController.
	/// </summary>
	public class SongController : ApiController
	{
		readonly SDWebApiDbContext _db = new SDWebApiDbContext();
		
	    [HttpGet]
		[Route("api/song/all")]		
        public IHttpActionResult GetAll(string keyword = "")
        {
           keyword = keyword.Trim();
           var songs =  _db.Songs
           	.Where(x => 
           	       x.Artist.ToLower().Contains(keyword) || 
           	       x.Title.ToLower() .Contains(keyword) || 
         	       x.Writer.ToLower() .Contains(keyword))
           	.ToList();
           return Ok(songs);
        }
        
 
		
	    [HttpPost]
		[Route("api/song/create")]		
        public IHttpActionResult Create(Song song)
        {
            _db.Songs.Add(song);
            _db.SaveChanges();
            return Ok(song);
        }
        
      [HttpGet]
  	  [Route("api/song/find/{Id}")]		
        public IHttpActionResult Get(int Id)
        {       
            var song = _db.Songs.Find(Id);
            if (song != null)
                return Ok(song);
            else
                return BadRequest("Song Id is invalid or not found");
        }
        
		[HttpDelete]
		[Route("api/song/remove/{Id}")]		
		public IHttpActionResult Delete(int Id)
		{
			var song = _db.Songs.Find(Id);
			if (song != null)
				{
					_db.Songs.Remove(song);
					_db.SaveChanges();
					return Ok("Song removed successfully!");
				}
			else
				return BadRequest("Song Id is invalid or not found");
		}
      [HttpPut]
        [Route("api/song/update")]		
        public IHttpActionResult Update(Song songUpdate)
        {
            var song = _db.Songs.Find(songUpdate.Id);
            if (song != null)
            {	
            	song.Title = songUpdate.Title;
            	song.Artist = songUpdate.Artist;
            	song.Writer = songUpdate.Writer;
            	song.Genre = songUpdate.Genre;
            	song.ReleaseDate = songUpdate.ReleaseDate;
      
                _db.Entry(song).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(song);
            }
            else
                return BadRequest("song Id is invalid or not found");
        }
	}
}