﻿using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    public class LeaveAllocationsController : BaseController
    {
        public LeaveAllocationsController(IMediator mediator) : base(mediator)
        {
        }

        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get(bool isLoggedInUser = false)
        {
            
            var leaveAllocations = await Mediator.Send(new GetLeaveAllocationListRequest() { IsLoggedInUser = isLoggedInUser });
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await Mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };
            var repsonse = await Mediator.Send(command);
            return Ok(repsonse);
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation };
            await Mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
