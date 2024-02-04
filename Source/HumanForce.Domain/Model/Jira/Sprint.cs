using System;
namespace HumanForce.Domain.Model.Jira
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
