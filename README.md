# Simple Task Manager Console Application in C#

This is a clean, beginner-friendly C# console app that mimics a basic task manager. Built entirely using arrays (not lists), this project is designed to help students and aspiring developers understand C# fundamentals through a real-world console-based application.

## Features

- Add new tasks (title, description, priority)
- Create tasks from templates
- Mark tasks as completed
- Delete tasks by index
- Display all tasks
- Estimate task/project cost using accurate numeric conversions
- Auto-resize task array when reaching max capacity

## Project Structure
TaskManagerProject/
├── Program.cs // Main console logic
├── MyTask.cs // Custom class to represent a task
├── /Assets/
│ ├── Infographics/ // Concept images: value types, conversions, arrays
│ └── Docs/ // Learning PDFs

## Concepts Covered

| Concept                    | Description                                                    |
|---------------------------|----------------------------------------------------------------|
| Value vs Reference Types   | Understanding memory allocation (stack vs heap)                |
| Type Conversion & Casting  | Using TryParse, Convert, explicit casting and why they matter  |
| Deep vs Shallow Copy       | Object references and task template duplication                |
| Arrays & Dynamic Resizing  | Managing fixed-size arrays and resizing with Array.Resize      |
| Input Validation           | Avoiding crashes using TryParse with user input                |
| Cost Estimation Logic      | Working with decimal for precision, rounding, and truncation   |

## Learning Aids (PDFs + Images)

Inside the `Assets` folder:

- `Infographics/`  
  Helpful visual diagrams:
  - Value vs Reference Types
  - Implicit vs Explicit Conversion
  - Convert Class vs TryParse vs Parse

- `Docs/`  
  In-depth PDF guide with:
  - Use cases for casting and conversion
  - Decimal vs float vs double in real scenarios
  - Safe type conversion patterns
  - How to prevent runtime exceptions

## Medium Post

I documented this full project, including the logic, mistakes, insights, and key takeaways in an article here:

[Read the Full Medium Post](https://medium.com/@aibhi.dev/how-building-a-simple-task-manager-taught-me-deep-c-concepts-027ebb200199)

