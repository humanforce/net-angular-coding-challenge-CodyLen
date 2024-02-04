using System;
using System.Collections.Generic;

namespace HumanForce.Domain.Model.PublicHoliday
{
    public class PublicHoliday
    {
        public string Summary { get; set; }
        public List<Item> Items { get; set; }
    }
}
