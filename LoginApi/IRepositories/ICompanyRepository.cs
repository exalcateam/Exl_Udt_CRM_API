using LoginApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.IRepositories
{
    public interface ICompanyRepository
    {
        public List<UserLoginClass> getuser();
        public Task<UserLoginClass> authentication([FromBody] UserLoginClass checkuser);
        public Task<bool> deleteuser(string username);
        public Task createuser(UserLoginClass newuser);
    }
}
