using E_Commerce_Revision.DTOs.CustomerDTOs;
using E_Commerce_Revision.Repos.CustomerRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Revision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _repo;

        public CustomersController(ICustomer repo)
        {
            _repo = repo;
        }
        [HttpPost("Add")]
        public IActionResult Add(CustomerDto customerDto)
        {
            _repo.AddCustomer(customerDto);
            return Created();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var res = _repo.GetAll();
            return Ok(res);
        }
        [HttpPost("AddExist")]
        public IActionResult AddExist(CustomerDtoToAddWithExistingCoupon customerDto)
        {
            _repo.AddCustomer22(customerDto);
            return Created();
        }
    }
}
