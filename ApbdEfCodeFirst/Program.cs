using ApbdEfCodeFirst.Context;
using ApbdEfCodeFirst.Services;
using Microsoft.EntityFrameworkCore;

namespace ApbdEfCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<PharmacyContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}