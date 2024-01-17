using CounThings.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Infra.Context
{
    public class ActivityContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
    }
}
