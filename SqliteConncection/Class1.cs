using FormsTest.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace SqliteConncection
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        private readonly string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

    }
}
