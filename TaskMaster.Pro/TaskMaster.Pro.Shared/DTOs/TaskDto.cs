using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Shared.Enums;
using TaskStatus = TaskMaster.Pro.Shared.Enums.TaskStatus;

namespace TaskMaster.Pro.Shared.DTOs
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;        
        public TaskStatus Status { get; set; }
        public Priority Priority { get; set; }
        public string? Description { get; set; }
    }
}
