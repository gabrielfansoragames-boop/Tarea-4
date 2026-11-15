using Microsoft.EntityFrameworkCore;

namespace Tarea_4
{
    public class HelperDbContext : DbContext
    {
        public DbSet<Paciente> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Cita> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=.\\SQLEXPRESS;Database=GestionCitasDb;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=5;");
        }
    }
}