using ComplaintManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Application.Interfaces
{
    public interface IComplaintService
    {
        void CreateComplaint(CreateComplaintDto dto);
    }
}
