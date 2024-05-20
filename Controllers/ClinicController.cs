using DentalClinic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;
        
        public ClinicController(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        [HttpGet]
        public IActionResult GetClinics()
        {
            var clinics = _clinicRepository.GetClinics();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else { return Ok(clinics); }
        }

        [HttpGet("{name}")]
        public IActionResult GetClinicByName(string name)
        {
            var clinic = _clinicRepository.GetClinicByName(name);
            if (clinic == null) { return NotFound(); }
            else { return Ok(clinic); }
        }

    }
}
