using System;
using System.IO;
using Ardalis.GuardClauses;
using HumanForce.Domain.Enums;
using HumanForce.Domain.Model.PublicHoliday;
using HumanForce.Domain.Services;
using Newtonsoft.Json;

namespace HumanForce.Services
{
    public class CalendarService : ICalendarService
    {
        public PublicHoliday GetPublicHoliday(Country country)
        {
            string file = "";
            switch (country)
            {
                case Country.Philippines:
                    file = @"Resources/philippines.json";
                    break;
                case Country.Pakistan:
                    file = @"Resources/pakistan.json";
                    break;
                case Country.Australia:
                    file = @"Resources/australian.json";
                    break;
            }

            var jsonResult = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<PublicHoliday>(jsonResult);
        }
    }
}
