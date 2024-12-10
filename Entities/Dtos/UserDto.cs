using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Kullanıcı adı girilmesi zorunludur!")]
        public string? UserName { get; init; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email girilmesi zorunludur!")]
        public string? Email { get; init; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }
        public HashSet<String> Roles { get; set; } = new  HashSet<string>();
    }
}