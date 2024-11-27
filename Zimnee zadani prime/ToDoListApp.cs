using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zimnee_zadani_prime
{
    class ToDoListApp
    {
        public ToDoListManager toDolistManager = new ToDoListManager();

       
        public static ToDoListManager GetToDoListManager(ToDoListManager toDoListManager)
        {
            return toDoListManager;
        }

        public static void Run(ToDoListManager toDoListManager)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Список дел:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Удалить выполненную задачу");
                Console.WriteLine("3. Показать задачи на указанную дату");
                Console.WriteLine("4. Экспортировать задачи в HTML");
                Console.WriteLine("5. Выйти");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        toDoListManager.AddTask();
                        break;
                    case "2":
                        toDoListManager.RemoveTask();
                        break;
                    case "3":
                        toDoListManager.ShowTasks();
                        break;
                    case "4":
                        toDoListManager.ExportToHtml();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Нажмите Enter и попробуйте снова.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        internal static void Run()
        {
            throw new NotImplementedException();
        }
    }
}
