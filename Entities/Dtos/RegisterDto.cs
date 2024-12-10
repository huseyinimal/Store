using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto
    {
        [Required(ErrorMessage ="Kullanıcı adı girilmesi zorunludur!")]
        public String? UserName { get; init; }
         [Required(ErrorMessage ="Email girilmesi zorunludur!")]
        public String? Email { get; init; }
         [Required(ErrorMessage ="Şifre girilmesi zorunludur!")]
        public String? Password { get; init; }
    }
}