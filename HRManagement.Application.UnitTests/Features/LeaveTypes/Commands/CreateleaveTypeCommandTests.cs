using AutoMapper;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using HRManagement.Application.MappingProfiles;
using HRManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HRManagement.Application.UnitTests.Features.LeaveTypes.Commands;

public class CreateleaveTypeCommandTests
{
    private readonly IMapper _mapper;
    private Mock<ILeaveTypeRepository> _mockRepo;

    public CreateleaveTypeCommandTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidLeaveType()
    {
        var handler = new CreateLeaveTypeCommandHandler(_mapper, _mockRepo.Object);

        await handler.Handle(new CreateLeaveTypeCommand() { Name = "Test1", DefaultDays = 1
        }, CancellationToken.None);

        var leaveTypes = await _mockRepo.Object.GetAllAsync();
        leaveTypes.Count.ShouldBe(5);
    }
}