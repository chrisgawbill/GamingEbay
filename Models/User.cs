using ConsoleApi.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApi.Models
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { set; get; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }   

        public ShoppingCart cart { get; set; }
        public List<SellableItem> sellingList { get; set; } 
        
        public User(string firstName, string lastName, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;  
            this.email = email;
            this.password = password;
            cart = new ShoppingCart();
            sellingList= new List<SellableItem>();
        }
    }
}
