using ApbdEfCodeFirst.Context;
using ApbdEfCodeFirst.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApbdEfCodeFirst.Services
{
    public class PatientService : IPatientService
    {

        private readonly PharmacyContext _context;

        public PatientService(PharmacyContext context)
        {
            _context = context;
        }

        public IActionResult GetPatientData(int patientId)
        {

            var result = _context.Prescriptions
                 .Where(p => p.IdPatient == patientId)
                 .Select(p =>
                 new NewPrescription
                 {
                     Patient = new PatientDto
                     {
                         IdPatient = p.Patients.IdPatient,
                         FirstName = p.Patients.FirstName,
                         LastName = p.Patients.LastName,
                         BirthDate = p.Patients.BirthDate,
                     },
                     Doctor = new DoctorDto
                     {
                         IdDoctor = p.Doctors.IdDoctor,
                         FirstName = p.Doctors.FirstName,
                         LastName = p.Doctors.LastName,
                         Email = p.Doctors.Email,
                     },

                     Medicament = p.prescriptionMedicaments
                     .Select(pp => new MedicamentDto
                     {
                         IdMedicament = pp.Medicament.IdMedicament,
                         Name = pp.Medicament.Name,
                         Dose = (int)pp.Dose,
                         Description = pp.Medicament.Description,
                     })
                 });
            


          


            return new OkObjectResult(result);

        }

    }
}
