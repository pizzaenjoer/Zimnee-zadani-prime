using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zimnee_zadani_prime
{
    class ToDoConsoleOperations
    {
        private readonly ToDoListManager manager;

        public ToDoConsoleOperations(ToDoListManager manager)
        {
            this.manager = manager;
        }

        public void HandleRemoveTask()
        {
            Console.Write("Введите дату задачи для удаления (ГГГГ-ММ-ДД): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Некорректная дата. Нажмите Enter для продолжения.");
                Console.ReadLine();
                return;
            }
             var tasks = manager.GetTasks();
            if (!tasks.ContainsKey(date))
            {
                Console.WriteLine("Задачи на указанную дату не найдены. Нажмите Enter для продолжения.");
                Console.ReadLine();
                return;
            }
             Console.WriteLine("Задачи на указанную дату:");
            for (int i = 0; i < tasks[date].Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[date][i]}");
            }
            Console.Write("Введите номер выполненной задачи: ");
            if (!int.TryParse(Console.ReadLine(), out int taskIndex))
            {
                Console.WriteLine("Некорректный номер задачи. Нажмите Enter для продолжения.");
                Console.ReadLine();
                return;
            }
            bool isRemoved = manager.RemoveTask(date, taskIndex);
            if (isRemoved)
            {
                Console.WriteLine("Задача успешно удалена. Нажмите Enter для продолжения.");
            }
            else
            {
                Console.WriteLine("Удаление не удалось. Проверьте номер задачи и дату. Нажмите Enter для продолжения.");
            }
            Console.ReadLine();
        }
    }
}
