using Microsoft.AspNetCore.Mvc;
using ToDoApp.IServices;
using ToDoApp.Models;

public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }

    /// <summary>
    /// Displays a list of all tasks.
    /// </summary>
    /// <returns>The Index view with a list of tasks.</returns>
    public IActionResult Index()
    {
        ViewBag.ErrorMessage = TempData["ErrorMessage"];
        ViewBag.SuccessMessage = TempData["SuccessMessage"];
        var tasks = _taskService.GetAllTasks().OrderBy(task => task.Priority).ToList();
        if (tasks == null)
        {
            tasks = new List<TaskItem>();
        }
        return View(tasks);
    }

    /// <summary>
    /// Displays the form for creating a new task.
    /// </summary>
    /// <returns>The Create view.</returns>
    [HttpGet]
    public IActionResult Create() => View();

    /// <summary>
    /// Handles the form submission for creating a new task.
    /// </summary>
    /// <param name="task">The task to create.</param>
    /// <returns>Redirects to the Index view if successful; otherwise, returns the Create view with validation errors.</returns>
    [HttpPost]
    public IActionResult Create(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _taskService.AddTask(task);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }
        return View(task);
    }

    /// <summary>
    /// Displays the form for editing an existing task.
    /// </summary>
    /// <param name="id">The ID of the task to edit.</param>
    /// <returns>The Edit view with the task data, or NotFound if the task is not found.</returns>
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _taskService.GetAllTasks().FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();
        return View(task);
    }

    /// <summary>
    /// Handles the form submission for editing an existing task.
    /// </summary>
    /// <param name="task">The updated task data.</param>
    /// <returns>Redirects to the Index view if successful; otherwise, returns the Edit view with validation errors.</returns>
    [HttpPost]
    public IActionResult Edit(TaskItem task)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _taskService.EditTask(task);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }
        return View(task);
    }

    /// <summary>
    /// Handles the deletion of a task.
    /// </summary>
    /// <param name="id">The ID of the task to delete.</param>
    /// <returns>Redirects to the Index view after deletion.</returns>
    [HttpPost]
    public IActionResult Delete(int id)
    {
        try
        {
            _taskService.DeleteTask(id);
            TempData["SuccessMessage"] = "Task deleted successfully.";
        }
        catch (InvalidOperationException ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return RedirectToAction("Index");
    }
}
