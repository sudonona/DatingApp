
using API.entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        //Creare un costruttore
        public DataContext( DbContextOptions options) : base(options)
        {
        }

        //Aggiungere una classe
        public DbSet<AppUser> Users { get; set; }

    }
}