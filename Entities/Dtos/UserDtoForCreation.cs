using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserDtoForCreation : UserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre girilmesi zorunludur!")]
        public string? Password { get; init; }
        
    }
    
}