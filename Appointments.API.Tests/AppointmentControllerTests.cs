using Appointments.API.Controllers;
using Appointments.API.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;

namespace Appointments.API.Tests
{
    [TestClass]
    public class AppointmentControllerTests
    {
        [TestMethod]
        public void GetReturnsList()
        {
            // Arrange
            var dbContext = new Mock<ApplicationDbContext>();
            var appointments = new List<Appointment>
            {
                new() { Id = 1, Name = "New Years Day", Date = new DateOnly(2024, 01, 01) },
                new() { Id = 2, Name = "Doctor Appointment", Date = new DateOnly(2024, 03, 15) },
                new() { Id = 3, Name = "Car Oil Change", Date = new DateOnly(2024, 03, 22) }
            };
            dbContext.Setup(x => x.Appointments)
                .ReturnsDbSet(appointments);

            var controller = new AppointmentController(dbContext.Object);

            // Act
            var result = controller.Get() as OkObjectResult;
            var viewModel = result.Value as List<Appointment>;

            // Assert
            Assert.IsInstanceOfType<OkObjectResult>(result);
            Assert.IsInstanceOfType<List<Appointment>>(viewModel);
            Assert.AreEqual(3, viewModel.Count);
        }

        [TestMethod]
        public void PostAddsToList()
        {
            // Arrange
            var dbContext = new Mock<ApplicationDbContext>();
            var appointments = new List<Appointment>
            {
                new() { Id = 1, Name = "New Years Day", Date = new DateOnly(2024, 01, 01) },
                new() { Id = 2, Name = "Doctor Appointment", Date = new DateOnly(2024, 03, 15) },
                new() { Id = 3, Name = "Car Oil Change", Date = new DateOnly(2024, 03, 22) }
            };
            dbContext.Setup(x => x.Appointments)
                .ReturnsDbSet(appointments);

            var controller = new AppointmentController(dbContext.Object);

            // Act
            var result = controller.Post(new() { Name = "Add another appointment", Date = new DateOnly(2024, 07, 07) }) as OkResult;

            // Assert
            Assert.IsInstanceOfType<OkResult>(result);
        }

        [TestMethod]
        public void PostWithIdReturnsBadRequest()
        {
            // Arrange
            var dbContext = new Mock<ApplicationDbContext>();
            var appointments = new List<Appointment>
            {
                new() { Id = 1, Name = "New Years Day", Date = new DateOnly(2024, 01, 01) },
                new() { Id = 2, Name = "Doctor Appointment", Date = new DateOnly(2024, 03, 15) },
                new() { Id = 3, Name = "Car Oil Change", Date = new DateOnly(2024, 03, 22) }
            };
            dbContext.Setup(x => x.Appointments)
                .ReturnsDbSet(appointments);

            var controller = new AppointmentController(dbContext.Object);

            // Act
            var result = controller.Post(new() { Id = 4, Name = "Add another appointment", Date = new DateOnly(2024, 07, 07) }) as BadRequestResult;

            // Assert
            Assert.IsInstanceOfType<BadRequestResult>(result);
        }
    }
}