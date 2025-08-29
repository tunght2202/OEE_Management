using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RTC_OOE.API
{
    public class BlogDataContext : DbContext
    {
        static readonly string connectionString = "Server=localhost; User ID=root; Password=Bongmatntk9; Database=rtc_oee_management";
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");
                entity.HasKey(e => e.deptId);
                entity.Property(e => e.deptId).HasColumnName("dept_id");
                entity.Property(e => e.deptCode).HasColumnName("dept_code");
                entity.Property(e => e.deptName).HasColumnName("dept_name");
            });
        }

    }

    public class Department
    {
        public int deptId { get; set; }
        public string deptCode { get; set; }
        public string deptName { get; set; }

        //public ICollection<User> Users { get; set; }
    }

}
