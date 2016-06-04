using System;
using System.Data.Entity;

namespace IOU_Slack_Backend.Context
{
    public class SystemDbContext : DbContext
    {
        #region Fields

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<UserInGroup> UsersInGroups { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Event> Events { get; set; }

        #endregion

        #region Constructors
        public SystemDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>()
                        .Configure(c => c.HasColumnType("datetime2"));
        }

        #endregion
    }
}