using ModelTask;

namespace ToDo
{
    class Program
    {
        public static int PrintMenu()
        {   
            Console.Clear();
            

            while (true)
            {
                System.Console.WriteLine("---------- MENU ----------");
                System.Console.WriteLine("[1] LIST TASKS");
                System.Console.WriteLine("[2] LIST COMPLETED TASKS");
                int input = 0;
                int[] options = { 1, 2};
                string entrada = Console.ReadLine();
                try
                {

                    input = int.Parse(entrada);
                    if (options.Contains(input))
                    {
                        return input;
                    }
                    else
                    {   
                        Console.Clear();
                        System.Console.WriteLine("Choose a number from the options above.");
                    }
                }
                catch (FormatException)
                {   
                    Console.Clear();
                    System.Console.WriteLine("Type a whole number between the options above.");
                }
            }
        }

        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            bool hasTasks = taskManager.ReadTaskFromFiles();
            while (true)
            {
                int inputMenuStart = PrintMenu();

                if (inputMenuStart == 1)
                {
                    while (true) {
                        int inputListTasks = taskManager.ListTasks();
                        switch (inputListTasks)
                        {
                            case 1:
                                System.Console.WriteLine("TYPE A TITLE FOR YOUR TASK.");
                                string title = Console.ReadLine();
                                System.Console.WriteLine("TYPE A DESCRIPTION FOR YOUR TASK.");
                                string description = Console.ReadLine();
                                taskManager.AddTask(title, description);
                                break;

                            case 2:
                                System.Console.WriteLine("TYPE THE ID OF THE CHOSEN TASK.");
                                try
                                {
                                    int id = int.Parse(Console.ReadLine());
                                    taskManager.CompleteTask(id);
                                    break;
                                }
                                catch (FormatException)
                                {
                                    System.Console.WriteLine("THE ID IS A WHOLE NUMBER.");
                                    break;
                                }
                            
                            case 3:
                                System.Console.WriteLine("TYPE THE ID OF THE CHOSEN TASK.");
                                try
                                {
                                    int id = int.Parse(Console.ReadLine());
                                    taskManager.DeleteTask(id);
                                    break;
                                }
                                catch (FormatException)
                                {
                                    System.Console.WriteLine("THE ID IS A WHOLE NUMBER.");
                                    break;
                                }

                            default:
                                break;
                        
                        }

                    }


                }
            }
        }

        
    }
}
