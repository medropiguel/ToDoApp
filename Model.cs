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
        public string Description { get; private set; }
        public string Status { get; private set; }
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

        

        public void ListTasks()
        {
            Console.WriteLine($"ID | TITULO | DESCRIÇÃO | STATUS | DATA DE INÍCIO | DATA DE CONCLUSÃO");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{tasks[i].Id}|{tasks[i].Title}|{tasks[i].Description}|{tasks[i].Status}|{tasks[i].StartDate}|{tasks[i].FinishDate}");
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
            var newTask = new TaskItem(newId, title, description, "Pendente", DateTime.Now, null);
            tasks.Add(newTask);
        }


    }

}