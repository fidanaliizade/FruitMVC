using System.ComponentModel.DataAnnotations;

namespace Fruit.Project.Areas.Manage.ViewModels.ProductVMs
{
    public class ProductUpdateVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        public IFormFile? Image { get; set; }
    }
}
