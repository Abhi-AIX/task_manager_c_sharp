using System;
using System.Globalization;
using TaskManagerProject;

Console.WriteLine("Simple Task Manager Console Application");

MyTask[] arrayTasks = new MyTask[30];

MyTask[] templates = new MyTask[]
{
    new MyTask(0, "Write Weekly Report", "Summarize weekly progress", 2),
    new MyTask(0, "Team Standup", "Daily status meeting", 1),
    new MyTask(0, "Client Feedback Review", "Go through client notes", 3),
};

int[] matchingIndexes = new int[arrayTasks.Length];

// 'isExit' is a value type (bool), stored on the stack. The Data is stored directly at that memory address.
bool isExit = false;

// 'taskCount' is a value type (int), stored on the stack.
uint taskCount = 0;

//uint is unsigned integer contains only positive numbers, try to use uint for counters, indexes, quantities, sizes.
//to use byte declare byte as sbyte.
uint priority = 0;

while (!isExit)
{
    Console.WriteLine("\n");
    Console.WriteLine(
        " 1. Add Task\n 2. Create task from template\n 3. delete task\n 4. Mark as completed\n 5. Display all tasks\n 6. Estimate cost for [Project/task]\n 7. exit"
    );
    Console.WriteLine("\n");

    string options = Console.ReadLine().Trim();

    if (!string.IsNullOrEmpty(options) && int.TryParse(options, out int result))
    {

        if (taskCount>=0 && taskCount>=arrayTasks.Length) { 
        
            int newSize = arrayTasks.Length + 20;

            Array.Resize(ref arrayTasks, newSize);

            Console.WriteLine($"Task capacity expanded to {newSize}. You can now add more tasks.");

        }

        switch (result)
        {
            case 1:

                Console.Write("Enter the title:");
                string title = Console.ReadLine();

                Console.Write("Enter the Description:");
                string description = Console.ReadLine();

                addTask(title, description);

                break;

            case 2:

                createTaskFromTemplate();

                break;

            case 3:

                deleteTask();

                break;

            case 4:

                markAsCompleted();

                break;

            case 5:

                displayAllTasks();

                break;

            case 6:
                estimateTaskCost();
                break;

            case 7:

                isExit = true;

                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}

void addTask(string title, string description)
{
    uint result = 0;

    if (taskCount >= arrayTasks.Length)
    {
        Console.WriteLine("Array is Full");
        return;
    }

    Console.WriteLine("Enter the priority of task from (1-5):");
    string priorityInput = Console.ReadLine().Trim().ToLower();

    bool isValid =
        !string.IsNullOrEmpty(priorityInput)
        && uint.TryParse(priorityInput, out result)
        && priority >= 1
        && priority <= 5;
    //uint is unsigned integer contains only positive numbers, try to use uint for counters

    if (isValid)
    {
        Console.WriteLine("Invalid input.");
    }

    //Variables of reference types store references to their data (objects), that is they point to data values stored somewhere else.
    MyTask newTask = new MyTask(taskCount + 1, title, description, result);
    arrayTasks[taskCount] = newTask;
    taskCount++;

    Console.WriteLine("Task added successfully.");
}

void deleteTask()
{
    bool isDeleted = false;
    string deleteIndex = "";

    //getMatchingIndexes();
    displayAllTasks();

    if (taskCount == 0)
    {
        Console.WriteLine("No tasks available to delete.");
        return;
    }

    while (!isDeleted)
    {
        Console.Write("Please enter a task number to delete:");
        deleteIndex = Console.ReadLine().Trim().ToLower();

        /*
                for (int i = 0; i < matchCount; i++)
                {
                    if (deleteIndex == matchingIndexes[i])
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Invalid input");
                }
            }*/

        if (
            !string.IsNullOrEmpty(deleteIndex)
            && int.TryParse(deleteIndex, out int result)
            && result >= 0
            && result < taskCount
            && arrayTasks[result] != null
        )
        {
            string deleteTitle = arrayTasks[result].title;

            for (int i = result; i < arrayTasks.Length - 1; i++)
            {
                arrayTasks[i] = arrayTasks[i + 1];
            }

            isDeleted = true;
            arrayTasks[taskCount - 1] = null;
            taskCount--;

            Console.WriteLine($"{deleteTitle} successfully deleted ");
        }
    }

    if (!isDeleted)
    {
        Console.WriteLine("Invalid input");
    }
}

void markAsCompleted()
{
    bool isUpdated = false;

    //getMatchingIndexes();

    displayAllTasks();

    string updateStatusIndex = "";

    while (!isUpdated)
    {
        Console.Write("Please enter a task number to updateStatus:");
        updateStatusIndex = Console.ReadLine().ToLower();

        if (
            !string.IsNullOrEmpty(updateStatusIndex)
            && int.TryParse(updateStatusIndex, out int result)
            && result >= 0
            && result < taskCount
            && arrayTasks[result] != null
        )
        {
            isUpdated = true;
            arrayTasks[result].isCompleted = true;
            Console.WriteLine($"Task {arrayTasks[result].title} marked as completed.");
            break;
        }
    }

    if (!isUpdated)
    {
        Console.WriteLine("invalid input");
    }
}

void displayAllTasks()
{
    if (taskCount > 0)
    {
        for (int i = 0; i < arrayTasks.Length; i++)
        {
            if (arrayTasks[i] != null && !string.IsNullOrEmpty(arrayTasks[i].title))
            {
                Console.WriteLine(
                    $"id: [{i}] | title: {arrayTasks[i].title} | Description: {arrayTasks[i].description} | status: {(arrayTasks[i].isCompleted ? "completed" : "pending")} | priority: {arrayTasks[i].priority}"
                );
            }
        }
    }
    else
    {
        Console.WriteLine("No tasks added to display.");
    }
}

void createTaskFromTemplate()
{
    int templateNumber = 0;

    if (taskCount >= arrayTasks.Length)
    {
        Console.WriteLine("Task list is full.");
        return;
    }

    for (int i = 0; i < templates.Length; i++)
    {
        Console.WriteLine(
            $"{i} | {templates[i].title} | {templates[i].description} | {templates[i].priority}"
        );
    }

    Console.WriteLine("\n");

    Console.WriteLine("choose the template and enter the template number:");

    string input = Console.ReadLine().Trim().ToLower();

    bool isValid =
        !string.IsNullOrEmpty(input)
        && int.TryParse(input, out templateNumber)
        && templateNumber < templates.Length
        && templateNumber >= 0;

    if (!isValid)
    {
        Console.WriteLine("Please choose the valid template number");
    }

    //All reference types such as objects, strings, arrays... stored in heap memory.
    // Here we're not creating a new object — just assigning the same reference (memory address).
    MyTask selectedTemplate = templates[templateNumber];

    //When we are working with objects make sure your requirement need shallow copy or deep copy.
    // arrayTask[Taskcount] = selectedTemplate;
    //That means both are pointing to same memory address changes to one will affect another.
    //So always prefer deep copy through creation a new object.

    arrayTasks[taskCount] = new MyTask(
        taskCount + 1,
        selectedTemplate.title,
        selectedTemplate.description,
        selectedTemplate.priority
    );

    Console.WriteLine("task created successfully.");

    taskCount++;
}

void estimateTaskCost()
{
    //we will learn data types conversions and couple of methods over here

    Console.WriteLine("Enter the hours:");
    string hoursInput = Console.ReadLine().Trim();

    Console.WriteLine("Enter the cost:");
    string costInput = Console.ReadLine().Trim();

    //Use trim to remove any white spaces in input.
    //Then validate using bool variables if inputs are valid.
    //As we are performing calculations related to cost use decimal for most accurate result.

    decimal hour = 0;
    decimal cost = 0;

    /*For Conversion we have 4 methods (lets say 4 options)
     
     * int.Parse() - If user didn't gave number as input throws runtime exception application crashed, Use it for direct conversion when you have a hard coded values
     * int.TryParse(input, int out result) - Safe because it is boolean method if conversion failed it returns false simply, mostly used with input forms, user input real world.
     * int.Convert.ToInt32() - These method will rounds up the input, So this can even manipulate user input. Use this when you want to round up data.
     * Narrowing conversion(Explicit Conversion) - decimal cost = (int) cost; - This will truncate the data, so doesn't work.
     
     */

    
    bool isHour = !string.IsNullOrEmpty(hoursInput) && decimal.TryParse(hoursInput, out hour); //When calling a method with an out parameter, you must use the keyword out before the variable, which holds the value.
    bool isCost = !string.IsNullOrEmpty(costInput) && decimal.TryParse(costInput, out cost);   //The out parameter is assigned to the result variable in the code (int.TryParse(value, out result).

    decimal totalCost = hour * cost;

    //Narrowing Conversion

    int totalCostTruncate = (int)totalCost;

    int totalCostRoundUp = Convert.ToInt32(totalCost);

    //To estimate cost we need to convert those strings into numbers.

    Console.WriteLine($"Total estimate of exact cost: {totalCost}");
    Console.WriteLine($"Total estimate of truncated cost: {totalCostTruncate}");
    Console.WriteLine($"Total estimate of Round Up cost : {totalCostRoundUp}");

    //There is also one more conversion implicit conversion - Compiler will take care of it if we are trying to convert smaller data type into bigger data type.
    //Example int to decimal | int -> long | short -> int |
    //I have used this in application but written for learning purpose
}


/*
void getMatchingIndexes()
{
    matchCount = 0;

    Console.WriteLine("Please Enter the title:");
    string verifyTitle = Console.ReadLine();
    Console.WriteLine("\n");

    for (int i = 0; i < arrayTasks.Length; i++)
    {
        if (arrayTasks[i] != null && verifyTitle.Equals(arrayTasks[i].title))
        {
            matchingIndexes[matchCount] = i;
            matchCount++;
        }
    }

    if (matchCount > 0)
    {
        for (int i = 0; i < matchCount; i++)
        {
            Console.WriteLine($"{matchingIndexes[i]} : {arrayTasks[matchingIndexes[i]].title}");
        }
    }
    else
    {
        Console.WriteLine("No Matches Found");
    }
}*/
