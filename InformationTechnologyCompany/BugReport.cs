using System;
using System.Collections.Generic;
using System.Text;

namespace InformationTechnologyCompany
{
    public enum Status
    {
        New,
        Assigned,
        Fixed,
        Verified,
        ClosedAsDuplicate,
        ClosedNotReproducible,
        ClosedObsolete
    }
    public class BugReport
    {
        string bugId = CompanyUtil.GetGuid();
        DateTime timestamp = DateTime.UtcNow;
        string title;
        string description;
        string createById;
        string assignedToId;
        Status status = Status.New;

        public BugReport(string createById, string title, string description)
        {
            this.createById = createById;
            this.title = title;
            this.description = description;
        }

        public string BugId { get => bugId; set => bugId = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string CreateById { get => createById; set => createById = value; }
        public string AssignedToId { get => assignedToId; set => assignedToId = value; }
        public Status Status { get => status; set => status = value; }
    }
}
