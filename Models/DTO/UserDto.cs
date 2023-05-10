using System.ComponentModel.DataAnnotations;

namespace ConsoleApi.Models.DTO
{
    public class UserDto
    {
        public int id { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

        public ShoppingCart cart { get; set; }
        public List<SellableItem> sellingList { get; set; }

        public UserDto(int id, string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            cart = new ShoppingCart();
            sellingList = new List<SellableItem>();
        }
    }
}
