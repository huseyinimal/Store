using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Order{
        public int OrderId { get; set; }        
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        [Required(ErrorMessage ="İsim girilmesi zorunludur!")]
        public string? Name {get;set;}

        [Required(ErrorMessage ="Adres girilmesi zorunludur!")]

        public String? Line1 { get; set; }
        public String? Line2 { get; set; }
        public String? Line3 { get; set; }
        public String? City { get; set; }
        public bool GiftWrap {get;set;}
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
    }
}