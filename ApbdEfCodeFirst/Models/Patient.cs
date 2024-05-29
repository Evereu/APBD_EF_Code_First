using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApbdEfCodeFirst.Models
{
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

    }
}
