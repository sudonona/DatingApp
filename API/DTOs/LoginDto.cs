namespace API.DTOs
{
    //Qui ci sono le proprietà del lOGIN , l'abbiamo fatto in una classe a parte perche 
    // piu avanti le proprieta della registrazione verrano agiornati
    public class LoginDto
    {
        public string Username {get; set;}

        public string Password {get; set;}
        
    }
}