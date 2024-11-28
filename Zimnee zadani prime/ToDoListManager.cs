﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zimnee_zadani_prime
{
    public class ToDoListManager
    {
        private readonly Dictionary<DateTime, List<string>> toDoList = new();

        public void AddTask()
        {
            Console.Write("Введите дату задачи (ГГГГ-ММ-ДД): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.Write("Введите описание задачи: ");
                string task = Console.ReadLine();
                if (!toDoList.ContainsKey(date))
                {
                    toDoList[date] = new List<string>();
                }
                toDoList[date].Add(task);
                Console.WriteLine("Задача добавлена. Нажмите Enter для продолжения.");
            }
            else
            {
                Console.WriteLine("Некорректная дата. Нажмите Enter для продолжения.");
            }
            Console.ReadLine();
        }

        public void RemoveTask()
        {
            Console.Write("Введите дату задачи для удаления (ГГГГ-ММ-ДД): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date) && toDoList.ContainsKey(date))
            {
                Console.WriteLine("Задачи на указанную дату:");
                for (int i = 0; i < toDoList[date].Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {toDoList[date][i]}");
                }

                Console.Write("Введите номер выполненной задачи: ");
                if (int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex > 0 && taskIndex <= toDoList[date].Count)
                {
                    toDoList[date].RemoveAt(taskIndex - 1);
                    Console.WriteLine("Задача удалена. Нажмите Enter для продолжения.");
                }
                else
                {
                    Console.WriteLine("Некорректный номер задачи. Нажмите Enter для продолжения.");
                }

                if (toDoList[date].Count == 0)
                {
                    toDoList.Remove(date);
                }
            }
            else
            {
                Console.WriteLine("Задачи на указанную дату не найдены. Нажмите Enter для продолжения.");
            }
            Console.ReadLine();
        }

        public void ShowTasks()
        {
            Console.Write("Введите дату для отображения задач (ГГГГ-ММ-ДД): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date) && toDoList.ContainsKey(date))
            {
                Console.WriteLine("Задачи на указанную дату:");
                foreach (var task in toDoList[date])
                {
                    Console.WriteLine($"- {task}");
                }
            }
            else
            {
                Console.WriteLine("На указанную дату задач нет.");
            }
            Console.WriteLine("Нажмите Enter для продолжения.");
            Console.ReadLine();
        }

        //Новый метод для получения задач
        public Dictionary<DateTime, List<string>> GetTasks()
        {
            return toDoList;
        }

    }
}
