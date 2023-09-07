using CourseCreator.Datalayer.Entities.Course;
using CourseCreator.Datalayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Datalayer.Context
{
    public class CourseCreatorContext : DbContext
    {
        public CourseCreatorContext(DbContextOptions<CourseCreatorContext> options) : base(options)
        {
            
        }

        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        #endregion

        #region Courses
        public DbSet<CourseGroup> CourseGroups { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseGroup>()
                .HasQueryFilter(g => !g.IsDelete);

            base.OnModelCreating(modelBuilder);
        }
    }
}
