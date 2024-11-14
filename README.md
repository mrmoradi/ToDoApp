
# ToDoApp

ToDoApp is a web-based application designed to help users manage their tasks efficiently. This application allows users to create, view, edit, and delete tasks, with task priority and status management features. The project is built using ASP.NET Core MVC, C#, and is integrated with Bootstrap for responsive design.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Running Tests](#running-tests)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Task Creation**: Users can add new tasks with a name, priority, and status.
- **Task Viewing**: View a list of all tasks, sorted by priority.
- **Task Editing**: Modify existing task details.
- **Task Deletion**: Delete tasks with confirmation.
- **User Notifications**: Success and error messages are displayed to inform users of their actions.

## Technologies Used

- **ASP.NET Core MVC**: Backend framework for building the web application.
- **C#**: Programming language used for backend logic.
- **Bootstrap**: For responsive design and modal components.
- **Moq**: For mocking services in unit tests.
- **xUnit**: Testing framework for unit testing the application.
- **HTML/CSS**: For structuring and styling the front-end.

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/ToDoApp.git
   cd ToDoApp
   ```

2. **Set up the project in your IDE**:
   - Open the project in Visual Studio or your preferred C# IDE.
   - Ensure that you have the required .NET SDK installed.

3. **Install necessary NuGet packages**:
   - Ensure that `Moq`, `xUnit`, and `Microsoft.AspNetCore.Mvc` are installed as needed.

4. **Run the project**:
   - Build and run the project using the following command:
     ```bash
     dotnet run
     ```

## Usage

- Navigate to `http://localhost:5000` (or your configured URL) to view the ToDoApp homepage.
- Use the **Create New Task** button to add tasks.
- View and manage tasks directly from the list.
- Edit tasks by clicking the **Edit** button.
- Delete tasks by clicking the **Delete** button, which triggers a custom confirmation modal.

### Custom Confirmation Modal

The project includes a custom modal for task deletion confirmation:
- A modal is displayed when the **Delete** button is clicked.
- The modal confirms whether the user wants to delete the task.
- If confirmed, a form is programmatically submitted to delete the task.

## Running Tests

The project includes unit tests for controller actions:

1. **Run tests using the .NET CLI**:
   ```bash
   dotnet test
   ```

2. **Test Details**:
   - Tests cover task retrieval, creation, editing, and deletion.
   - The `Mock` framework is used for mocking dependencies.

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`feature/your-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a Pull Request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

---

Feel free to explore, modify, and contribute to the ToDoApp!
