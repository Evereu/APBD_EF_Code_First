using ApbdEfCodeFirst.Context;
using ApbdEfCodeFirst.DtoModels;
using ApbdEfCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApbdEfCodeFirst.Services
{
    public class PrescriptionService : IPrescriptionService
    {

        private readonly PharmacyContext _context;

        public PrescriptionService(PharmacyContext context)
        {
            _context = context;
        }

        public IActionResult AddPrescription(NewPrescription newPrescription)
        {

            var patient = _context.Patients.FirstOrDefault(p => p.IdPatient == newPrescription.Patient.IdPatient);

            if (patient == null)
            {
                _context.Patients.AddAsync(new Patient
                {
                    IdPatient = newPrescription.Patient.IdPatient,
                    FirstName = newPrescription.Patient.FirstName,
                    LastName = newPrescription.Patient.LastName,
                    BirthDate = newPrescription.Patient.BirthDate,
                });

                _context.SaveChanges();
            }


            var doctor = _context.Doctors.FirstOrDefault(d => d.IdDoctor == newPrescription.Doctor.IdDoctor);

            if (doctor == null)
            {
                _context.Doctors.AddAsync(new Doctor
                {
                    IdDoctor = newPrescription.Doctor.IdDoctor,
                    FirstName = newPrescription.Doctor.FirstName,
                    LastName = newPrescription.Doctor.LastName,
                    Email = newPrescription.Doctor.Email,


                });

                _context.SaveChanges();
            }


            if (newPrescription.DueDate <= newPrescription.Date)
            {
                return new BadRequestObjectResult("data zła");
            }



            var medicamentIds = newPrescription.Medicament.Select(m => m.IdMedicament).ToList();

            if(medicamentIds.Count >= 10)
            {
                return new BadRequestObjectResult("Za dużo leków ");
            }

            var existingMedicamentId = _context.Medicaments
                                    .Select(m => m.IdMedicament)
                                    .ToList();

            var missingMedicamentIds = medicamentIds.Except(existingMedicamentId).ToList();

            if (missingMedicamentIds.Any())
            {
                return new BadRequestObjectResult($"Nie istniejące id leków:  {string.Join(", ", missingMedicamentIds)}");
            }

         
            var newPersc = _context.Prescriptions.AddAsync(new Prescription
            {
                Date = newPrescription.Date,
                DueDate = newPrescription.DueDate,
                IdPatient = newPrescription.Patient.IdPatient,
                IdDoctor = newPrescription.Doctor.IdDoctor,
            });
            
            _context.SaveChanges();

            var lastPrescriptionsId = newPersc.Result.Entity;

            var newPerscMedi = newPrescription.Medicament.Select(m => new PrescriptionMedicament
            {
                IdMedicament = m.IdMedicament,
                IdPrescription = lastPrescriptionsId.IdPrescription,
                Dose = m.Dose,
                Details = m.Details,
            }) ;

            _context.AddRange(newPerscMedi);

            _context.SaveChanges();

            return new OkObjectResult("Dodano");

        }
    }
}
