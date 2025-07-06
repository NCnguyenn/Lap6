namespace Lap6
{
    internal class Program
    {
        public static void AddTask(string[] list, ref int count)
        {
            if (count >= list.Length)
            {
                Console.WriteLine("Task list is full");
                return;
            }

            Console.Write("Enter new task: ");
            string newTask = Console.ReadLine();
            list[count] = newTask;
            Console.WriteLine("Task added successfully.");
            count++;
        }

        public static void ListTask(string[] list, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("The task list is empty.");
                return;
            }

            Console.WriteLine("Your tasks:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i]}");
            }
        }

        public static void RemoveTask(string[] list, ref int count)
        {
            if (count == 0)
            {
                Console.WriteLine("The task list is empty. Nothing to remove.");
                return;
            }

            Console.Write("Enter the task number to remove: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int index);

            if (!isValid || index < 1 || index > count)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }

            for (int i = index - 1; i < count - 1; i++)
            {
                list[i] = list[i + 1];
            }

            list[count - 1] = null;
            count--;
            Console.WriteLine("Task removed successfully.");
        }

        public static void SearchTask(string[] list, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("The task list is empty. Nothing to search.");
                return;
            }

            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine().ToLower();

            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (list[i].ToLower().Contains(keyword))
                {
                    Console.WriteLine($"{i + 1}. {list[i]}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching tasks found.");
            }
        }

        public static void UpdateTask(string[] list, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("The task list is empty. Nothing to update.");
                return;
            }

            Console.Write("Enter the task number to update: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int index);

            if (!isValid || index < 1 || index > count)
            {
                Console.WriteLine("Invalid task number.");
                return;
            }

            Console.Write("Enter the updated task description: ");
            string updatedTask = Console.ReadLine();
            list[index - 1] = updatedTask;
            Console.WriteLine("Task updated successfully.");
        }

        static void Main(string[] args)
        {
            int count = 0;
            string[] taskList = new string[10];

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. List tasks");
                Console.WriteLine("3. Remove task");
                Console.WriteLine("4. Search task");
                Console.WriteLine("5. Update task");
                Console.WriteLine("6. Exit");

                Console.Write("Your choice: ");
                string input = Console.ReadLine();
                bool isValidChoice = int.TryParse(input, out int choice);

                if (!isValidChoice)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddTask(taskList, ref count);
                        break;
                    case 2:
                        ListTask(taskList, count);
                        break;
                    case 3:
                        RemoveTask(taskList, ref count);
                        break;
                    case 4:
                        SearchTask(taskList, count);
                        break;
                    case 5:
                        UpdateTask(taskList, count);
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
