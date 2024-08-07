using Appointments.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public AppointmentController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dbContext.Appointments.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Appointment appointment)
    {
        if (appointment.Id != null)
        {
            return BadRequest();
        }

        _dbContext.Appointments.Add(appointment);
        _dbContext.SaveChanges();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}