using ConsoleApi.Models.DTO;

namespace ConsoleApi.Models
{
    public class ShoppingCart
    {
        public int NumOfItems { get; set; }

        public List<SellableItem> ShoppingCartList { get; set; }

        public ShoppingCart() { }
    }
}
