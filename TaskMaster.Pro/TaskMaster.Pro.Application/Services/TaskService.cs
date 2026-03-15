using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Application.Interfaces;
using TaskMaster.Pro.Shared.DTOs;

namespace TaskMaster.Pro.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskDto> CreateAsync(CreateTaskDto dto, CancellationToken ct)
        {
            // Business logic here (validation, etc.)
            return await _repository.CreateAsync(dto, ct);
        }
        public async Task<List<TaskDto>> GetTasksAsync(CancellationToken ct = default)
        {
            // For demo, return empty list or get all tasks
            // Later: add projectId parameter
            return new List<TaskDto>();
        }

    }
}
