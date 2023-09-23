using AutoFixture;
using AutoMapper;
using FluentAssertions;
using MiskProgramTask.DomainLayer;
using MiskProgramTask.Helpers;
using MiskProgramTask.RepositoryLayer.Application;
using MiskProgramTask.ServiceLayer;
using MiskProgramTask.ServiceLayer.Application;
using MiskProgramTask.ServiceLayer.Application.DTOs;
using Moq;

namespace MiskProgramTaskUnitTesting;

public class ApplicationServiceTests
{
    private readonly Mock<IApplicationRepository> _mockApplicationRepository;
    private readonly IMapper _mapper;

    public ApplicationServiceTests()
    {
        var fixture = new Fixture();

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = new Mapper(configuration);

        _mockApplicationRepository = new Mock<IApplicationRepository>();
    }

    [Fact]
    public async Task CreateApplication_Should_Return_SuccessResponse_When_CreationSucceeds()
    {
        // Arrange
        var service = new ApplicationService(_mockApplicationRepository.Object, _mapper);

        // To configure the Payload as needed for this case
        var payload = new AddApplicationPayload();

        var entity = _mapper.Map<Application>(payload);
        _mockApplicationRepository.Setup(repo => repo.CreateApplication(It.IsAny<Application>()))
            .ReturnsAsync(true);

        // Act
        var result = await service.CreateApplication(payload);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.ResponseCode.Should().Be(ResponseCode.Success);
        result.Message.Should().Be("Created Successfully");
    }

    [Fact]
    public async Task CreateApplication_Should_Return_ErrorResponse_When_ExceptionIsThrown()
    {
        // Arrange
        var service = new ApplicationService(_mockApplicationRepository.Object, _mapper);

        // To configure the Payload as needed
        var payload = new AddApplicationPayload();

        _mockApplicationRepository.Setup(repo => repo.CreateApplication(It.IsAny<Application>()))
            .ThrowsAsync(new Exception("Simulated error"));

        // Act
        var result = await service.CreateApplication(payload);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.ResponseCode.Should().Be(ResponseCode.Error);
        result.Message.Should().Be("Something went wrong");
    }

    [Fact]
    public async Task UpdateApplication_Should_Return_SuccessResponse_When_UpdateSucceeds()
    {
        // Arrange
        var service = new ApplicationService(_mockApplicationRepository.Object, _mapper);
        var applicationId = Guid.NewGuid(); // Replace with a valid application ID
        var payload = new AddApplicationPayload(); // Customize the payload as needed

        var existingApplication = new Application
            { Id = applicationId };
        _mockApplicationRepository.Setup(repo => repo.GetApplicationById(applicationId))
            .ReturnsAsync(existingApplication);

        _mockApplicationRepository.Setup(repo => repo.UpdateApplication(It.IsAny<Application>()))
            .ReturnsAsync(true);

        // Act
        var result = await service.UpdateApplication(applicationId, payload);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.ResponseCode.Should().Be(ResponseCode.Success);
        result.Message.Should().Be("Updated Successfully");
    }

    [Fact]
    public async Task UpdateApplication_Should_Return_ErrorResponse_When_ApplicationNotFound()
    {
        // Arrange
        var service = new ApplicationService(_mockApplicationRepository.Object, _mapper);
        var applicationId = Guid.NewGuid();
        var payload = new AddApplicationPayload();

        _mockApplicationRepository.Setup(repo => repo.GetApplicationById(applicationId))
            .ReturnsAsync((Application)null);

        // Act
        var result = await service.UpdateApplication(applicationId, payload);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.ResponseCode.Should().Be(ResponseCode.Error);
        result.Message.Should().Be("Application Not Found");
    }

    [Fact]
    public async Task UpdateApplication_Should_Return_ErrorResponse_When_UpdateFails()
    {
        // Arrange
        var service = new ApplicationService(_mockApplicationRepository.Object, _mapper);
        var applicationId = Guid.NewGuid();
        var payload = new AddApplicationPayload();

        var existingApplication = new Application
            { Id = applicationId };
        _mockApplicationRepository.Setup(repo => repo.GetApplicationById(applicationId))
            .ReturnsAsync(existingApplication);

        _mockApplicationRepository.Setup(repo => repo.UpdateApplication(It.IsAny<Application>()))
            .ReturnsAsync(false);

        // Act
        var result = await service.UpdateApplication(applicationId, payload);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.ResponseCode.Should().Be(ResponseCode.Error);
        result.Message.Should().Be("Something went wrong");
    }

    [Fact]
    public async Task GetApplicationById_Should_Return_ApplicationDto_When_ApplicationExists()
    {
        // Arrange
        var service = new ApplicationService(_mockApplicationRepository.Object, _mapper);
        var applicationId = Guid.NewGuid();

        var existingApplication = new Application
            { Id = applicationId };
        _mockApplicationRepository.Setup(repo => repo.GetApplicationById(applicationId))
            .ReturnsAsync(existingApplication);

        // Act
        var result = await service.GetApplicationById(applicationId);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.ResponseCode.Should().Be(ResponseCode.Success);
        result.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task GetApplicationById_Should_Return_Null_When_ApplicationNotFound()
    {
        // Arrange
        var service = new ApplicationService(_mockApplicationRepository.Object, _mapper);
        var applicationId = Guid.NewGuid();

        _mockApplicationRepository.Setup(repo => repo.GetApplicationById(applicationId))
            .ReturnsAsync((Application)null);

        // Act
        var result = await service.GetApplicationById(applicationId);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.ResponseCode.Should().Be(ResponseCode.Error);
        result.Data.Should().BeNull();
    }
}