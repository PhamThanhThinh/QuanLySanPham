using QuanLySanPham.DAL;

namespace QuanLySanPham.Repositories.Implement
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _dbcontext;

    public UnitOfWork(ApplicationDbContext dbcontext)
    {
      _dbcontext = dbcontext;
      ProductRepository = new ProductRepository(_dbcontext);
    }

    public IProductRepository ProductRepository { get; private set; }

    public async Task<int> SaveChangesAsync()
    {
      return await _dbcontext.SaveChangesAsync();
    }
  }
}
