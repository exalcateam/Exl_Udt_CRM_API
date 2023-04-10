using LoginApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginApi.Datas
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<UserLoginClass> Logincred { get; set; }
        public DbSet<Companydetails> Companydetails { get; set; }
        public DbSet<PersonDetails> Persondetails { get; set; }
    }
}
