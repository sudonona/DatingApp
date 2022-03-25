using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required] // cosi non potrà essere un campo vuoto e caso contrario mi avvisera tramite exception message
        public string Username { get; set; }
  
        [Required] // Cosi non potra essere vuoto
        //[RegularExpression] // Essendo un password deve rispettare una espressione regolare
        public string Password{ get; set; }
    }
}