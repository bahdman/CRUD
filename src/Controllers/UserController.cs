using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Models;


namespace src.Controllers{

    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class UserDetailsController : ControllerBase{
        
        private static readonly List<UserDetails> userDetails = new List<UserDetails>{};

        // public UserDetails _User;


        [HttpGet]
        public IEnumerable<UserDetails> GetAllUsers(){
            return userDetails;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDetails> GetUserById(Guid id)
        {
            var GetId = userDetails.Where(search => search.Id == id).SingleOrDefault();
            
            if(GetId == null){return NotFound();};

            return GetId;
        }

        [HttpPost]
        public ActionResult<UserDetails> AddNewUser(CreateUser createUser)
        {
            var newUser = new UserDetails{
                Id = createUser.Id, 
                Name = createUser.Name, 
                Age = createUser.Age, 
                Email = createUser.Email, 
                DateCreated = DateTimeOffset.UtcNow
            };

            if(newUser == null){ return NotFound();};

            userDetails.Add(newUser);
            return CreatedAtAction(nameof(GetAllUsers), new{id = newUser.Id}, newUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserDetails(Updatedetails updateDetails, Guid id)
        {
            var userExist = userDetails.Where(search => search.Id == id).SingleOrDefault();

            if(userExist == null){ return NotFound();};

            var update = new UserDetails{
                Id = userExist.Id, 
                Name = updateDetails.Name,
                Age = updateDetails.Age,
                Email = updateDetails.Email,
                DateCreated = updateDetails.DateUpadated,
            };

            var UserLocation = userDetails.FindIndex(index => index.Id == userExist.Id);

            userDetails[UserLocation] = update;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserDetails(Guid id)
        {
            var getUser = userDetails.Where(user => user.Id == id).SingleOrDefault();
            
            if(getUser == null){ return NotFound();};

            var userLocation = userDetails.FindIndex(index => index.Id == getUser.Id);

            userDetails.RemoveAt(userLocation);
            return NoContent();
        }

    }
}