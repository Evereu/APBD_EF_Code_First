using ApbdEfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace ApbdEfCodeFirst.Context
{
    public partial class PharmacyContext : DbContext
    {
        public PharmacyContext() 
        { 
        }

        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options) 
        { 
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription>().HasKey(q => q.IdPrescription);
            modelBuilder.Entity<Medicament>().HasKey(q => q.IdMedicament);
            modelBuilder.Entity<PrescriptionMedicament>().HasKey(q => new
            {
                q.IdMedicament,
                q.IdPrescription
            });


            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(u => u.Medicament)
                .WithMany(u => u.prescriptionMedicaments)
                .HasForeignKey(u => u.IdMedicament);

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(u => u.Prescription)
                .WithMany(u => u.prescriptionMedicaments)
                .HasForeignKey(u => u.IdPrescription);

            //identity off

            modelBuilder.Entity<Patient>()
                .Property(k => k.IdPatient)
                .ValueGeneratedNever();

            //identity off
            modelBuilder.Entity<Doctor>()
                .Property(k => k.IdDoctor)
                .ValueGeneratedNever();

        }


    }
}
