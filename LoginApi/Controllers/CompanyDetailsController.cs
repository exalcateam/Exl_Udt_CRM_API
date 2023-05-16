using LoginApi.Dto;
using LoginApi.IRepositories;
using LoginApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CompanyDetailsController : ControllerBase
    {
        public readonly ICompanyRepository _companyRepository;
        public CompanyDetailsController(ICompanyRepository companyReopsitory)
        {
            _companyRepository = companyReopsitory;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCompanyandPerson([FromBody] CompanyFullDetails newcompanyandperson)
        {
            await _companyRepository.createcompanyandpersondetails(newcompanyandperson);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDetails newperson)
        {
            await _companyRepository.createperson(newperson);
            return Ok();
        }



        [HttpGet]
        public List<Companydetails> GetCompanydetails()
        {
            return _companyRepository.getcompany();
        }


        [HttpGet]
        public List<PersonDetails> GetPersonDetails(int id)
        {
            return _companyRepository.getperson(id);
        }


        [HttpDelete]
        public Task<bool> DeleteCompany(int id)
        {
           return  _companyRepository.deletecompany(id);
        }


        [HttpDelete]
        public Task<bool> DeletePerson(int id)
        {
            return _companyRepository.deleteperson(id);
        }


        [HttpPut]
        public async Task<IActionResult> EditPerson(EditPersonDetails newperson)
        {
            await _companyRepository.editperson(newperson);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditCompany(Companydetails editcompany)
        {
            await _companyRepository.editcompany(editcompany);
            return Ok();
        }

    }
}
