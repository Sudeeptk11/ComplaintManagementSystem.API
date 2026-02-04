using ComplaintManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Application.Interfaces
{
    public interface IComplaintRepository
    {
        void Add(Complaint complaint);
    }
}
