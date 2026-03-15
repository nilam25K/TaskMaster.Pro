using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Pro.Domain.Entities
{
    public class ProjectEntity
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
    }
}
