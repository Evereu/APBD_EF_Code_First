using Microsoft.AspNetCore.Mvc;

namespace ApbdEfCodeFirst.Services
{
    public interface IPatientService
    {
        IActionResult GetPatientData(int patientId);
    }
}