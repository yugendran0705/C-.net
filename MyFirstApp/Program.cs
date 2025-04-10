List<string> tasks = [];
bool isRunning = true;
Console.WriteLine("1. Add Task\n2. View Tasks\n3. Remove Task\n4. Exit");
while (isRunning)
{
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine() ?? string.Empty;
    switch (choice)
    {
        case "1":
            Console.Write("Enter task: ");
            string task = Console.ReadLine() ?? string.Empty;
            task = task.Trim();
            task = char.ToUpper(task[0]) + task[1..];
            tasks.Add(task);
            break;
        case "2":
            Console.WriteLine("\nTasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
            Console.WriteLine();
            break;
        case "3":
            Console.Write("Enter task number to remove: ");
            int taskNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                tasks.RemoveAt(taskNumber);
                Console.WriteLine("Task removed.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
            break;
        case "4":
            isRunning = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}
