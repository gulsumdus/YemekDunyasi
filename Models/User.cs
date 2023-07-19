using System.Text.Json.Serialization;

namespace YemekDünyasi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string TelNo { get; set; }

        [JsonIgnore]
        public ICollection<UserSepet>? UserSepets { get; set; }
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }
    }
}
