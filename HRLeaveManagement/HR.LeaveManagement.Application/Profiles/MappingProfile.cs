using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.DTOs.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<Domain.LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<Domain.LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<Domain.LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<Domain.LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
        }
    }
}
