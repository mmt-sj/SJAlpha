using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MT.SJAlpha.EFCoreCodeFirst.Entitis;

namespace MT.SJAlpha.EFCoreCodeFirst
{
    public class EFDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=127.0.0.1;database=sj_alpha;user=root;password=123456;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Account).IsUnique();
        }
        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
