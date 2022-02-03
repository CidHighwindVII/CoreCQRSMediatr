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
            #region LeaveRequest
            CreateMap<Domain.LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<Domain.LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<Domain.LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<Domain.LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion

            #region LeaveAllocation
            CreateMap<Domain.LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<Domain.LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<Domain.LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
            #endregion

            #region LeaveType
            CreateMap<Domain.LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<Domain.LeaveType, CreateLeaveTypeDto>().ReverseMap();
            #endregion
        }
    }
}
