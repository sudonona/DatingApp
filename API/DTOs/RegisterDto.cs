using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required] // cosi non potrà essere un campo vuoto e caso contrario mi avvisera tramite exception message
        public string Username { get; set; }
  
        [Required] // Cosi non potra essere vuoto
        [StringLength(8, MinimumLength = 4)]//la lunghezza della password max 8 min 4  //[RegularExpression] // Essendo un password deve rispettare una espressione regolare
        public string Password{ get; set; }
    }
}