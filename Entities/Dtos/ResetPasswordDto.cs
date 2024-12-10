using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto{
        public string? UserName { get; init; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre girilmesi zorunludur!")]
        public string? Password { get; init; }
          [DataType(DataType.Password)]
        [Required(ErrorMessage ="Tekrar Şifre girilmesi zorunludur!")]
        [Compare("Password", ErrorMessage ="Şifreleriniz birbiriyle eşleşmiyor.")]
         public string? ConfirmPassword { get; init; }
    }
}