using API.entities;

namespace API.Interfaces
{
    public interface ITokenService
    {
        //Creiamo un metodo che ricevera un utente come parametro e porteremo tale utente alle entità API 
         string CreateToken(AppUser user);
    }
}