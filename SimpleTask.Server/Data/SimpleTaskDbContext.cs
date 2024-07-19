using Microsoft.EntityFrameworkCore;
using SimpleTask.Server.Models;
using System;

namespace SimpleTask.Server.Data
{
    public class SimpleTaskDbContext: DbContext
    {
        public SimpleTaskDbContext(DbContextOptions<SimpleTaskDbContext> options) : base(options) { }

        public DbSet<Account> People { get; set; }
        public DbSet<AccountTask> TaskInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts").HasIndex(a => a.Username).IsUnique(true);
            modelBuilder.Entity<AccountTask>().ToTable("AccountTasks");
        }
    }
}
