using ApbdEfCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApbdEfCodeFirst.Controllers
{
    [Route("/api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) 
        {
            
            _patientService = patientService;

        }

        [HttpGet]
        public IActionResult GetPatientData(int patientId)
        {

            var result = _patientService.GetPatientData(patientId);

            return Ok(result);

        }


    }
}
