using Microsoft.AspNetCore.Mvc;
using WebApiTest.Entities;
using WebApiTest.Repositories;
using System.Collections.Generic;
using System.Linq;
using WebApiTest.Dtos;
using System;

namespace WebApiTest.Controllers
{
    //laat aan het systeem weten dat het een api controller is
    [Controller]
    //zorgt ervoor dat je in de url de naam van deze controller moet typen om hem te bereiken
    [Route("Users")]
    public class UserController : ControllerBase//implementeert de controller base klasse
    {
       private readonly IUserRepository userRepository;
       private readonly ITicketRepository ticketRepository;
        //set up voor dependancy injection zodat we de goeie repository binnen krijgen
        public UserController(IUserRepository userRepository, ITicketRepository ticketRepository)
        {
            this.userRepository = userRepository;
            this.ticketRepository = ticketRepository;
        }
        //GET /Users
        [HttpGet]
        public IEnumerable<UserDto> getUsers()
        {
            var users =  userRepository.GetUsers().Select( user => user.AsDto());
            return users;
        }

        //GET /Users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDto> getUser(Guid id)
        {
            var user = userRepository.GetUser(id);
            //als de user niet gevonden is return de goeie foutmelding
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user.AsDto());
        }

        //POST /Users
        [HttpPost]
        public ActionResult<UserDto> createUser(CreateUser UserDto)
        {
            //maak een nieuw user aan op basis van het data transfer object
            User user = new()    { 
                 Id = Guid.NewGuid(),
                 Name = UserDto.Name,
                 CreatedDate = DateTime.Now
            };
            //maak een nieuwe user aan in de repository
            userRepository.CreateUser(user);
            //geef de gemaakte user terug met een get request
            return CreatedAtAction(nameof(getUser), new { id = user.Id }, user.AsDto());
        }
        //PUT /Users/{id}
        [HttpPut("{id}")]
        public ActionResult updateUser(Guid id, CreateUser user)
        {
            //haal de properties van de al bestaande user op
            var existingUser = userRepository.GetUser(id);
            //check of de user wel bestaat
            if(existingUser == null)
            {
                return NotFound();
            }

            User updateUser = existingUser with
            {
                Name = user.Name,
            };
            userRepository.UpdateUser(updateUser);
            return NoContent();
        }

        //DELETE /User/{id}
        [HttpDelete("{id}")]
        public ActionResult deleteUser(Guid id)
        {
            //als de user niet gevonden is return notfound
            if(userRepository.GetUser(id) == null) { 
                return NotFound(); 
            }

            userRepository.DeleteUser(id);

            return NoContent();
        }
    }
}
