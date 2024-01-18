using System.ComponentModel.DataAnnotations;

namespace Fruit.Project.ViewModels.AccountVMs
{
    public class LoginVM
    {
        [Required]
        public string UserNameOrEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
