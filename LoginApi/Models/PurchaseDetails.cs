using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginApi.Models
{
    public class PurchaseDetails
    {
        [Key]
        public int Id { get; set; }
        public string?Product { get; set; }
        public int OrderedDate { get; set; }
        public int DeliveredDate { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public int CompanyId { get;set; }
        [ForeignKey("CompanyId")]
        public virtual Companydetails? Company { get; set; }
    }
}
