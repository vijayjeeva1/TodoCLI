namespace TodoCLI.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"[{(IsCompleted ? "X" : " ")}] {Id}: {Description}";
        }
    }
}
