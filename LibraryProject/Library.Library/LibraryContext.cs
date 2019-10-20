using Library.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library
{
    public class LibraryContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;
        public LibraryContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(optionBuilder);
        }

        public LibraryContext(DbContextOptions options) : base(options) { }
        public DbSet<StudentInfo> StudentInfos { get; set; }
        public DbSet<BookInfo> BookInfos { get; set; }
        public DbSet<Issue> IssueBooks { get; set; }
    }
}
