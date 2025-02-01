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
      try
      {
        var products = await _unitOfWork.ProductRepository.GetProducts();
        return View(products);
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View();
      }
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
      try
      {
        if (ModelState.IsValid)
        {
          await _unitOfWork.ProductRepository.Add(product);
          await _unitOfWork.SaveChangesAsync();
          TempData["successMessage"] = "Sản phẩm đã thêm thành công";
          return RedirectToAction("Index");
        }
        TempData["errorMessage"] = "Sản phẩm không hợp lệ";

        return View(product);
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View(product);
      }
    }

    public async Task<IActionResult> Edit(int id)
    {
      try
      {
        if (id == 0)
        {
          return View();
        }
        var product = await _unitOfWork.ProductRepository.GetProductById(id);
        if (product == null)
        {
          return View();
        }
        return View(product);
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View();
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, ProductName, Price, Quantity")] Product product)
    {
      try
      {
        if (id != product.Id)
        {
          return View();
        }
        if (ModelState.IsValid)
        {
          await _unitOfWork.ProductRepository.Update(product);
          await _unitOfWork.SaveChangesAsync();
          TempData["successMessage"] = "Sản phẩm đã sửa thành công";
          return RedirectToAction("Index");
        }
        return View(product);
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View(product);
      }
    }

    public async Task<IActionResult> Details(int id)
    {
      try
      {
        if (id == 0)
        {
          return View();
        }
        var product = await _unitOfWork.ProductRepository.GetProductById(id);
        if (product == null)
        {
          return View();
        }
        return View(product);
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View();
      }
    }

    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        if (id == 0)
        {
          return View();
        }
        var product = await _unitOfWork.ProductRepository.GetProductById(id);
        if (product == null)
        {
          return View();
        }
        return View(product);
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View();
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id, ProductName, Price, Quantity")] Product product)
    {
      try
      {
        if (id != product.Id)
        {
          return View();
        }
        if (ModelState.IsValid)
        {
          await _unitOfWork.ProductRepository.Delete(id);
          await _unitOfWork.SaveChangesAsync();

          TempData["successMessage"] = "Sản phẩm đã xóa thành công";

          return RedirectToAction("Index");
        }
        return View(product);
      }
      catch (Exception ex)
      {
        TempData["errorMessage"] = ex.Message;
        return View(product);
      }
    }
  }
}
