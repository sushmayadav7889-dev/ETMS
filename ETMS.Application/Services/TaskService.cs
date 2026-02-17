using System.Security.Claims;
using ETMS.Application.DTOs;
using ETMS.Application.Interfaces;
using ETMS.Domain.Entities;

public class TaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(CreateTaskDto dto, int userId)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Status = "Pending",
            UserId = userId
        };

        await _repository.AddAsync(task);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<TaskDto>> GetMyTasksAsync(int userId)
    {
        var tasks = await _repository.GetByUserIdAsync(userId);

        return tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Status = t.Status,
            DueDate = t.DueDate
        }).ToList();
    }

    public async Task<List<TaskItem>> GetAllAsync()
        => await _repository.GetAllAsync();
}
