using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Entity;

namespace Project.Data
{
    public class BanKhoaHocDbContext : DbContext
    {

        public static ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public BanKhoaHocDbContext(DbContextOptions options) : base(options) { }


        #region 
        public DbSet<NguoiDung>? NguoiDungs { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDung>(nguoiDung =>
            {
                nguoiDung.HasIndex(nd => nd.TenDangNhap).IsUnique();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }
    }
}