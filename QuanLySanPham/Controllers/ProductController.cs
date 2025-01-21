using Microsoft.AspNetCore.Mvc;
using QuanLySanPham.Repositories;

namespace QuanLySanPham.Controllers
{
  public class ProductController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
      var products = await _unitOfWork.ProductRepository.GetProducts();
      return View(products);
    }

    public IActionResult Create()
    {
      return View();
    }
    //public IActionResult Details() { }

  }
}
