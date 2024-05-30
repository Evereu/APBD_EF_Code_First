using ApbdEfCodeFirst.Models;

namespace ApbdEfCodeFirst.DtoModels
{
    public class NewPrescription
    {

        public PatientDto Patient { get; set; }

        public DoctorDto Doctor { get; set; }   

        public IEnumerable<MedicamentDto> Medicament { get; set; }

        public DateTime Date { get; set; }  
        public DateTime DueDate { get; set; }   



    }
}
