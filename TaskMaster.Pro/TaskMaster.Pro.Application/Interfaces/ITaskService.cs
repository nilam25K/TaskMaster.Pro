using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Shared.DTOs;

namespace TaskMaster.Pro.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetTasksAsync();
        Task<TaskDto?> GetTaskAsync(Guid id);
        Task<TaskDto> CreateAsync(CreateTaskDto dto);
        Task UpdateAsync(Guid id, UpdateTaskDto dto);
        Task DeleteAsync(Guid id);
    }
}
