using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
    public class LoginModel
    {
        private string? _returnurl;
        [Required(ErrorMessage ="Kullanıcı Adı girilmesi zorunludur!")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Şifre girilmesi zorunludur!")]
        public string? Password { get; set; }

        public string ReturnUrl{
            get{
                if(_returnurl is null)
                return "/";
                else
                return _returnurl;
            }
            set{
                _returnurl = value;
            }
        }
    }
}