using System;
using System.Collections.Generic;
using System.IO;
using HumanForce.Domain.Model.Jira;
using HumanForce.Domain.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HumanForce.Services
{
    public class JiraTicketService : IJiraTicketService
    {
        public IEnumerable<Sprint> GetSprints()
        {
            throw new NotImplementedException();
        }

        public Ticket GetTickets()
        {
            var jiraTicketJson = @"Resources/backlog.json";
            var jsonResult = File.ReadAllText(jiraTicketJson);
            var tickets = JsonConvert.DeserializeObject<Ticket>(jsonResult);
            return tickets;
        }
    }
}
