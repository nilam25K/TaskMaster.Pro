using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskMaster.Pro.Domain.Entities;
using TaskMaster.Pro.Infrastructure.Data;

namespace TaskMaster.Pro.Web.Controllers
{
    [Authorize]
    public class TaskEntitiesController : Controller
    {
        private readonly AppDbContext _context;

        public TaskEntitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TaskEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        // GET: TaskEntities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntity = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEntity == null)
            {
                return NotFound();
            }

            return View(taskEntity);
        }

        // GET: TaskEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Status,Priority,AssigneeId,ProjectId,CreatedAt")] TaskEntity taskEntity)
        {
            if (ModelState.IsValid)
            {
                taskEntity.Id = Guid.NewGuid();
                _context.Add(taskEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskEntity);
        }

        // GET: TaskEntities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntity = await _context.Tasks.FindAsync(id);
            if (taskEntity == null)
            {
                return NotFound();
            }
            return View(taskEntity);
        }

        // POST: TaskEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Status,Priority,AssigneeId,ProjectId,CreatedAt")] TaskEntity taskEntity)
        {
            if (id != taskEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskEntityExists(taskEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(taskEntity);
        }

        // GET: TaskEntities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskEntity = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskEntity == null)
            {
                return NotFound();
            }

            return View(taskEntity);
        }

        // POST: TaskEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var taskEntity = await _context.Tasks.FindAsync(id);
            if (taskEntity != null)
            {
                _context.Tasks.Remove(taskEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskEntityExists(Guid id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
