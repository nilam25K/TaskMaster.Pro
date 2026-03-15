using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Shared.Enums;
using TaskStatus = TaskMaster.Pro.Shared.Enums.TaskStatus;

namespace TaskMaster.Pro.Shared.DTOs
{
    public record CreateTaskDto(string Title, string? Description, TaskStatus Status, Priority Priority, Guid ProjectId);
    public record TaskDto(Guid Id, string Title, TaskStatus Status, Priority Priority);

}
