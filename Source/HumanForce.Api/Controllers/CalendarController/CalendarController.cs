using System;
using System.Collections.Generic;
using HumanForce.Api.Controllers.CalendarController.Models;
using HumanForce.Domain.Enums;
using HumanForce.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HumanForce.Domain.Model.Jira;

namespace HumanForce.Api.Controllers.CalendarController
{
    [Route("[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {

        public CalendarController(ICalendarService calendarService, IJiraTicketService jiraTicketService, IUserService userService)
        {
            CalendarService = calendarService;
            JiraTicketService = jiraTicketService;
            UserService = userService;
        }

        protected ICalendarService CalendarService { get; }
        protected IJiraTicketService JiraTicketService { get; }
        protected IUserService UserService { get; }


        [HttpGet("getholiday")]
        public IActionResult GetCalendar(Country country)
        {
            var result = getPublicHolidayByCountry(country);
            return Ok(result);
        }

        [HttpGet("getpublicholidays")]
        public IActionResult GetPublicHolidayBySprintId(int sprintId)
        {
            var result = getPublicHolidayBySprintId(sprintId);
            return Ok(result);
        }

        private List<PublicHolidayModel> getPublicHolidayByCountry(Country coutry)
        {
            var result = new List<PublicHolidayModel>();
            var items = CalendarService.GetPublicHoliday(coutry).Items.ToList();
            foreach(var i in items)
            {
                result.Add(new PublicHolidayModel
                {
                    Description = i.Description,
                    Summary = i.Summary,
                    HolidayDate = i.Start.Date
                });
            }

            return result;
        }

        private List<PublicHolidayModel> getPublicHolidayBySprintId(int sprintId)
        {
            DateTime startDate;
            DateTime endDate;
            var result = new List<PublicHolidayModel>();
            var au = CalendarService.GetPublicHoliday(Country.Australia).Items.ToList();
            var pa = CalendarService.GetPublicHoliday(Country.Pakistan).Items.ToList();
            var ph = CalendarService.GetPublicHoliday(Country.Philippines).Items.ToList();
            var sprint = JiraTicketService.GetSprints().Values.Where(v => v.Id == sprintId).Select(x => new Sprint
            {
                Name = x.Name,
                StartDate = DateTime.Parse(x.StartDate).ToLocalTime(),
                EndDate = DateTime.Parse(x.EndDate).ToLocalTime(),
            }).SingleOrDefault();


            startDate = sprint.StartDate;
            endDate = sprint.EndDate;
            
            foreach (var a in au)
            {
                var t = DateTime.Parse(a.Start.Date).ToLocalTime();
                if (t >= startDate && t <= endDate)
                {
                    result.Add(new PublicHolidayModel
                    {

                        HolidayDate = a.Start.Date,
                        Description = a.Description,
                        Summary = a.Summary,
                    });
                }

            };

            foreach (var a in pa)
            {
                var t = DateTime.Parse(a.Start.Date).ToLocalTime();
                if (t >= startDate && t <= endDate)
                {
                    result.Add(new PublicHolidayModel
                    {

                        HolidayDate = a.Start.Date,
                        Description = a.Description,
                        Summary = a.Summary,
                    });
                }

            };

            foreach (var a in ph)
            {
                var t = DateTime.Parse(a.Start.Date).ToLocalTime();
                if (t >= startDate && t <= endDate)
                {
                    result.Add(new PublicHolidayModel
                    {

                        HolidayDate = a.Start.Date,
                        Description = a.Description,
                        Summary = a.Summary,
                    });
                }

            };

            return result;
        }

    }
}
