using System.Text.Json.Serialization;

namespace YemekDünyasi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
     
        public int RestaurantId { get; set; }

        [JsonIgnore]
        public Restaurant? Restaurant { get; set; }
        [JsonIgnore]
        public ICollection<UserSepet>? UserCarts { get; set; }
        [JsonIgnore]
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}

