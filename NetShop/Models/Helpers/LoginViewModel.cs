using System.ComponentModel.DataAnnotations;

namespace NetShop.Models.Helpers
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Введите имя")]
        [MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
        [MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
