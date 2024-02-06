using System;
using System.Collections.Generic;
using HumanForce.Api.Controllers.JiraTicketsController.Models;

namespace HumanForce.Api.Handler
{
    public interface ITicketHandler
    {
        int GetTeamVelocityPoints(int sprintId);
        int GetTeamCapacityBySprintId(int sprintId);
        List<TicketModel> GetTicketsBySprintId(int sprintId);
    }
}
