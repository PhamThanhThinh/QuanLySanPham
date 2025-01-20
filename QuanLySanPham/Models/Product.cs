using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLySanPham.Models
{
  public class Product
  {
    // mã định danh
    [Key]
    public int Id { get; set; }
    [Required]
    //[DisplayName("Tên sản phẩm")]
    [DisplayName("Ten san pham")]
    public string ProductName { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public int Quantity { get; set; }
  }
}
