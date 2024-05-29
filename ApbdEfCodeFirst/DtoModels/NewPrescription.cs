using ApbdEfCodeFirst.Models;

namespace ApbdEfCodeFirst.DtoModels
{
    public class NewPrescription
    {

        public PatientDto patientDto { get; set; }  

        public MedicamentDto medicamentDto { get; set; }

        public DateTime Date { get; set; }  
        public DateTime DueDate { get; set; }   



    }
}
