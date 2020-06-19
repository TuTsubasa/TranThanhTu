using Bigschool.DTOs;
using Bigschool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bigschool.Controllers
{
   
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userid = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userid && f.FolloweeId == followingDto.Followeeid))
                return BadRequest("Following already exists");
            var following = new Following
            {
                FollowerId = userid,
                FolloweeId = followingDto.Followeeid
            };
            _dbContext.Followings.Add(following);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
