using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginApi.Models
{
    public class BankDetails
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountNo { get; set; }
        [Required]
        public string? Nominee { get; set; }
        [Required]
        public string? BankName { get; set; }
        [Required]
        public string? Branch {  get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Companydetails? company { get; set; }
    }
}
