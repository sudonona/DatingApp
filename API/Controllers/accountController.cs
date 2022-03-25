using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] //auomaticamente convalida i parametri che passano

    public class accountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public accountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")] //endpoint per la registrazione
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            //effettuamo un controllo --non si puo aggiungere piu utenti con lo stesso nome che sia con maiuascola o minuscola o anche CamelCase
            // EX : Dani , dani, DANI---va considerato uguale

            if (await UserExists(registerDto.Username)) return BadRequest("Username is Taken");

            //si creano due variabile una per la password e l'altro per l'utente
            using var hmac = new HMACSHA512(); // password crittata
            var user = new AppUser
            {
                Username = registerDto.Username.ToLower(),
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                passwordSalt = hmac.Key
            }; // Utente con i suoi parametri ossia username and password

            _context.Users.Add(user); // aggiungiamo l'utente alla nostra tabella Users database
            await _context.SaveChangesAsync(); //salavtaggio asincrono tramite task

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)

            }; 
            //return user; si ritorna l'utente registrato
        }

        [HttpPost("login")] //endpoint per il login

        //sara una attività publica asincrona , che verra restituita ai risultati dell'azione con actionResult
        //che restituiremo poi all'utente dell'applicazione
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == loginDto.Username);

            if (user == null)
                return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.passwordSalt);

            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < ComputeHash.Length; i++)
            {
                if (ComputeHash[i] != user.passwordHash[i])
                    return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)

            };

            //return user;
        }


        // metodo privato ossia visibile solo dalla classe register che controlla se l'utente era gia registrato 
        //(ossia esiste un utente uguale stesso username) cosi non si insersce nuovamente uno già esistente
        private async Task<bool> UserExists(string Username)
        {
            return await _context.Users.AnyAsync(x => x.Username == Username.ToLower());
        }


    }
}