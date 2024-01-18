using Fruit.Project.Models.BaseModel;

namespace Fruit.Project.Models
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string? ImgUrl { get; set; }
    }
}
