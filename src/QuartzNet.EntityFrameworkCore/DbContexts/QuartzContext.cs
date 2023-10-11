using System.Reflection;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
