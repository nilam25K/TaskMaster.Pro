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

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskEntity> CreateAsync(TaskEntity task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task UpdateAsync(TaskEntity task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
        //public async Task<TaskDto> CreateAsync(CreateTaskDto dto, CancellationToken ct = default)
        //{
        //    var task = new TaskEntity
        //    {
        //        Title = dto.Title,
        //        Description = dto.Description,
        //        Status = dto.Status,
        //        Priority = dto.Priority,
        //        AssigneeId = dto.AssigneeId
        //    };
        //    _context.Tasks.Add(task);
        //    await _context.SaveChangesAsync(ct);

        //    return new TaskDto
        //    {
        //        Id = task.Id,
        //        Title = task.Title,
        //        Description = task.Description,
        //        Status = task.Status,
        //        Priority = task.Priority
        //    };
        //    //return new TaskDto(task.Id, task.Title, task.Status, task.Priority,task.Description);
        //}

        //public async Task<List<TaskDto>> GetByProjectAsync(Guid projectId, CancellationToken ct = default)
        //{
        //    var tasks = await _context.Tasks
        //   .Where(t => t.ProjectId == projectId)
        //   .ToListAsync(ct);

        //    return tasks.Select(t => new TaskDto
        //    {
        //        Id = t.Id,
        //        Title = t.Title,
        //        Description = t.Description,
        //        Status = t.Status,
        //        Priority = t.Priority
        //    }).ToList();

        //    //return tasks.Select(t => new TaskDto(t.Id, t.Title, t.Status, t.Priority)).ToList();
        //}
    }
}
