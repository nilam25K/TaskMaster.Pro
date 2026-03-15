using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Shared.Enums;

namespace TaskMaster.Pro.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; }= string.Empty;
        public UserRole Role { get; set; }
    }

   
}
