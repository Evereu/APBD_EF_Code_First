using ApbdEfCodeFirst.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace ApbdEfCodeFirst.Services
{
    public interface IPrescriptionService
    {
        IActionResult AddPrescription(NewPrescription newPrescription);
    }
}