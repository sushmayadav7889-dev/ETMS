namespace ETMS.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Status { get; set; } = "ToDo";

    public string Priority { get; set; } = "Medium";
     public DateTime DueDate { get; set; }

    public Guid AssignedTo { get; set; }

    public Guid ProjectId { get; set; }
    public int UserId { get; set; }

    // 🔥 THIS IS REQUIRED
    public User User { get; set; } = null!;
}
