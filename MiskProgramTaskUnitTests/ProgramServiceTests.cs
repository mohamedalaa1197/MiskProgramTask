using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MiskProgramTask.DomainLayer;
using MiskProgramTask.Helpers;
using MiskProgramTask.RepositoryLayer;
using MiskProgramTask.ServiceLayer.Program;
using MiskProgramTask.ServiceLayer.Program.DTOs;
using Moq;

/// <summary>
/// sample of the unit testing using AutoFixture, FluentAssertion, and XUnit
/// 
/// !Not all the test cases Covered
/// </summary>
public class ProgramServiceTests
{
    private readonly Mock<IProgramRepository> _mockProgramRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IConfiguration> _mockConfiguration;
    private readonly Mock<IHostEnvironment> _mockEnvironment;

    public ProgramServiceTests()
    {
        var fixture = new Fixture();

        _mockProgramRepository = new Mock<IProgramRepository>();

        _mockMapper = new Mock<IMapper>();

        _mockConfiguration = new Mock<IConfiguration>();

        _mockEnvironment = new Mock<IHostEnvironment>();
    }

    [Fact]
    public async Task CreateProgram_Should_Return_SuccessResponse_When_CreationSucceeds()
    {
        // Arrange
        var service = new ProgramService(
            _mockProgramRepository.Object,
            _mockMapper.Object,
            _mockConfiguration.Object,
            _mockEnvironment.Object);

        var payload = new ProgramPayload();

        _mockMapper.Setup(mapper => mapper.Map<Program>(payload))
            .Returns(new Program());

        _mockProgramRepository.Setup(repo => repo.CreateProgram(It.IsAny<Program>()))
            .ReturnsAsync(true);

        // Act
        var result = await service.CreateProgram(payload);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.ResponseCode.Should().Be(ResponseCode.Success);
        result.Message.Should().Be("Added Successfully");
    }

    [Fact]
    public async Task CreateProgram_Should_Return_ErrorResponse_When_ExceptionIsThrown()
    {
        // Arrange
        var service = new ProgramService(
            _mockProgramRepository.Object,
            _mockMapper.Object,
            _mockConfiguration.Object,
            _mockEnvironment.Object);

        var payload = new ProgramPayload(); // Customize the payload as needed

        _mockMapper.Setup(mapper => mapper.Map<Program>(payload))
            .Returns(new Program()); // Simulate mapping

        _mockProgramRepository.Setup(repo => repo.CreateProgram(It.IsAny<Program>()))
            .ThrowsAsync(new Exception("Database Exception"));

        // Act
        var result = await service.CreateProgram(payload);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.ResponseCode.Should().Be(ResponseCode.Error);
        result.Message.Should().Be("Something went wrong");
    }
}