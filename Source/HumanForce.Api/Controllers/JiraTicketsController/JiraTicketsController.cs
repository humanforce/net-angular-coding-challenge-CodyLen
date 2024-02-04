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
        public IActionResult GetJiraTickets(string sprint)
        {
            var result = getTickets(sprint);
            return Ok(result);
        }

        [HttpGet("getvelocity")]
        public IActionResult GetTeamVelocity()
        {

            var result = getTeamVelocity();
            return Ok(result);
        }

        [HttpGet("getvelocitypast3sprints")]
        public IActionResult GetTeamvelocityPast3Sprints(string sprint)
        {

            var total = getTeamVelocityPoints(sprint);
            var result = Math.Round(total / 3.0, 1);
            return Ok(result);
        }

        [HttpGet("getcapacity")]
        public IActionResult GetTeamCapacity()
        {

            var result = getTeamCapacity();
            return Ok(result);
        }

        [HttpGet("getcapacitybysprint")]
        public IActionResult GetTeamCapacityBySprint(string sprint)
        {

            var result = getTeamCapacityBySprint(sprint);
            return Ok(result);
        }

        private List<SprintModel> getTeamVelocity()
        {
            var result = JiraTicketService.GetTickets().Issues
                              .Where(x => (x.Fields.Customfield_10020[0].Name == SprintConsts.SCRUMSprint8 || x.Fields.Customfield_10020[0].Name == SprintConsts.SCRUMSprint9 || x.Fields.Customfield_10020[0].Name == SprintConsts.SCRUMSprint10) && x.Fields.Status.Name == SprintConsts.Done)
                              .GroupBy(x => x.Fields.Customfield_10020[0].Name)
                              .Select(x => new SprintModel { SprintName = x.Key, StoryPoint = x.Sum(x => Convert.ToInt32(x.Fields.Customfield_10016.Split('.')[0])) })
                              .ToList();

            return result;
        }

        private int getTeamVelocityPoints(string sprint)
        {
            var sprints = getPastThreeSprintsConst(sprint);
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

        private List<string> getPastThreeSprintsConst(string sprint)
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

        private List<SprintModel> getTeamCapacity()
        {
            var result = JiraTicketService.GetTickets().Issues
                                          .GroupBy(x => x.Fields.Customfield_10020[0].Name)
                                          .Select(x => new SprintModel { SprintName = x.Key, StoryPoint = x.Sum(x => Convert.ToInt32(x.Fields.Customfield_10016.Split('.')[0]))})
                                          .ToList();
            return result;
        }

        private int getTeamCapacityBySprint(string sprint)
        {
            var result = JiraTicketService.GetTickets().Issues
                                          .Where(x => x.Fields.Customfield_10020[0].Name == sprint)
                                          .GroupBy(x => x.Fields.Customfield_10020[0].Name)
                                          .Select(x =>  x.Sum(x => Convert.ToInt32(x.Fields.Customfield_10016.Split('.')[0])))
                                          .SingleOrDefault();
            return result;
        }

        private List<TicketModel> getTickets(string sprint)
        {
            var result = JiraTicketService.GetTickets().Issues
                                          .Where(i => i.Fields.Customfield_10020[0].Name == sprint)
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
                                          }).Take(50).ToList(); //temp pagination to 10 tasks
            return result;
        }

    }
}
