using CounThings.Domain.Models;
using CounThings.Infra.Context;
using CounThings.Infra.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CounThings.Infra.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ActivityContext _context;

        public ActivityRepository(ActivityContext context)
        {
            _context = context;
        }

        public async Task<Activity> AddActivity(Activity toCreate)
        {
            _context.Activities.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeletePerson(int activityId)
        {
            var activity = await GetActivityById(activityId);

            if (activity is null) return;

            _context.Activities.Remove(activity);

            await _context.SaveChangesAsync();
        }

        public async Task<Activity> GetActivityById(int activityId)
        {
            return await _context.Activities.AsNoTracking().FirstOrDefaultAsync(p => p.Id == activityId);
        }

        public async Task<ICollection<Activity>> GetAll()
        {
            return await _context.Activities.AsNoTracking().ToListAsync();
        }

        public async Task<Activity> UpdateQuantity(int id)
        {
            var activity = await GetActivityById(id);
            
            activity.UpdateQuantity();

            await _context.SaveChangesAsync();

            return activity;
        }
    }
}
