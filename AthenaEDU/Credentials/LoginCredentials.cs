using System.ComponentModel.DataAnnotations;

namespace AthenaEDU.Credentials
{
    public class LoginCredentials
    {
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        [EmailAddress(ErrorMessage = "Введенные данные не являются почтой!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым!")]
        public string Password { get; set; }
    }
}
