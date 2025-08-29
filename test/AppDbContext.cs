using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace test
{
    public class AppDbContext : DbContext
    {
        public DbSet<departments> departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=Bongmatntk9;database=rtc_oee_management;",
                new MySqlServerVersion(new Version(9, 4, 0)) // đổi version theo MySQL của bạn
            );

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chỉ định khóa chính cho entity Department
            modelBuilder.Entity<departments>()
                .HasKey(d => d.dept_id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
