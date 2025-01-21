namespace QuanLySanPham.Repositories
{
  public interface IUnitOfWork
  {
    IProductRepository ProductRepository { get; }
    //Task<int> LuuThayDoiAsync();
    Task<int> SaveChangesAsync();
  }
}
