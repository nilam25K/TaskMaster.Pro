using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Pro.Infrastructure.Identity
{
    public class ApplicationUser :IdentityUser
    {
        // Custom properties for TaskMaster.Pro:
        public string? FullName { get; set; }
        public Guid? DefaultProjectId { get; set; }
    }
}
