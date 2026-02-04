using ComplaintManagementSystem.Application.Interfaces;
using ComplaintManagementSystem.Domain.Entities;
using ComplaintManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Infrastructure.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly AppDbContext _context;
        public ComplaintRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Complaint complaint)
        {
            _context.Complaints.Add(complaint);
            _context.SaveChanges();
        }

        //public async Task AddAsync(Complaint complaint)
        //{
        //    await _context.Complaints.AddAsync(complaint);
        //    await _context.SaveChangesAsync();
        //}

    }
}
