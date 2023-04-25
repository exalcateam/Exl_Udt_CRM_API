using LoginApi.Datas;
using LoginApi.Dto;
using LoginApi.IRepositories;
using LoginApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public readonly UserDbContext _userDbContext;
        public CompanyRepository(UserDbContext dbContext)
        {
            _userDbContext = dbContext;
        }
        public List<UserLoginClass> getuser()
        {
            return _userDbContext.LoginCredential.ToList();
        }


        public async Task<UserLoginClass> authentication([FromBody]UserLoginClass checkuser)
        {
            try
            {
                var auth = _userDbContext.LoginCredential.FirstOrDefault(x => x.Username == checkuser.Username && x.Password == checkuser.Password);
                if (auth != null)
                {
                    return auth;
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
     
        }



        public async Task<bool> deleteuser(string username)
        {
            var del = await this._userDbContext.LoginCredential.FirstOrDefaultAsync(x => x.Username == username);
            if(del == null)
            {
                return false;
            }
            _userDbContext.LoginCredential.Remove(del);
            await _userDbContext.SaveChangesAsync();
            return true;
        }



        public async Task createuser(UserLoginClass newuser)
        {
           this._userDbContext.LoginCredential.Add(newuser);
            await this._userDbContext.SaveChangesAsync();
        }




        public async Task<bool> createcompanyandpersondetails([FromBody]CompanyFullDetails newcompanyandperson)
        {
            var checkuser = await this._userDbContext.Companydetails.FirstOrDefaultAsync(user => user.CompanyId == newcompanyandperson.newcompanydetails.CompanyId);
            if (checkuser == null)
            {
                var company = await this._userDbContext.Companydetails.AddAsync(newcompanyandperson.newcompanydetails);
                this._userDbContext.SaveChanges();
                foreach (PersonDetails person in newcompanyandperson.newpersondetails)
                {
                    person.CompanyId = company.Entity.CompanyId;
                    person.company = null;
                    this._userDbContext.Persondetails.Add(person);
                }
                await this._userDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }



        public async Task<bool> createperson(PersonDetails newperson)
        {
            newperson.company = null;
            await _userDbContext.Persondetails.AddAsync(newperson);
            await this._userDbContext.SaveChangesAsync();
            return true;
        }



        public List<Companydetails> getcompany()
        {
            return _userDbContext.Companydetails.ToList();
        }



        public List<PersonDetails> getperson([FromBody]int id)
        {
            return _userDbContext.Persondetails.Where(x => x.CompanyId == id).ToList();
        }
    }
}
