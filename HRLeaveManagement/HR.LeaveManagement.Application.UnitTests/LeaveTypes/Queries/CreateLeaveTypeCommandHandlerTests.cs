using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Application.Profiles;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateLeaveTypeDto _CreateLeaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _CreateLeaveTypeDto = new CreateLeaveTypeDto
            {
                Name = "Covid Test",
                DefaultDays = 1
            };

            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task ValidCreateLeaveTypeTest()
        {            
            var createLeaveTypeCommand = new CreateLeaveTypeCommand
            {
                LeaveTypeDto = _CreateLeaveTypeDto
            };

            var result = await _handler.Handle(createLeaveTypeCommand, CancellationToken.None);
            var leaveTypes = await _mockRepo.Object.LeaveTypeRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(true);
            leaveTypes.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InvalidCreateLeaveTypeTest()
        {
            _CreateLeaveTypeDto.DefaultDays = -1;

            var createLeaveTypeCommand = new CreateLeaveTypeCommand
            {
                LeaveTypeDto = _CreateLeaveTypeDto
            };

            var result = await _handler.Handle(createLeaveTypeCommand, CancellationToken.None);
            var leaveTypes = await _mockRepo.Object.LeaveTypeRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(false);
            leaveTypes.Count.ShouldBe(3);
        }
    }
}
