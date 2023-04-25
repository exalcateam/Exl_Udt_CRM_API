using LoginApi.Datas;
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




        [HttpGet]
        public async Task<IActionResult> GetFile()
        {
            var document  = new PdfSharpCore.Pdf.PdfDocument();
            var html = "<h1>Santhosh M</h1>";
            PdfGenerator.AddPdfPages(document,html,PageSize.A4);
            byte[]? response = null;
            using(MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);
                response = stream.ToArray();
            }
            string Filename = "Sample.pdf";
            return File(response,"application/pdf", Filename);
        }


    }
}
