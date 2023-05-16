using LoginApi.Datas;
using LoginApi.Dto;
using LoginApi.IRepositories;
using LoginApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;


namespace LoginApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LogincredController : ControllerBase
    {
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
            return Ok(auth);
        }



        [HttpGet]
        public List<UserLoginClass> Get()
        {
            return _companyRepository.getuser();
        }



        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]string username)
        {
            await _companyRepository.deleteuser(username);
            return Ok();
        }


        [HttpPatch]
        public async Task<IActionResult> ForgotPassword(UserLoginClass user)
        {
            await _companyRepository.forgotpassword(user);
            return Ok();
        }


        [HttpPatch]
        public async Task<IActionResult> ChangePassword(ChangeUserPassword newUserPassword)
        {
            var a = await _companyRepository.changepassword(newUserPassword);
            if(a == true)
            {
                return Ok();
            }
            else
                return BadRequest();
            
        }



        /*[HttpGet]
        public async Task<IActionResult> GetFile()
        {
            var user = new UserLoginClass()
            {
                Username = "Santhosh M",
                Password = "S@nthosh09",
                Role = "Admin"
            };
            var document = new PdfSharpCore.Pdf.PdfDocument();
            var html = System.IO.File.ReadAllText(@"./PdfTemplate/index.html");
            PdfGenerator.AddPdfPages(document, html, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);
                response = stream.ToArray();
            }
            string Filename = "Sample.pdf";
            return File(response,"application/pdf",Filename);
        }*/

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(string newaccount)
        {
            _companyRepository.deleteaccount(newaccount);
            return Ok();
        }

    }
}
