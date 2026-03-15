using Microsoft.AspNetCore.Mvc;
using TaskMaster.Pro.Application.Services;

namespace TaskMaster.Pro.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;
        public TasksController(TaskService taskService) => _taskService = taskService;

        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetTasksAsync();
            return View(tasks);
        }
       
    }
}
