using FinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<StockModel> Stocks { get; set; }
    public DbSet<CommentModel> Comments { get; set; }
}