using System.ComponentModel.DataAnnotations;

namespace Fruit.Project.Areas.Manage.ViewModels.ProductVMs
{
    public class ProductCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string SubTitle { get; set; }
        public IFormFile? Image { get; set; }

    }
}
