using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Shared.DTOs;

namespace TaskMaster.Pro.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskDto> CreateAsync(CreateTaskDto dto, CancellationToken ct);
        Task<List<TaskDto>> GetByProjectAsync(Guid projectId, CancellationToken ct);
    }
}
