using System;
using System.Collections.Generic;
using System.Linq;
using HumanForce.Api.Controllers.JiraTicketsController.Models;
using HumanForce.Domain.Model.Jira;
using HumanForce.Domain.Services;

namespace HumanForce.Api.Handler
{
    public class TicketHandler: ITicketHandler
    {
        public TicketHandler(IJiraTicketService jiraTicketService)
        {
            JiraTicketService = jiraTicketService;
        }

        protected IJiraTicketService JiraTicketService { get; }

        public int GetTeamVelocityPoints(int sprintId)
        {
            var sprints = GetPastThreeSprints(sprintId);
            var total = 0;
            var issues = JiraTicketService.GetTickets().Issues;
            foreach (var issue in issues)
            {
                if (sprints.Count == 3 && sprints.Contains(issue.Fields.Customfield_10020[0].Name))
                {
                    total += Convert.ToInt32(issue.Fields.Customfield_10016.Split('.')[0]);
                }
            }

            return total;
        }

        public int GetTeamCapacityBySprintId(int sprintId)
        {
            var sprint = GetSprintById(sprintId);
            var result = JiraTicketService.GetTickets().Issues
                                          .Where(x => x.Fields.Customfield_10020[0].Name == sprint.Name)
                                          .GroupBy(x => x.Fields.Customfield_10020[0].Name)
                                          .Select(x => x.Sum(x => Convert.ToInt32(x.Fields.Customfield_10016.Split('.')[0])))
                                          .SingleOrDefault();
            return result;
        }

        public List<TicketModel> GetTicketsBySprintId(int sprintId)
        {
            var sprint = GetSprintById(sprintId);

            var result = JiraTicketService.GetTickets().Issues
                                          .Where(i => i.Fields.Customfield_10020[0].Name == sprint.Name)
                                          .Select(x => new TicketModel
                                          {
                                              Id = x.Id,
                                              Status = x.Fields.Status.Name,
                                              StoryPoints = Convert.ToInt32(x.Fields.Customfield_10016.Split('.')[0]),
                                              Priority = x.Fields.Priority.Name,
                                              ProjectName = x.Fields.Project.Name,
                                              ProjectTypeKey = x.Fields.Project.ProjectTypeKey,
                                              StartDate = x.Fields.Customfield_10020.Select(x => x.StartDate).SingleOrDefault(),
                                              EndDate = x.Fields.Customfield_10020.Select(x => x.EndDate).SingleOrDefault(),
                                              CustomFieldName = x.Fields.Customfield_10020.Select(x => x.Name).SingleOrDefault()
                                          }).Take(50).ToList();
            return result;
        }

        private Sprint GetSprintById(int sprintId)
        {
            var sprint = JiraTicketService.GetSprints().Values.Where(v => v.Id == sprintId).Select(x => new Sprint
            {

                Id = x.Id,
                Name = x.Name,
                StartDate = DateTime.Parse(x.StartDate).ToLocalTime(),
                EndDate = DateTime.Parse(x.EndDate).ToLocalTime(),
            }).SingleOrDefault();
            return sprint;
        }

        private List<string> GetPastThreeSprints(int sprintId)
        {
            var result = new List<string>();
            var sprint = JiraTicketService.GetSprints().Values.Where(v => v.Id < sprintId).TakeLast(3).ToList();
            sprint.ForEach(x => result.Add(x.Name));
            return result;
        }
    }
}
