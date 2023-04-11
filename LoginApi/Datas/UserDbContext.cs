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
<<<<<<< Updated upstream
        public DbSet<Companydetails> Companydetails { get; set; }
        public DbSet<PersonDetails> Persondetails { get; set; }
=======
        public DbSet<PurchaseDetails> Purchasedetails { get; set; }
        public DbSet<BankDetails> Bankdetails { get; set; } 
>>>>>>> Stashed changes
    }
}
