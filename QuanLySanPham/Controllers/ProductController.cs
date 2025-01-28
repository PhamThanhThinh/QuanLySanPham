using Microsoft.AspNetCore.Mvc;
using QuanLySanPham.Models;
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id, ProductName, Price, Quantity")] Product product)
    {
      if (ModelState.IsValid)
      {
        await _unitOfWork.ProductRepository.Add(product);
        await _unitOfWork.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(product);
    }

  }
}
