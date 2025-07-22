using ModelTask;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            bool hasTasks = taskManager.ReadTaskFromFiles();

            if (!hasTasks)
            {
                System.Console.WriteLine("Não possui tarefas cadastradas.");
            }
        }
    }
}
