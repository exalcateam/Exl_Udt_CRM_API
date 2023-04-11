using LoginApi.Models;

namespace LoginApi.Dto
{
    public class CompanyFullDetails
    {
        public Companydetails newcompanydetails { get; set; }
        public BankDetails newbankdetails { get; set; }
        public List<PersonDetails> newpersondetails { get; set; }
        public List<PurchaseDetails> newpurchasedetails { get; set; }
    }
}
