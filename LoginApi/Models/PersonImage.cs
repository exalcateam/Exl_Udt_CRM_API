using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
    public class PersonImage
    {
        [Key]
        public int PersonImageId { get; set; }
        public string? Filename { get; set; }
        public string? Filetype { get; set; }
        public byte[]? Filecontent { get; set; }
        public string? Filesize { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual PersonDetails? Person { get; set; }
    }
}
