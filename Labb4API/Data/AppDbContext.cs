using Labb4Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> persons { get; set; }
        public DbSet<Interest> interests { get; set; }
        public DbSet<Link> links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person()
            {
                PersonID = 1,
                FirstName = "Sana",
                LastName = "Kolq",
                Age = 30,
                Phone = "1234561337",
                DateOfBirth = new DateTime(1990,02,03),
            }, new Person()
            {
                PersonID = 2,
                FirstName = "Saibot",
                LastName = "Kolq",
                Age = 33,
                Phone = "57678811",
                DateOfBirth = new DateTime(1987, 04, 20),
            }, new Person()
            {
                PersonID = 3,
                FirstName = "Radier",
                LastName = "Qolk",
                Age = 40,
                Phone = "52266004",
                DateOfBirth = new DateTime(1978,10,27),
            });

            modelBuilder.Entity<Interest>().HasData(new Interest()
            {
                InterestID = 1,
                Title = "Programming",
                Description = "Programming with C#"
            }, new Interest() 
            {
                InterestID = 2,
                Title = "Skateboarding",
                Description = "Doing sick flips"
            }, new Interest()
            {
                InterestID = 3,
                Title = "Lifting",
                Description = "Getting gains"
            });

            modelBuilder.Entity<Link>().HasData(new Link()
            {
                LinkID = 1,
                URL = "https://www.youtube.com",
                PersonID = 1,
                InterestID = 2
            }, new Link()
            {
                LinkID = 2,
                URL = "https://www.reddit.com",
                PersonID = 2,
                InterestID = 2
            }, new Link()
            {
                LinkID = 3,
                URL = "https://www.notion.com",
                PersonID = 3,
                InterestID = 1
            });
        }
    }
}
