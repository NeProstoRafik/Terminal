using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Terminal.Models;

namespace Terminal.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<TerminalProcedures> TerminalProcedures { get; set; }

    }
}