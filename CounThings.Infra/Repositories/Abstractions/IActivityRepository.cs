using CounThings.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Infra.Repositories.Abstractions
{
    public interface IActivityRepository
    {
        Task<ICollection<Activity>> GetAll();

        Task<Activity> GetActivityById(int activityId);

        Task<Activity> AddActivity(Activity toCreate);

        Task<Activity> UpdateActivity(Activity activityUpdate);

        Task Delete(int activityId);
    }
}
