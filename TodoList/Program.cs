string[] todoList = new string[20];
int totalTasks = todoList.Length;
string welcomeMessage = "Welcome To Your To-Do List. Please an option from below: \n\n1. View All Current Tasks\n2. Add a Task.\n3. Delete a Task.\n4. Show current tasks total.\n5. Close App.";
string currentTask = "?";
string input = "";
string newTask;

todoList[0] = "-Say Hello to the World!";

while (!ExitApp())
{
    InitializeApp();
    input = Console.ReadLine();

    switch (input)
    {
        case "1":
            ShowList();
            Console.ReadLine();
            break;

        case "2":
            CurrentTasks();
            string anotherTask = "y";
            bool validEntry = false;
            if (CurrentTasks() < totalTasks)
            {
                do
                {
                    Console.WriteLine($"You can still add up to {(totalTasks - CurrentTasks())} tasks to your list.\n Enter (y/n) to continue.");
                    input = Console.ReadLine();
                    if (input != null)
                    {
                        anotherTask = input.ToLower();
                    }
                } while (anotherTask != "y" && anotherTask != "n");
            }

            while (anotherTask == "y" && CurrentTasks() < totalTasks && validEntry == false)
            {
                Console.WriteLine("Enter a new task here: ");
                newTask = Console.ReadLine();
                if (newTask != null)
                {
                    validEntry = true;
                    if (validEntry)
                    {
                        todoList[CurrentTasks()] = newTask;
                        Console.WriteLine("New task added!");
                        Console.ReadLine();
                    }
                }
                else
                {
                    validEntry = false;
                }

                //   while (anotherTask != "y" && anotherTask != "n") ;

            }

            if (CurrentTasks() >= totalTasks)
            {
                Console.Write("You've entered maximum to-dos in your list!");
            }


            break;

        case "3":
            Console.WriteLine("Enter index number of list to delete.");
            DeleteTask();
            Console.ReadLine();
            break;

        case "4":
            ShowCurrentTotal();
            break;

        case "5":
            ExitApp();
            break;

        default:
            ExitApp();
            break;
    }
}



// void EditTask()

void ShowList()
{
    int count = 0;
    Console.WriteLine("Current Tasks: \n");
    for (int i = 0; i < todoList.Length; i++)
    {
        if (todoList[i] != null)
        {
            count++;
            currentTask = todoList[i];
            Console.Write($"{count}-\t{currentTask}\n");
        }
    }
}
int CurrentTasks()
{
    int count = 0;
    for (int i = 0; i < totalTasks; i++)
    {
        if (todoList[i] != null)
        {
            count++;
        }
    }
    return count;
}

void InitializeApp()
{
    Console.WriteLine(welcomeMessage);
}
bool ExitApp()
{
    return input == "5";
}
void ShowCurrentTotal()
{
    int currentTask = 0;
    for (int i = 0; i < todoList.Length; i++)
    {
        if (todoList[i] != null)
        {
            currentTask++;
        }
    }
    Console.Write($"You have {currentTask} To-Dos left on your list!");
    Console.ReadLine();
}

void DeleteTask()
{
    int selectedTask;
    int taskLength;
    int selected = 0;
    input = Console.ReadLine();
    while (selected == 0)
    {
        if (int.TryParse(input, out selected))
        {
           selectedTask = selected - 1;
           taskLength = todoList[selectedTask].Length;
           todoList[(selectedTask)] = null;
           Console.Write($"You have successfully deleted list {selected} from your current To-Do list.");
            return;
        }
        else
        {
            Console.Write($"invalid input. Enter index number of list to delete.");
            return;
        }
    }
}