using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //strat with api /controller

    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        //Vogliamo render il nostro codice asincrono aggiungendo dei TASKS (THREAD) 
        //Per assegnare ad ogni operazione un tempo determinato per essere svolto 
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;

            //Soluzione migliore 
            //return _context.Users.ToList();
        }

        // percorso api/users/id
         [HttpGet("{Id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
        
            var user = await _context.Users.FindAsync(id);

            return user;

               //Soluzione migliore 
            //return _context.Users.Find();
        }
    }
}