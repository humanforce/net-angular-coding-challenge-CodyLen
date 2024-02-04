using System;
using System.Collections.Generic;

namespace HumanForce.Api.Controllers.JiraTicketsController.Models
{

    public class TicketModel
    {
        public string Id { get; set; }
        public int StoryPoints { get; set; }
        public string Status { get; set; }
        public string ProjectName { get; set; }
        public string ProjectTypeKey { get; set; }
        public string Priority { get; set; }
        public string CustomFieldName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}

