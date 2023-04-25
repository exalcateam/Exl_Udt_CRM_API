using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginApi.Models
{
	public class Companydetails
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CompanyId { get; set; }
		public string? CompanyName { get; set; }
		public string? CompanyLocation { get; set; }
		public string? GstNo { get; set; }
		public string? CustomerType { get; set; }
		public string? Photos { get; set; }
	}
}