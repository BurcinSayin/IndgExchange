using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Entity;
using Exchange.Domain.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Data.Sqlite
{
    public class ExchangeDataContext:DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<User> Users { get; set; }

        // private string DbPath { get; set; }
        
        // public ExchangeDataContext(DbContextOptions<ExchangeDataContext> options): base(options)
        // {
        //     
        // }

        // public ExchangeDataContext()
        // {
        //     var folder = Environment.SpecialFolder.LocalApplicationData;
        //     var path = Environment.GetFolderPath(folder);
        //     DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}exchange.db";
        // }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=exchange.db");
        
    }
}