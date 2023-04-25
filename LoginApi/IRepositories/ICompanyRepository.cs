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
    }
}
