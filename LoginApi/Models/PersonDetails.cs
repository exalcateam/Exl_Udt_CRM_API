using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginApi.Models
{
    public class PersonDetails
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int MobileNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Photo { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserLoginClass users { get;set; }
    }
}
