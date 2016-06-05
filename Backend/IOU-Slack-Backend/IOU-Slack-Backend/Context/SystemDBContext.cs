using IOU_Slack_Backend.Backend_Models;
using System;
using System.Data.Entity;

namespace IOU_Slack_Backend.Context
{
    public class SystemDbContext : DbContext
    {
        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventSubscription> EventSubscriptions { get; set; }

        public SystemDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>()
                        .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}