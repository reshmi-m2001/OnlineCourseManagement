using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Domain;
using OnlineCourseManagement.Domain.Common;
using OnlineCourseManagement.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseManagement.Persistence.DatabaseContext
{
    public class ConnectionDatabaseContext : DbContext
    {
        public ConnectionDatabaseContext(DbContextOptions<ConnectionDatabaseContext> options) : base(options)
        {
        }

        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Course>()
           .HasOne(c => c.CourseCategory)
           .WithMany(cc => cc.Courses)
           .HasForeignKey(c => c.CourseCategoryId);*/


            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConnectionDatabaseContext).Assembly);
            modelBuilder.ApplyConfiguration(new CourseCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());


            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {

                    entry.Entity.DateCreated = DateTime.Now;
                }


            }
                return base.SaveChangesAsync(cancellationToken);
            
        }

    }
}
