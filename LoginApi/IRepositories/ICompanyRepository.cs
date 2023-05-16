using LoginApi.Dto;
using LoginApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.IRepositories
{
    public interface ICompanyRepository
    {
        public List<UserLoginClass> getuser();
        public Task<UserLoginClass> authentication([FromBody] UserLoginClass checkusername);
        public Task<bool> deleteuser(string username);
        public Task createuser(UserLoginClass newuser);
        public Task<bool> createperson([FromBody] PersonDetails newperson);
        public Task<bool> createcompanyandpersondetails([FromBody] CompanyFullDetails newcompanyandperson);
        public List<Companydetails> getcompany();
        public List<PersonDetails> getperson([FromBody] int id);
        public Task<bool> deletecompany( int id);
        public Task<bool> deleteperson(int id);
        public Task<bool> forgotpassword(UserLoginClass user);
        public Task<bool> changepassword(ChangeUserPassword changepassword);
        public Task<bool> editperson(EditPersonDetails newperson);
        public Task<bool> editcompany(Companydetails editcompany);
        public Task<bool> deleteaccount(string newaccount);
        /*public Companydetails getpdf(int Id);*/
    }
}
