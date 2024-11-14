using ToDoApp.Models;
using ToDoApp.IServices;

namespace ToDoApp.Services
{
    /// <summary>
    /// Service class for managing tasks in the ToDo application.
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _tasks = new(); // Internal collection of tasks

        /// <summary>
        /// Retrieves all tasks sorted by priority.
        /// </summary>
        /// <returns>An IEnumerable collection of tasks sorted by priority.</returns>
        public virtual IEnumerable<TaskItem> GetAllTasks() => _tasks.OrderBy(task => task.Priority);

        /// <summary>
        /// Adds a new task to the collection.
        /// </summary>
        /// <param name="task">The task to be added.</param>
        /// <exception cref="InvalidOperationException">Thrown if a task with the same name already exists.</exception>
        public void AddTask(TaskItem task)
        {
            if (_tasks.Any(t => t.Name == task.Name))
            {
                throw new InvalidOperationException("A task with the same name already exists.");
            }
            // Automatically assigns a new ID based on the highest existing ID
            task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(task);
        }

        /// <summary>
        /// Updates an existing task in the collection.
        /// </summary>
        /// <param name="updatedTask">The updated task data.</param>
        /// <exception cref="InvalidOperationException">Thrown if a task with the same name already exists.</exception>
        public void EditTask(TaskItem updatedTask)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
            if (existingTask == null) return;

            if (_tasks.Any(t => t.Name == updatedTask.Name && t.Id != updatedTask.Id))
            {
                throw new InvalidOperationException("A task with the same name already exists.");
            }

            // Update task properties
            existingTask.Name = updatedTask.Name;
            existingTask.Priority = updatedTask.Priority;
            existingTask.Status = updatedTask.Status;
        }

        /// <summary>
        /// Deletes a task from the collection if it is marked as completed.
        /// </summary>
        /// <param name="id">The ID of the task to be deleted.</param>
        /// <exception cref="InvalidOperationException">Thrown if the task is not completed.</exception>
        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                throw new InvalidOperationException("Task not found.");
            }

            if (task.Status != ToDoApp.Enums.TaskStatus.Completed)
            {
                throw new InvalidOperationException("Cannot delete a task that is not completed.");
            }

            _tasks.Remove(task);
        }

    }
}
