using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginApi.Models
{
    public class UserLoginClass
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        
    }
}
