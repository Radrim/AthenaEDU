using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AthenaEDU.Credentials
{
    public class RegistrationCredentials
    {
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [EmailAddress(ErrorMessage = "Введенные данные не являются почтой!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Минимум 6, максимум 20 символов!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        public string Patronymic { get; set; }
    }
}
