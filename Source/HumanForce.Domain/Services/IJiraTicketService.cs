using System;
using System.Collections.Generic;
using HumanForce.Domain.Model.Jira;

namespace HumanForce.Domain.Services
{
    public interface IJiraTicketService
    {
        Ticket GetTickets();
        SprintList GetSprints();
    }
}
