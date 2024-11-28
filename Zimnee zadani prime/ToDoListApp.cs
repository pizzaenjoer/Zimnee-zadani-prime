using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zimnee_zadani_prime
{
    public class ToDoListApp
    {
        private readonly ToDoListManager manager; //Управление задачами
        private readonly ToDoExport exporter;    //Экспорт задач

        public ToDoListApp()
        {
            manager = new ToDoListManager();
            exporter = new ToDoExport();
        }

        public void Run()
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
                        manager.AddTask();
                        break;
                    case "2":
                        manager.RemoveTask();
                        break;
                    case "3":
                        manager.ShowTasks();
                        break;
                    case "4":
                        ExportToHtml(); // Вызов метода экспорта
                        break;
                    case "5":
                        return; // Завершение программы
                    default:
                        Console.WriteLine("Некорректный выбор. Нажмите Enter и попробуйте снова.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Вызов экспорта задач через ToDoExport
        private void ExportToHtml()
        {
            // Получение списка задач из ToDoListManager
            var tasks = manager.GetTasks();
            exporter.ExportToHtml(tasks);
        }
    }
}
