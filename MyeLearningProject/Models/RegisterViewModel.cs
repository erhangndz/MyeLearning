using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace MyeLearningProject.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Şifreler birbiriyle eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        public string Username { get; set; }
    }
}
