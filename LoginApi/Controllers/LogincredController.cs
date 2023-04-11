using LoginApi.Datas;
using LoginApi.IRepositories;
using LoginApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LogincredController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        private readonly ICompanyRepository _companyRepository;
        public LogincredController(ICompanyRepository companyrepository)
        {
            _companyRepository = companyrepository;
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserLoginClass newuser)
        {
            await _companyRepository.createuser(newuser);
            return Ok();
        }




        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication([FromBody] UserLoginClass checkuser)
        {
            var auth = await _companyRepository.authentication(checkuser);
            if (auth == null)
            {
                return BadRequest();
            }
            return Ok();
        }



        [HttpGet]
        public List<UserLoginClass> Get()
        {
            return _companyRepository.getuser();
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(string username)
        {
            var deluser = await _companyRepository.deleteuser(username);
            if (deluser == null)
            {
                return BadRequest();
            }
            _userDbContext.Remove(deluser);
            _userDbContext.SaveChanges();
            return Ok();
        }
    }
}
