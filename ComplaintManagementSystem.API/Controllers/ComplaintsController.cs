using ComplaintManagementSystem.Application.DTOs;
using ComplaintManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintManagementSystem.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaintService _complaintService;
        public ComplaintsController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpPost]
        public IActionResult Create (CreateComplaintDto dto)
        {
            _complaintService.CreateComplaint(dto);
            return Ok(new { message = "Complaint created successfully" });
        }

        [HttpGet("test-error")]
        public IActionResult TestError()
        {
            throw new Exception("TEST EXCEPTION");
        }

    }
}
