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
                System.Console.WriteLine("[1] ADICIONAR NOVA TAREFA");
                System.Console.WriteLine("[2] LISTAR TAREFAS");
                System.Console.WriteLine("[3] LISTAR TAREFAS CONCLUÍDAS");
                int input = 0;
                int[] options = { 1, 2, 3 };
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
                        System.Console.WriteLine("Escolha um número entre as opções acima.");
                    }
                }
                catch (FormatException)
                {   
                    Console.Clear();
                    System.Console.WriteLine("Digite um número inteiro entre as opções acima.");
                }
            }
        }

        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            bool hasTasks = taskManager.ReadTaskFromFiles();
            int inputMenuInicial = PrintMenu();

            switch (inputMenuInicial)
            {
                case 1:
                    break;
                case 2:
                    taskManager.ListTasks();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            
        }

        
    }
}
