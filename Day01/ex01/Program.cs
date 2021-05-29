using Task;
using TaskType;
using TaskPriority;
using System;
using System.Collections.Generic;

namespace ex01
{
    class Program
    {
        static void CreateTask(ref Task.Task1 task)
        {
            bool error = false;
            System.Console.WriteLine("Введите заголовок");
            string title = Console.ReadLine();

            System.Console.WriteLine("Введите описание");
            string summary = Console.ReadLine();

            System.Console.WriteLine("Введите срок");
            System.DateTime dueDate;

            bool isDate = DateTime.TryParse(Console.ReadLine(), out dueDate);
            if (isDate == false)
                error = true;
            task.dateString = dueDate.ToString();
            System.Console.WriteLine("Введите тип");
            string type = Console.ReadLine();
            TaskType.Type typeWork = TaskType.Type.Nullable;
            if (type == "Study")
            {
                task.typeString = "Study";
                typeWork = TaskType.Type.Study;
            }
            else if (type == "Work")
            {
                task.typeString = "Work";
                typeWork = TaskType.Type.Work;
            }
            else if (type == "Personal")
            {
                task.typeString = "Personal";
                typeWork = TaskType.Type.Personal;
            }
            else
                error = true;

            System.Console.WriteLine("Установите приоритет");
            string priority = Console.ReadLine();
            TaskPriority.Priority priority1 = TaskPriority.Priority.Nullable;
            if (priority == "Low")
            {
                task.priorityString = "Low";
                priority1 = TaskPriority.Priority.Low;
            }
            else if (priority == "Normal")
            {
                task.priorityString = "Normal";
                priority1 = TaskPriority.Priority.Normal;
            }
            else if (priority == "High")
            {
                task.priorityString = "High";
                priority1 = TaskPriority.Priority.High;
            }
            else
                error = true;
            task.stateString = "New";
            if (error)
            {
                System.Console.WriteLine("Ошибка ввода!");
                task.error = true;
                return ;
            }
            task.SetValue(title, summary, typeWork, priority1, dueDate);
        }

        static void OutputInfo(Task.Task1 task)
        {
            System.Console.WriteLine("- {0}", task.GetTitle());
            System.Console.WriteLine("[{0}][{1}]", task.typeString, task.stateString);
            System.Console.WriteLine("Priority: {0}, Due till {1}", task.priorityString, task.dateString);
            System.Console.WriteLine("{0}", task.GetSummary());
        }
        
        static void DoneTask(List<Task.Task1> tasks)
        {
            System.Console.WriteLine("Введите заголовок");
            string title = Console.ReadLine();
            int i = 0;
            for (i = 0; i < tasks.Count; i++) 
            {
                if (tasks[i].GetTitle() == title)
                {
                    tasks[i].SetStateTask("Done", TaskState.TaskState.Done);
                    break ;
                }
            }
            if (i == tasks.Count)
                System.Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
            else
                System.Console.WriteLine("Задача [{0}] выполнена!", tasks[i].GetTitle());
        }

        static void WontDoState(List<Task.Task1> tasks) 
        {
            System.Console.WriteLine("Введите заголовок");
            string title = Console.ReadLine();
            int i = 0;
            for (i = 0; i < tasks.Count; i++) 
            {
                if (tasks[i].GetTitle() == title)
                {
                    tasks[i].SetStateTask("WontDoState", TaskState.TaskState.WontDoState);
                    break;
                }
            }
            if (i == tasks.Count)
                System.Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
            else
                System.Console.WriteLine("Задача [{0}] более не актуальна!", tasks[i].GetTitle());
        }

        static void Main(string[] args)
        {
            List<Task.Task1> tasks = new List<Task.Task1>();
            while (true)
            {
                string inputMessage = Console.ReadLine();
                if (inputMessage == "add")
                {
                    Task.Task1 newTask = new Task.Task1();;
                    CreateTask(ref newTask);
                    tasks.Add(newTask);
                }
                if (inputMessage == "list")
                {
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        if (tasks[i].stateString != "Done" && tasks[i].error == false)
                            OutputInfo(tasks[i]);
                    }
                }
                if (inputMessage == "done")
                    DoneTask(tasks);
                if (inputMessage == "wontdo")
                    WontDoState(tasks);
                if (inputMessage == "quit" || inputMessage == "q")
                    Environment.Exit(0);
            }
        }
    }
}
