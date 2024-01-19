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
            return await _context.Activities
                .Include(x => x.Payments)
                .FirstOrDefaultAsync(p => p.Id == activityId);
        }

        public async Task<ICollection<Activity>> GetAll()
        {
            return await _context.Activities.AsNoTracking().ToListAsync();
        }

        public async Task<Activity> UpdateActivity(Activity activityUpdate)
        {
            _context.Update(activityUpdate);
            await _context.SaveChangesAsync();

            return activityUpdate;
        }
    }
}
