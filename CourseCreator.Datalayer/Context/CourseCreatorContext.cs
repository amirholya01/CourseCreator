using CourseCreator.Datalayer.Entities.Course;
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
