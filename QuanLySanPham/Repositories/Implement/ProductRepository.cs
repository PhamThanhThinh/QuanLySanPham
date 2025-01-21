using Microsoft.EntityFrameworkCore;
using QuanLySanPham.DAL;
using QuanLySanPham.Models;

namespace QuanLySanPham.Repositories.Implement
{
  public class ProductRepository : IProductRepository
  {
    private readonly ApplicationDbContext _dbcontext;

    public ProductRepository(ApplicationDbContext dbcontext)
    {
      _dbcontext = dbcontext;
    }

    public async Task Add(Product product)
    {
      _dbcontext.Products.Add(product);
      await _dbcontext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      //_dbcontext.Products.Remove(_dbcontext.Products.Find(id));
      var product = await _dbcontext.Products.FindAsync(id);

      if (product != null)
      {
        _dbcontext.Remove(product);
        await _dbcontext.SaveChangesAsync();
      }
    }

    public async Task<Product> GetProductById(int id)
    {
      return await _dbcontext.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
      return await _dbcontext.Products.ToListAsync();
    }

    public async Task Update(Product product)
    {
      _dbcontext.Entry(product).State = EntityState.Modified;
      await _dbcontext.SaveChangesAsync();
    }
  }
}
