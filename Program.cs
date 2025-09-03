using TodoCLI.Services;

var service = new ToDoService();
bool running = true;

while (running)
{
    Console.WriteLine("\n--- Todo List ---");
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. List tasks");
    Console.WriteLine("3. Complete task");
    Console.WriteLine("4. Delete task");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Enter task description: ");
            var desc = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(desc))
                service.AddTask(desc);
            break;

        case "2":
            service.ListTasks();
            break;

        case "3":
            Console.Write("Enter task id to complete: ");
            if (int.TryParse(Console.ReadLine(), out int id1))
                service.CompleteTask(id1);
            break;

        case "4":
            Console.Write("Enter task id to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id2))
                service.DeleteTask(id2);
            break;

        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}
