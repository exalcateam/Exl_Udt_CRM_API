using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
    public class UserLoginClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
