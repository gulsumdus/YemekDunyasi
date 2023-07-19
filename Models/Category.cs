using System.Text.Json.Serialization;

namespace YemekDünyasi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Restaurant>? Restaurants { get; set; }
    }
}

