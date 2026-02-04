using ComplaintManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash   { get; private set; }
        public string Role { get; private set; }
        public User() { }

        public User(String fullName, String email, String passwordHash, string role)
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}


//Add - Migration InitialCreate - Project ComplaintManagementSystem.Infrastructure - StartupProject ComplaintManagementSystem.API
//Update-Database -Project ComplaintManagementSystem.Infrastructure -StartupProject ComplaintManagementSystem.API

//day 8
//Install - Package FluentValidation
//Install-Package FluentValidation.AspNetCore