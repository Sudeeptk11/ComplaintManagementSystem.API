using ComplaintManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Domain.Entities
{
    public class Complaint : BaseEntity
    {
        public String Title { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public int UserId { get; private set; }
        public Complaint() { }

        public Complaint(String title, String description, int userId)
        {
            Title = title;
            Description = description;
            Status = ComplaintStatus.Pending;   
            UserId = userId;
        }

        public void MarkInProgress()
        {
            Status = "In Progress";
        }
        public void Resolve()
        {
            Status = "Resolved";
        }
    }
}
