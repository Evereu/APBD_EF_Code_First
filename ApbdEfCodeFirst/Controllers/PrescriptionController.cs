using Microsoft.AspNetCore.Mvc;

namespace ApbdEfCodeFirst.Controllers
{
    [Route("/api/prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {

        [HttpPost]
        public void AddPrescription()
        {

            //Wystawienie nowej recepty
            // Ma przyjmować nowy model DTO
            // Jeśli pacjent nie istnieje zwracamy błąd
            // W recepcie max 10 leków, inaczej zwracamy błąd
            // DueData >= Date



        }



    }
}
