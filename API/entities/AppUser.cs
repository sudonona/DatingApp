namespace API.entities
{
    public class AppUser
    {
        public int Id { get; set; } //primary key del nostro database
        public string Username { get; set; }

        // aggiungiamo ora due proprietà per la password hash e salt(codifica)

        public byte[] passwordHash { get; set;}

        public byte[] passwordSalt { get; set;}   

        /*Per poter renderle effettive nella nostra tabella bisogna aggiungere una ef migrations da riga di commando
        --dotnet ef migrations add UserPasswordAdded
        --e poi aggiornare il nostro database con dotnet ef database update
        --per verificare gli aggiornamenti facciamo in vsCode ctrl+shitf+p poi sqlite Open database
        
        Poi dobbiamo creare un nuovo controller per gestire l'accesso al nostro database (registrazione)*/ 
        

        //Proprieta di default ---se usiamo PROPFULL
       /* private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        */


    }
}