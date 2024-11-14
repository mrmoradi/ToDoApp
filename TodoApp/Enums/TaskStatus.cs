using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Enums
{
    /// <summary>
    /// Represents the possible statuses of a task.
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// The task has not been started yet.
        /// </summary>
        [Display(Name = "Not Started")]
        NotStarted,

        /// <summary>
        /// The task is currently in progress.
        /// </summary>
        [Display(Name = "In Progress")]
        InProgress,

        /// <summary>
        /// The task has been completed.
        /// </summary>
        [Display(Name = "Completed")]
        Completed
    }
}
