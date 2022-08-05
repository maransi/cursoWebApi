using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Content
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseMySql("Server=localhost;Port=3306;Database=testdb;Uid=root;Pwd=root",
                                        ServerVersion.AutoDetect("Server=localhost;Port=3306;Database=testdb;Uid=root;Pwd=root"));
    }
}
