using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
    public class CompanyImage
    {
        [Key]
        public int ImageId { get; set; }
        public string? Filename { get; set; }
        public string? Filetype { get; set; }
        public byte[]? Filecontent { get; set; }
        public string? Filesize { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Companydetails? company { get; set; }
    }
}
