using Microsoft.EntityFrameworkCore;
using ETMS.Application.Interfaces;
using ETMS.Domain.Entities;
using ETMS.Infrastructure.Data;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TaskItem task)
        => await _context.Tasks.AddAsync(task);

    public async Task<List<TaskItem>> GetByUserIdAsync(int userId)
        => await _context.Tasks
            .Where(t => t.UserId == userId)
            .ToListAsync();

    public async Task<List<TaskItem>> GetAllAsync()
        => await _context.Tasks
            .Include(t => t.User)
            .ToListAsync();

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    => await _context.Tasks.FindAsync(id);


    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
