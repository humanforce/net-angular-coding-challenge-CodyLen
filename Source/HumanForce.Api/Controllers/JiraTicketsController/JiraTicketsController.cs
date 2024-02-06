using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using HumanForce.Api.Controllers.JiraTicketsController.Models;
using HumanForce.Api.Handler;
using HumanForce.Domain.Model.Jira;
using HumanForce.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanForce.Api.Controllers.JiraTicketsController
{
    [Route("[controller]")]
    [ApiController]
    public class JiraTicketsController : ControllerBase
    {

        public JiraTicketsController(ITicketHandler ticketHandler)
        {
            TicketHandler = ticketHandler;
        }

        protected ITicketHandler TicketHandler { get; }


        [HttpGet("gettickets")]
        public IActionResult GetJiraTicketsBySprintId(int sprintId)
        {
            Guard.Against.NegativeOrZero(sprintId);
            var result = TicketHandler.GetTicketsBySprintId(sprintId);
            return Ok(result);
        }


        [HttpGet("getvelocity")]
        public IActionResult GetTeamvelocityPast3Sprints(int sprintId)
        {
            Guard.Against.NegativeOrZero(sprintId);
            var total = TicketHandler.GetTeamVelocityPoints(sprintId);
            var result = Math.Round(total / 3.0, 1);
            return Ok(result);
        }

        [HttpGet("getcapacity")]
        public IActionResult GetTeamCapacityBySprintId(int sprintId)
        {
            Guard.Against.NegativeOrZero(sprintId);
            var result = TicketHandler.GetTeamCapacityBySprintId(sprintId);
            return Ok(result);
        }

    }
}
