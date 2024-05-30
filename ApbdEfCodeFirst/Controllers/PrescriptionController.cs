using ApbdEfCodeFirst.DtoModels;
using ApbdEfCodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApbdEfCodeFirst.Controllers
{
    [Route("/api/prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {

        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService  prescriptionService) 
        {
            
            _prescriptionService = prescriptionService;

        }

        [HttpPost]
        public IActionResult AddPrescription(NewPrescription newPrescription)
        {
           var abc =  _prescriptionService.AddPrescription(newPrescription);

            return Ok(abc);
        }



    }
}
