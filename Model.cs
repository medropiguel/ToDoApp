// Encapsulamento

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace ModelTask

{
    public class TaskItem
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime? FinishDate { get; private set; }

        public TaskItem(int id, string title, string description, string status, DateTime startdate, DateTime? finishdate)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
            StartDate = startdate;
            FinishDate = finishdate;
        }

        public void CompleteTask() {
            Status = "COMPLETED";
            FinishDate = DateTime.Now;
        } 

    }


    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private readonly string dir = "./tasks.csv";

        public int GenerateNewId()
        {
            if (tasks.Count == 0)
            {
                return 1;
            }
            else
            {
                int max = tasks[0].Id;
                for (int i = 1; i < tasks.Count; i++)
                {
                    if (tasks[i].Id > max)
                    {
                        max = tasks[i].Id;
                    }
                }
                return max + 1;
            }
        }

        public bool ReadTaskFromFiles()
        {


            if (!File.Exists(dir)) return false;

            using (StreamReader sr = new StreamReader("./tasks.csv"))
            {
                string line;
                string[] parts;
                while ((line = sr.ReadLine()) != null)
                {
                    parts = line.Split(";");
                    tasks.Add(new TaskItem(
                                    int.Parse(parts[0]),
                                    parts[1],
                                    parts[2],
                                    parts[3],
                                    DateTime.Parse(parts[4]),
                                    string.IsNullOrWhiteSpace(parts[5]) ? (DateTime?)null : DateTime.Parse(parts[5])
                                    ));

                }
            }
            return tasks.Count > 0;
        }



        public int ListTasks()
        {
            System.Console.WriteLine("--------------------------");
            System.Console.WriteLine("\n");

            if (tasks.Count > 0)
            {
                Console.WriteLine($"ID | TITLE | DESCRPTION | STATUS | START DATE | FINISH DATE");
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{tasks[i].Id}|{tasks[i].Title}|{tasks[i].Description}|{tasks[i].Status}|{tasks[i].StartDate}|{tasks[i].FinishDate}");
                }

            }
            else
            {
                System.Console.WriteLine("There are no tasks registered.");

            }
            while (true)
            {
                System.Console.WriteLine("[1] ADD NEW TASK");
                System.Console.WriteLine("[2] COMPLETE TASK");
                System.Console.WriteLine("[3] DELETE TAREFA");
                System.Console.WriteLine("[4] BACK TO MENU");
                System.Console.WriteLine("\n");
                int input = 0;
                int[] options = { 1, 2, 3, 4 };
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


        public void DeleteTask(int id_delete)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == id_delete)
                {
                    tasks.RemoveAt(i);
                    break;
                }
            }
        }
        public void AddTask(string title, string description)
        {
            int newId = GenerateNewId();
            var newTask = new TaskItem(newId, title, description, "IN PROGRESS", DateTime.Now, null);
            tasks.Add(newTask);
        }

        public void CompleteTask(int id)
        {
            int index = -1;
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == id)
                {
                    index = i;
                }
            }
            if (index == -1)
            {
                System.Console.WriteLine("THERE ARE NO TASKS WITH THIS ID.");
            }
            else
            {
                tasks[index].CompleteTask();
            }
        }

    }

}