using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using QuartzNet.EntityFrameworkCore.Entities;

namespace QuartzNet.EntityFrameworkCore.DbContexts
{
    /// <summary>
    /// DbContext for the Quartz.Net data.
    /// </summary>
    public class QuartzContext : DbContext
    {
        /// <summary>
        /// Gets or sets the <see cref="CronTrigger"/> instances. 
        /// </summary>
        public DbSet<CronTrigger> CronTriggers => Set<CronTrigger>();

        /// <summary>
        /// Gets or sets the <see cref="PausedTriggerGroup"/> instances.
        /// </summary>
        public DbSet<PausedTriggerGroup> PausedTriggerGroups => Set<PausedTriggerGroup>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
