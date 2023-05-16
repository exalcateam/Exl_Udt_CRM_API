using LoginApi.Datas;
using LoginApi.Dto;
using LoginApi.IRepositories;
using LoginApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

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


        public async Task<bool> deletecompany(int id)
        {
            var company = this._userDbContext.Companydetails.FirstOrDefault(x => x.CompanyId == id);
            var person = _userDbContext.Persondetails.Where(x => x.CompanyId == id);
            if (company != null)
            {
                _userDbContext.Companydetails.Remove(company);
                foreach(PersonDetails deleteperson in person)
                {
                    _userDbContext.Persondetails.Remove(deleteperson);
                }
                _userDbContext.SaveChanges();
                return true;
            }
            return false;
        }


        public async Task<bool> deleteperson(int id)
        {
            var person = _userDbContext.Persondetails.FirstOrDefault(x => x.PersonId == id);
            if(person != null)
            {
                _userDbContext.Persondetails.Remove(person);
                _userDbContext.SaveChanges();
                return true;
            }
            return false;
        }


        public async Task<bool> forgotpassword(UserLoginClass user)
        {
            var forgotpassword = _userDbContext.LoginCredential.FirstOrDefault(x => x.Username == user.Username);
            if(forgotpassword != null)
            {
                forgotpassword.Password = user.Password;
                _userDbContext.LoginCredential.Update(forgotpassword);
                _userDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> changepassword(ChangeUserPassword newUserPassword)
        {
            var changepassword = _userDbContext.LoginCredential.FirstOrDefault(x => x.Username == newUserPassword.Username);
            if(changepassword != null)
            {
                if (changepassword.Password == newUserPassword.OldPassword)
                {
                    changepassword.Password = newUserPassword.NewPassword;
                    _userDbContext.LoginCredential.Update(changepassword);
                    _userDbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> editperson(EditPersonDetails newperson)
        {
            var person = _userDbContext.Persondetails.FirstOrDefault(x => x.PersonId == newperson.PersonId);
            if(person != null)
            {
                person.Name = newperson.Name;
                person.Designation = newperson.Designation;
                person.MobileNo = newperson.MobileNo;
                person.Email = newperson.Email;
                person.Photo = newperson.Photo;
                _userDbContext.Persondetails.Update(person);
                _userDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> editcompany(Companydetails editcompany)
        {
            var company = _userDbContext.Companydetails.FirstOrDefault(x => x.CompanyId == editcompany.CompanyId);
            if(company != null)
            {
                company.CompanyName = editcompany.CompanyName;
                company.CompanyLocation = editcompany.CompanyLocation;
                company.GstNo = editcompany.GstNo;
                company.CustomerType = editcompany.CustomerType;
                company.Photos = editcompany.Photos;
                _userDbContext.Companydetails.Update(company); 
                _userDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public Companydetails getpdf(int Id)
        {
            var company = _userDbContext.Companydetails.FirstOrDefault(x => x.CompanyId == Id);
            return company;
        }*/


        public async Task<bool> deleteaccount(string newaccount)
        {
            var User = _userDbContext.LoginCredential.FirstOrDefault(x => x.Username == newaccount);
            if(User != null)
            {
                _userDbContext.LoginCredential.Remove(User);
                _userDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
