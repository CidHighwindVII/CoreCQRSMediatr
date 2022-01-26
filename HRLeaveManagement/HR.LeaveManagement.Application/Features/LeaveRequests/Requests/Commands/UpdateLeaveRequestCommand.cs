using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id 
        { 
            get
            {
                if(UpdateLeaveRequestDto != null)
                {
                    return UpdateLeaveRequestDto.Id;
                }

                if(ChangeLeaveRequestApprovalDto != null)
                {
                    return ChangeLeaveRequestApprovalDto.Id;
                }

                return -1;
            }
        }

        public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }
        
        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }
    }
}
