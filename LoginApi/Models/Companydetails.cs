using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginApi.Models
{
	public class Companydetails
	{
		[Key]
		public int CompanyId { get; set; }
		public string? CompanyName { get; set; }
		public string? CompanyLocation { get; set; }
		public string? GstNo { get; set; }
		public string? CustomerType { get; set; }
		public string? Photos { get; set; }
		public string? UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual UserLoginClass users { get; set; }
		
	}
}