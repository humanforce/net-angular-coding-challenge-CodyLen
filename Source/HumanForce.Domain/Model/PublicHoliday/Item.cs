using System;
namespace HumanForce.Domain.Model.PublicHoliday
{
    public class Item
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public Start Start { get; set; }
        public Creator Creator { get; set; }
    }

    public class Start
    {
        public string Date { get; set; }
    }

    public class Creator
    {
        public string DisplayName { get; set; }
    }
}
