using ComplaintManagementSystem.Application.DTOs;
using ComplaintManagementSystem.Application.Interfaces;
using ComplaintManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Application.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _repository;
        public ComplaintService(IComplaintRepository repository)
        {
            _repository = repository;
        }
        public void CreateComplaint(CreateComplaintDto dto)
        {
            var complaint = new Complaint(
                dto.Title,
                dto.Description,
                dto.UserId
            );
            _repository.Add(complaint);
        }
    }
}
