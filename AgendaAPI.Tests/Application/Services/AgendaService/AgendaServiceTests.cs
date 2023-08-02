using Moq;
using Shouldly;
using AutoFixture;
using AgendaAPI.Models;
using AgendaAPI.Repositories.Interfaces;


namespace AgendaAPI.Tests.Application.Services.AgendaService
{
    public class AgendaServiceTests
    {
        private readonly IFixture _fixture;

        public AgendaServiceTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Create_ValidInput_ReturnsAgenda()
        {
            // Arrange
            var name = "John Doe";
            var email = "john.doe@example.com";
            var phoneNumber = "1234567890";

            var agendaRepositoryMock = new Mock<IAgendaRepository>();
            agendaRepositoryMock.Setup(repo => repo.Create(name, email, phoneNumber))
                .ReturnsAsync(new Agenda { Id = Guid.NewGuid(), Name = name, Email = email, Phonenumber = phoneNumber });

            var agendaService = new AgendaAPI.Services.AgendaService(agendaRepositoryMock.Object);

            // Act
            var result = await agendaService.Create(name, email, phoneNumber);

            // Assert
            result.ShouldNotBeNull();
            result.Name.ShouldBe(name);
            result.Email.ShouldBe(email);
            result.Phonenumber.ShouldBe(phoneNumber);
        }

        [Fact]
        public async Task Create_InvalidEmail_ThrowsException()
        {
            // Arrange
            var name = "John Doe";
            var email = "invalidEmail"; 
            var phoneNumber = "1234567890";

            var agendaService = new AgendaAPI.Services.AgendaService(_fixture.Create<Mock<IAgendaRepository>>().Object);

            // Act and Assert
            await Should.ThrowAsync<Exception>(async () => await agendaService.Create(name, email, phoneNumber));
        }

        [Fact]
        public async Task Create_InvalidPhoneNumber_ThrowsException()
        {
            // Arrange
            var name = "John Doe";
            var email = "john.doe@example.com";
            var phoneNumber = "invalidPhoneNumber";

            var agendaService = new AgendaAPI.Services.AgendaService(_fixture.Create<Mock<IAgendaRepository>>().Object);

            // Act and Assert
            await Should.ThrowAsync<Exception>(async () => await agendaService.Create(name, email, phoneNumber));
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsSuccessMessage()
        {
            // Arrange
            var idToDelete = Guid.NewGuid();

            var agendaRepositoryMock = new Mock<IAgendaRepository>();
            agendaRepositoryMock.Setup(repo => repo.Delete(idToDelete))
                .ReturnsAsync("Deleted successfully");

            var agendaService = new AgendaAPI.Services.AgendaService(agendaRepositoryMock.Object);

            // Act
            var result = await agendaService.Delete(idToDelete);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe("Deleted successfully");
        }    

        [Fact]
        public async Task GetAll_RepositoryReturnsEmptyList_ReturnsEmptyList()
        {
            // Arrange
            var emptyAgendaList = new List<Agenda>();

            var agendaRepositoryMock = new Mock<IAgendaRepository>();
            agendaRepositoryMock.Setup(repo => repo.GetAgenda())
                .ReturnsAsync(emptyAgendaList);

            var agendaService = new AgendaAPI.Services.AgendaService(agendaRepositoryMock.Object);

            // Act
            var result = await agendaService.GetAll();

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<Agenda>>();
            result.ShouldBe(emptyAgendaList);
        }

        [Fact]
        public async Task GetById_ValidId_ReturnsAgendaItem()
        {
            // Arrange
            var existingId = Guid.NewGuid();
            var existingAgendaItem = _fixture.Create<Agenda>();
            existingAgendaItem.Id = existingId;

            var agendaRepositoryMock = new Mock<IAgendaRepository>();
            agendaRepositoryMock.Setup(repo => repo.GetById(existingId))
                .ReturnsAsync(existingAgendaItem);

            var agendaService = new AgendaAPI.Services.AgendaService(agendaRepositoryMock.Object);

            // Act
            var result = await agendaService.GetById(existingId);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(existingAgendaItem);
        }

        [Fact]
        public async Task GetById_InvalidId_ReturnsNull()
        {
            // Arrange
            var nonExistingId = Guid.NewGuid();

            var agendaRepositoryMock = new Mock<IAgendaRepository>();
            agendaRepositoryMock.Setup(repo => repo.GetById(nonExistingId))
                .ReturnsAsync((Agenda)null);

            var agendaService = new AgendaAPI.Services.AgendaService(agendaRepositoryMock.Object);

            // Act
            var result = await agendaService.GetById(nonExistingId);

            // Assert
            result.ShouldBeNull();
        }       
                
        [Fact]
        public async Task Update_InvalidEmail_ThrowsException()
        {
            // Arrange
            var existingId = Guid.NewGuid();
            var nameToUpdate = "Updated Name";
            var invalidEmail = "invalid.email"; 
            var phoneNumberToUpdate = "9876543210";

            var agendaService = new AgendaAPI.Services.AgendaService(_fixture.Create<Mock<IAgendaRepository>>().Object);

            // Act and Assert
            await Should.ThrowAsync<Exception>(async () => await agendaService.Update(existingId, nameToUpdate, invalidEmail, phoneNumberToUpdate));
        }
    
        [Fact]
        public async Task Update_InvalidPhoneNumber_ThrowsException()
        {
            // Arrange
            var existingId = Guid.NewGuid();
            var nameToUpdate = "Updated Name";
            var emailToUpdate = "updated.email@example.com";
            var invalidPhoneNumber = "invalidPhoneNumber"; 

            var agendaService = new AgendaAPI.Services.AgendaService(_fixture.Create<Mock<IAgendaRepository>>().Object);

            // Act and Assert
            await Should.ThrowAsync<Exception>(async () => await agendaService.Update(existingId, nameToUpdate, emailToUpdate, invalidPhoneNumber));
        }

    }
}
