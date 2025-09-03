using System.Text.Json;
using TodoCLI.Models;

namespace TodoCLI.Services
{
    public class ToDoService
    {
        private readonly string _filePath = "todo.json";
        private List<TaskItem> _tasks = new();

        public ToDoService()
        {
            Load();
        }

        public void AddTask(string description)
        {
            int newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(new TaskItem { Id = newId, Description = description });
            Save();
        }

        public void ListTasks()
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine("No tasks yet!");
                return;
            }

            foreach (var task in _tasks)
            {
                Console.WriteLine(task);
            }
        }

        public void CompleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
                Save();
            }
            else
            {
                Console.WriteLine($"Task {id} not found!");
            }
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
                Save();
            }
            else
            {
                Console.WriteLine($"Task {id} not found!");
            }
        }

        private void Save()
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void Load()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
        }
    }
}
