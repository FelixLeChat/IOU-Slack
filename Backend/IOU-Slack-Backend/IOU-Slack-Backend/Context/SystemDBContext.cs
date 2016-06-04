using System;
using System.Data.Entity;

namespace IOU_Slack_Backend.Context
{
    public class SystemDbContext : DbContext
    {
        #region Fields

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