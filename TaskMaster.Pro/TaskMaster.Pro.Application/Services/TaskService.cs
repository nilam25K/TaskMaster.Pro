using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Application.Interfaces;
using TaskMaster.Pro.Domain.Entities;
using TaskMaster.Pro.Shared.DTOs;

namespace TaskMaster.Pro.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
            var tasks = await _repository.GetAllAsync();
            return tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority
            });
        }

        public async Task<TaskDto?> GetTaskAsync(Guid id)
        {
            var task = await _repository.GetByIdAsync(id);
            return task == null ? null : new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority
            };
        }

        public async Task<TaskDto> CreateAsync(CreateTaskDto dto)
        {
            var task = new TaskEntity
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                Priority = dto.Priority,
                AssigneeId = dto.AssigneeId
            };
            var result = await _repository.CreateAsync(task);
            return new TaskDto
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Status = result.Status,
                Priority = result.Priority
            };
        }

        public async Task UpdateAsync(Guid id, UpdateTaskDto dto)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task != null)
            {
                task.Title = dto.Title;
                task.Description = dto.Description;
                task.Status = dto.Status;
                task.Priority = dto.Priority;
                await _repository.UpdateAsync(task);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
