using Moq;
using ToDoApp.Models;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.IServices;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;

public class MockTaskControllerTests
{
    [Fact]
    public void Index_ShouldReturnViewWithTasks()
    {
        // Arrange
        var mockTaskService = new Mock<ITaskService>();
        var sampleTasks = new List<TaskItem>
    {
        new TaskItem { Id = 1, Name = "Task 1", Priority = 1, Status = ToDoApp.Enums.TaskStatus.NotStarted },
        new TaskItem { Id = 2, Name = "Task 2", Priority = 2, Status = ToDoApp.Enums.TaskStatus.InProgress }
    };

        mockTaskService.Setup(service => service.GetAllTasks()).Returns(sampleTasks);

        var controller = new TaskController(mockTaskService.Object)
        {
            TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>())
        };

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Model); // Ensure the model is not null
        Assert.Equal(sampleTasks, result.Model);
        mockTaskService.Verify(service => service.GetAllTasks(), Times.Once);
    }
}
