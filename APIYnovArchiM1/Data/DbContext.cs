using APIYnovArchiM1.Models;
using Microsoft.EntityFrameworkCore;

namespace APIYnovArchiM1.Data
{
    public class ArchiDbContext : DbContext
    {
        public ArchiDbContext(DbContextOptions options):base(options) 
        {

        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagActive> TagActives { get; set; }
        public DbSet<Quizz> Quizzs { get; set; }
        public DbSet<QuizzChoice> QuizzChoices { get; set; }
        public DbSet<QuizzText> QuizzText { get; set; }


    }
}
