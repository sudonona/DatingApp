namespace API.entities
{
    public class AppUser
    {
        public int Id { get; set; } //primary key del nostro database
        public string Username { get; set; }

            

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