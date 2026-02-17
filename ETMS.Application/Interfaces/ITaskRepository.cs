using ETMS.Domain.Entities;

public interface ITaskRepository
{
    Task AddAsync(TaskItem task);

    Task<List<TaskItem>> GetByUserIdAsync(int userId);
    Task<List<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(Guid id);

    //Task<TaskItem?> GetByIdAsync(int id);
    Task SaveChangesAsync();
}
