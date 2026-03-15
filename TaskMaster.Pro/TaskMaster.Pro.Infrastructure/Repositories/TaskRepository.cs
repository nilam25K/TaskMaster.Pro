using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Pro.Application.Interfaces;
using TaskMaster.Pro.Domain.Entities;
using TaskMaster.Pro.Infrastructure.Data;
using TaskMaster.Pro.Shared.DTOs;

namespace TaskMaster.Pro.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<TaskDto> CreateAsync(CreateTaskDto dto, CancellationToken ct = default)
        {
            var task = new TaskEntity
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                Priority = dto.Priority,
                ProjectId = dto.ProjectId
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync(ct);
            return new TaskDto(task.Id, task.Title, task.Status, task.Priority);
        }

        public async Task<List<TaskDto>> GetByProjectAsync(Guid projectId, CancellationToken ct = default)
        {
            var tasks = await _context.Tasks
           .Where(t => t.ProjectId == projectId)
           .ToListAsync(ct);

            return tasks.Select(t => new TaskDto(t.Id, t.Title, t.Status, t.Priority)).ToList();
        }
    }
}
