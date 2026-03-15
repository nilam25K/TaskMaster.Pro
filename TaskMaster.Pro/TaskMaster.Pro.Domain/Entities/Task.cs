using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Shared.Enums;
using TaskStatus = TaskMaster.Pro.Shared.Enums.TaskStatus;

namespace TaskMaster.Pro.Domain.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskStatus Status { get; set; }
        public Priority Priority { get; set; }
        public Guid? AssigneeId { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
