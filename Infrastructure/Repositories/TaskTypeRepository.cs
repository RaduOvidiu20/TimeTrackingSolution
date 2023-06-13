using Core.Contracts;
using Core.Entities;
using Infrastructure.AplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskTypeRepository : ITaskType
    {
        private readonly ApplicationDbContext _db;
        public TaskTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TaskType> AddTaskType(TaskType request)
        {
            _db.TaskTypes.AddAsync(request);
            await _db.SaveChangesAsync();
            return request;
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            _db.RemoveRange(_db.TaskTypes.Where(t => t.TaskTypeId == taskId));
            int deletedRows = await _db.SaveChangesAsync();
            return deletedRows > 0;
        }

        public async Task<List<TaskType>> GetAllTaskTypes()
        {
            return await _db.TaskTypes.OrderBy(t => t.Name).ToListAsync();
        }

        public async Task<TaskType> GetTaskTypeById(Guid taskId)
        {
            return await _db.TaskTypes.FindAsync(taskId);
        }

        public async Task<TaskType> UpdateTaskType(TaskType taskName)
        {
            TaskType matchingTaskType = await _db.TaskTypes.FirstOrDefaultAsync(t => t.TaskTypeId == taskName.TaskTypeId);
            if (matchingTaskType != null) { return taskName; }
            matchingTaskType.Name = taskName.Name;
            return matchingTaskType;
        }
    }
}
