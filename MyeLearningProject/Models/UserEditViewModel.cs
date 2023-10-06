using System.ComponentModel.DataAnnotations;

namespace MyeLearningProject.Models
{
    public class UserEditViewModel
    {
        public string NameSurname { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil.") ]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public IFormFile Image { get; set; }
    }
}
