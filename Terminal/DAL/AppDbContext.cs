using Microsoft.EntityFrameworkCore;
using Terminal.Models;

namespace Terminal.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TerminalProcedures> TerminalProcedures { get; set; }

    }
}