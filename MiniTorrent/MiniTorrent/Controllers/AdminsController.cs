using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MiniTorrent.Models;

namespace MiniTorrent.Controllers
{
    public class AdminsController : ApiController
    {
        private MiniTorrentContext db = new MiniTorrentContext();
        
        
        // GET: api/Admins
        [ActionName("users")]
        [HttpGet]
        public IQueryable<User> GetUsers()
        {
           
            return db.Users;
        }

        // GET: api/Admins/5
        [ActionName("user")]
        [ResponseType(typeof(User))]
        [HttpGet]
        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        
        // POST: api/Admins
        [ActionName("register")]
        [ResponseType(typeof(User))]
        [HttpPost]
        public IHttpActionResult PostUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();


            
            db.SaveChanges();

            return Ok("Register good !");
           // return CreatedAtRoute("DefaultApi", new { id = user.Id });
        }

        // DELETE: api/Admins/5
        [ActionName("delete")]
        [ResponseType(typeof(User))]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Files.ToList().Where(file => file.IdUser == id).ToList()
                .ForEach(f => db.Files.Remove(f));

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        [ActionName("Files")]
        [ResponseType(typeof(MyFile))]
        [HttpGet]
        public List<MyFile> ShowAllFiles()
        {
            var Files = db.Files.ToList();

            return Files;

           
        }
        [ActionName("activeUsers")]
        [HttpGet]
        public List<User> ShowAllActiveUsers()
        {
            var activeUsers = db.Users.ToList().Where(i => i.active == true).ToList();
            return activeUsers;



        }
       
        [ActionName("updateusername")]
        [HttpPut]
        public IHttpActionResult UpdateUserName(int id,string username)
        {
            if (UserExists(id))
            {
                User user = db.Users.Find(id);
                user.username = username;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }
            else
            {
                return BadRequest();
            }
        }
        [ActionName("updatepassword")]
        [HttpPut]
        public IHttpActionResult UpdatePassword(int id, string password)
        {
            if (UserExists(id))
            {
                User user = db.Users.Find(id);
                user.password = password;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }
            else
            {
                return BadRequest();
            }
        }
        [ActionName("updatestatus")]
        [HttpPut]
        public IHttpActionResult UpdateStatus(int id, Boolean active)
        {
            if (UserExists(id))
            {
                User user = db.Users.Find(id);
                user.active = active;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();



                return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            }
            else
            {
                return BadRequest();
            }


        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [ActionName("exists")]
        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }

        
    }
}