using Microsoft.EntityFrameworkCore;
using RTC_OEE_Management_API.Models.Entities;
namespace RTC_OEE_Management_API.Models.Context
{


    public class OeeDbContext : DbContext
    {
        public OeeDbContext()
        {

        }
        public OeeDbContext(DbContextOptions<OeeDbContext> options)
        : base(options)
        {
        }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineModelCycle> MachineModelCycles { get; set; }
        public DbSet<PlannedDowntime> PlannedDowntimes { get; set; }
        public DbSet<UnplannedDowntimeReason> UnplannedDowntimeReasons { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<MachineStatusLog> MachineStatusLogs { get; set; }
        public DbSet<ProductionCount> ProductionCounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.ConnectionString, new MySqlServerVersion(new Version(9, 4, 0)) // đổi version theo MySQL của bạn
             );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasKey(e => e.dept_id);
            modelBuilder.Entity<MachineStatusLog>(entity =>
            {
                entity.ToTable("machine_status_logs");
                entity.HasKey(e => e.log_id);
            }
            );
            modelBuilder.Entity<Factory>().HasKey(f => f.factory_id);
            modelBuilder.Entity<Zone>(entity =>
            {
                entity.HasKey(z => z.zone_id);

                entity.HasOne(z => z.Factory)
                      .WithMany(f => f.Zones) // giả sử Factory có ICollection<Zone> Zones
                      .HasForeignKey(z => z.factory_id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(z => z.ParentZone)
                      .WithMany(z => z.ChildZones)
                      .HasForeignKey(z => z.parent_zone_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(m => m.machine_id);

                entity.HasOne(m => m.Zone)
                      .WithMany(z => z.Machines)
                      .HasForeignKey(m => m.zone_id);
            });

            modelBuilder.Entity<Model>().HasKey(m => m.model_id);
            modelBuilder.Entity<Permission>().HasKey(p => p.perm_id);
            modelBuilder.Entity<PlannedDowntime>(entity =>
            {
                entity.ToTable("planned_downtimes");
                entity.HasKey(pd => pd.downtime_id);

                entity.Property(pd => pd.shift_code)
                      .HasMaxLength(50); // thêm ràng buộc nếu cần

                entity.HasOne(pd => pd.Machine)
                      .WithMany(m => m.PlannedDowntimes) // nếu Machine có ICollection<PlannedDowntime>
                      .HasForeignKey(pd => pd.machine_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.ToTable("user_permissions");
                entity.HasKey(up => new { up.user_id, up.perm_id });
            });
            modelBuilder.Entity<MachineModelCycle>(e =>
            {
                e.ToTable("machine_model_cycle");
                e.HasKey(x => x.id);

                e.HasOne(x => x.Machine)
                 .WithMany(m => m.MachineModelCycles)
                 .HasForeignKey(x => x.machine_id);     

                e.HasOne(x => x.Model)
                 .WithMany(md => md.MachineModelCycles)
                 .HasForeignKey(x => x.model_id);
            });

            modelBuilder.Entity<ProductionCount>(e =>
            {
                e.ToTable("production_counts");
                e.HasKey(x => x.id);

                e.HasOne(x => x.Machine)
                 .WithMany(m => m.ProductionCounts)
                 .HasForeignKey(x => x.machine_id);

                e.HasOne(x => x.Model)
                 .WithMany(md => md.ProductionCounts)
                 .HasForeignKey(x => x.model_id);
            });

            modelBuilder.Entity<Shift>(e =>
            {
                e.HasKey(x => x.shift_id);

                e.Property(x => x.shift_code)
                 .IsRequired()
                 .HasMaxLength(50);

                e.Property(x => x.shift_name)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(x => x.start_time)
                 .IsRequired();

                e.Property(x => x.end_time)
                 .IsRequired();
            });

            modelBuilder.Entity<UnplannedDowntimeReason>(e =>
            {
                e.ToTable("unplanned_downtime_reasons");
                e.HasKey(x => x.reason_id);

                e.Property(x => x.reason_code)
                 .IsRequired()
                 .HasMaxLength(50);

                e.Property(x => x.reason_name)
                 .IsRequired()
                 .HasMaxLength(100);

                e.Property(x => x.description)
                 .HasMaxLength(255); // hoặc bỏ nếu không muốn giới hạn

                e.HasMany(x => x.MachineStatusLogs)
                 .WithOne(log => log.UnplannedReason)
                 .HasForeignKey(log => log.unplanned_reason_id)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(e => e.user_id);

                entity.Property(e => e.username)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.password_hash)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.full_name)
                      .HasMaxLength(100);

                entity.Property(e => e.role)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.created_at)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(e => e.Department)
                      .WithMany(d => d.Users)
                      .HasForeignKey(e => e.dept_id)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasMany(e => e.UserPermissions)
                      .WithOne(up => up.User)
                      .HasForeignKey(up => up.user_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            // Zones self-reference
            modelBuilder.Entity<Zone>()
                .HasOne(z => z.ParentZone)
                .WithMany(z => z.ChildZones)
                .HasForeignKey(z => z.parent_zone_id)
                .OnDelete(DeleteBehavior.Restrict);

            // MachineModelCycle unique key
            modelBuilder.Entity<MachineModelCycle>()
                .HasIndex(m => new { m.machine_id, m.model_id }).IsUnique();

            // UserPermission relations
            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(up => up.user_id);

            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.Permission)
                .WithMany(p => p.UserPermissions)
                .HasForeignKey(up => up.perm_id);



            base.OnModelCreating(modelBuilder);
        }
    }
}