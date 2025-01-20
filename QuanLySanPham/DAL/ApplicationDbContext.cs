using Microsoft.EntityFrameworkCore;
using QuanLySanPham.Models;

namespace QuanLySanPham.DAL
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
  }
}

