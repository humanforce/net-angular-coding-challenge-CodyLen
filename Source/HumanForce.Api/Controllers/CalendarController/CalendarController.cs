using System;
using System.Collections.Generic;
using HumanForce.Api.Controllers.CalendarController.Models;
using HumanForce.Domain.Enums;
using HumanForce.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HumanForce.Api.Controllers.CalendarController
{
    [Route("[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {

        public CalendarController(ICalendarService jiraTicketService)
        {
            CalendarService = jiraTicketService;
        }

        protected ICalendarService CalendarService { get; }


        [HttpGet("getholiday")]
        public IActionResult GetCalendar(Country country)
        {
            var result = getPublicHolidayByCountry(country);
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

    }
}
