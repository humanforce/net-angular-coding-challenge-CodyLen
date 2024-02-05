using System;
using System.Collections.Generic;
using System.Linq;
using HumanForce.Api.Controllers.JiraTicketsController.Models;
using HumanForce.Domain.Consts;
using HumanForce.Domain.Enums;
using HumanForce.Domain.Model.Jira;
using HumanForce.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanForce.Api.Controllers.JiraTicketsController
{
    [Route("[controller]")]
    [ApiController]
    public class JiraTicketsController : ControllerBase
    {

        public JiraTicketsController(IJiraTicketService jiraTicketService)
        {
            JiraTicketService = jiraTicketService;
        }

        protected IJiraTicketService JiraTicketService { get; }


        [HttpGet("gettickets")]
        public IActionResult GetJiraTicketsBySprintId(int sprintId)
        {
            var result = GetTicketsBySprintId(sprintId);
            return Ok(result);
        }


        [HttpGet("getvelocity")]
        public IActionResult GetTeamvelocityPast3Sprints(int sprintId)
        {

            var total = getTeamVelocityPoints(sprintId);
            var result = Math.Round(total / 3.0, 1);
            return Ok(result);
        }

        [HttpGet("getcapacity")]
        public IActionResult GetTeamCapacityBySprintId(int sprintId)
        {

            var result = getTeamCapacityBySprintId(sprintId);
            return Ok(result);
        }

        private int getTeamVelocityPoints(int sprintId)
        {
            var sprint = GetSprintById(sprintId);
            var sprints = GetPastThreeSprintsConst(sprint.Name);
            var total = 0;
            var issues = JiraTicketService.GetTickets().Issues;
            foreach(var issue in issues)
            {
                if (sprints.Contains(issue.Fields.Customfield_10020[0].Name))
                {
                    total += Convert.ToInt32(issue.Fields.Customfield_10016.Split('.')[0]);
                }
            }

            return total;
        }

        private List<string> GetPastThreeSprintsConst(string sprint)
        {
            if (sprint == SprintConsts.SCRUMSprint4)
            {
                return new List<string> { SprintConsts.SCRUMSprint1, SprintConsts.SCRUMSprint2, SprintConsts.SCRUMSprint3 };
            }
            else if (sprint == SprintConsts.SCRUMSprint5)
            {
                return new List<string> { SprintConsts.SCRUMSprint2, SprintConsts.SCRUMSprint3, SprintConsts.SCRUMSprint4 };
            }
            else if (sprint == SprintConsts.SCRUMSprint6)
            {
                return new List<string> { SprintConsts.SCRUMSprint3, SprintConsts.SCRUMSprint4, SprintConsts.SCRUMSprint5 };
            }
            else if (sprint == SprintConsts.SCRUMSprint7)
            {
                return new List<string> { SprintConsts.SCRUMSprint4, SprintConsts.SCRUMSprint5, SprintConsts.SCRUMSprint6 };
            }
            else if (sprint == SprintConsts.SCRUMSprint8)
            {
                return new List<string> { SprintConsts.SCRUMSprint5, SprintConsts.SCRUMSprint6, SprintConsts.SCRUMSprint7 };
            }
            else if (sprint == SprintConsts.SCRUMSprint9)
            {
                return new List<string> { SprintConsts.SCRUMSprint6, SprintConsts.SCRUMSprint7, SprintConsts.SCRUMSprint8 };
            }
            else if (sprint == SprintConsts.SCRUMSprint10)
            {
                return new List<string> { SprintConsts.SCRUMSprint7, SprintConsts.SCRUMSprint8, SprintConsts.SCRUMSprint9 };
            }

            return null;
        }

        private int getTeamCapacityBySprintId(int sprintId)
        {
            var sprint = GetSprintById(sprintId);
            var result = JiraTicketService.GetTickets().Issues
                                          .Where(x => x.Fields.Customfield_10020[0].Name == sprint.Name)
                                          .GroupBy(x => x.Fields.Customfield_10020[0].Name)
                                          .Select(x =>  x.Sum(x => Convert.ToInt32(x.Fields.Customfield_10016.Split('.')[0])))
                                          .SingleOrDefault();
            return result;
        }

        private List<TicketModel> GetTicketsBySprintId(int sprintId)
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
            var sprint = JiraTicketService.GetSprints().Values.Where(v => v.Id == sprintId).Select(x => new Sprint {

                  Id = x.Id,
                  Name = x.Name,
                  StartDate = DateTime.Parse(x.StartDate).ToLocalTime(),
                  EndDate = DateTime.Parse(x.EndDate).ToLocalTime(),
            }).SingleOrDefault();
            return sprint;
        }

    }
}
