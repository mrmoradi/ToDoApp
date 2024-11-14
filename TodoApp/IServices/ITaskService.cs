using ToDoApp.Models;

namespace ToDoApp.IServices
{
    /// <summary>
    /// Defines the contract for task management services in the ToDo application.
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Retrieves all tasks.
        /// </summary>
        /// <returns>An IEnumerable collection of TaskItem objects.</returns>
        IEnumerable<TaskItem> GetAllTasks();

        /// <summary>
        /// Adds a new task to the collection.
        /// </summary>
        /// <param name="task">The task to be added.</param>
        void AddTask(TaskItem task);

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="updatedTask">The updated task data.</param>
        void EditTask(TaskItem updatedTask);

        /// <summary>
        /// Deletes a task based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the task to be deleted.</param>
        void DeleteTask(int id);
    }
}
