using System;
using HumanForce.Domain.Enums;
using HumanForce.Domain.Model.PublicHoliday;

namespace HumanForce.Domain.Services
{
    public interface ICalendarService
    {
        PublicHoliday GetPublicHoliday(Country country);
    }
}
