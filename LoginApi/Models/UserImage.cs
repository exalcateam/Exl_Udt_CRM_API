using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
    public class UserImage
    {
        [Key]
        public int UserImageId { get; set; }
        public string? Filename { get; set; }
        public string? Filetype { get; set; }
        public byte[]? Filecontent { get; set; }
        public string? Filesize { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserLoginClass? User { get; set; }
    }
}
