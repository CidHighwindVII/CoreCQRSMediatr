﻿using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            Include(new ILeaveRequestDtoValidator(leaveRequestRepository));

            RuleFor(p => p.Id)
                .GreaterThan(0)
                .MustAsync(async (id, cancelationToken) =>
                {
                    return !(await _leaveRequestRepository.Exists(id));
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
