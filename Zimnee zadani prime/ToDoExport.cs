using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zimnee_zadani_prime
{
    public class ToDoExport
    {
        public void ExportToHtml(Dictionary<DateTime, List<string>> toDoList)
        {
            string fileName = "ToDoList.html";
            string fullPath = Path.GetFullPath(fileName);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("<!DOCTYPE html>");
                writer.WriteLine("<html lang=\"en\">");
                writer.WriteLine("<head>");
                writer.WriteLine("<meta charset=\"UTF-8\">");
                writer.WriteLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
                writer.WriteLine("<title>Список дел</title>");
                writer.WriteLine("</head>");
                writer.WriteLine("<body>");
                writer.WriteLine("<h1>Список дел</h1>");

                foreach (var entry in toDoList)
                {
                    writer.WriteLine($"<h2>{entry.Key:yyyy-MM-dd}</h2>");
                    writer.WriteLine("<ul>");
                    foreach (var task in entry.Value)
                    {
                        writer.WriteLine($"<li>{task}</li>");
                    }
                    writer.WriteLine("</ul>");
                }

                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }

            Console.WriteLine($"Задачи экспортированы в файл {fullPath}");
            Console.WriteLine(" Нажмите Enter для продолжения.");
            Console.ReadLine();
        }
    }
}
