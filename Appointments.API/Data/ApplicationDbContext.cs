using Microsoft.EntityFrameworkCore;

namespace Appointments.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Appointment>()
            .HasData(new Appointment { Id = 1, Name = "New Years Day", Date = new DateOnly(2024, 01, 01) });

        builder.Entity<Appointment>()
            .HasData(new Appointment { Id = 2, Name = "Doctor Appointment", Date = new DateOnly(2024, 03, 15) });

        builder.Entity<Appointment>()
            .HasData(new Appointment { Id = 3, Name = "Car Oil Change", Date = new DateOnly(2024, 03, 22) });

        base.OnModelCreating(builder);
    }
}