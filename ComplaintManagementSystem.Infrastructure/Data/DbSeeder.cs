using ComplaintManagementSystem.Application.Common;
using ComplaintManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintManagementSystem.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var user = new User("Admin User",
                    "admin@test.com",
                    PasswordHasher.Hash("1234"),
                    "Admin");
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
