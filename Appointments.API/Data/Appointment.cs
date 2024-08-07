using System.ComponentModel.DataAnnotations;

namespace Appointments.API.Data;

public class Appointment
{
    [Key]
    public int? Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateOnly Date { get; set; }
}