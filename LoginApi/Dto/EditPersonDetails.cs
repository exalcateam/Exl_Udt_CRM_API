using System.ComponentModel.DataAnnotations;

namespace LoginApi.Dto
{
    public class EditPersonDetails
    {
        public int PersonId { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public long MobileNo { get; set; }
        public string? Email { get; set; }
        public string? Photo { get; set; }
    }
}
