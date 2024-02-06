using System;
using System.Collections.Generic;

namespace HumanForce.Domain.Model.Jira
{
    public class Ticket
    {
        public int Total { get; set; }
        public List<Issue> Issues { get; set; }
    }

    public class Issue
    {
        public string Id { get; set; }
        public Field Fields { get; set; }
    }

    public class Field
    {
        public string Customfield_10016 { get; set; }
        public Status Status { get; set; }
        public List<Customfield> Customfield_10020 { get; set; }
        public Project Project { get; set; }
        public Priority Priority { get; set; }

    }

    public class Status
    {
        public string Name { get; set; }
    }

    public class Customfield
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class Project
    {
        public string Name { get; set; }
        public string ProjectTypeKey { get; set; }
    }

    public class Priority
    {
        public string Name { get; set; }
    }
}
