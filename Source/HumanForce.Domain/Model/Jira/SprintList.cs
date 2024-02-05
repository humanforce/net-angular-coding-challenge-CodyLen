using System;
using System.Collections.Generic;

namespace HumanForce.Domain.Model.Jira
{
    public class SprintList
    {
        public List<Value> Values { get; set; }
    }

    public class Value
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
