using Microsoft.EntityFrameworkCore;
using YemekDünyasi.Models;

namespace YemekDünyasi.Models
{
    public class YemekDünyasContext: DbContext
    {
        public YemekDünyasContext(DbContextOptions<YemekDünyasContext>options): base(options)// framework.core dan gelen bir sınıf(DbContext) !!
        {

        }
        public DbSet<User> UsersTable { get; set; }
        public DbSet<Category> CategoryTable { get; set; }
        public DbSet<Order> OrderTable { get; set; }
        public DbSet<OrderItem> OrderItemTable { get; set; }
        public DbSet<Product> ProductTable { get; set; }
        public DbSet<UserSepet> UserSepetTable { get; set; }
        public DbSet<Restaurant> RestaurantTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserSepet>()
                .HasKey(uc => new { uc.UserId, uc.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            // İlişkileri tanımlama
            modelBuilder.Entity<UserSepet>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserSepets)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserSepet>()
                .HasOne(uc => uc.Product)
                .WithMany(p => p.UserCarts)
                .HasForeignKey(uc => uc.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Restaurant)
                .WithMany(r => r.Products)
                .HasForeignKey(p => p.RestaurantId);


            modelBuilder.Entity<Category>()
                .HasMany(c => c.Restaurants)
                .WithOne(r => r.Category)
                .HasForeignKey(r => r.CategoryId);

            //////////////////////DATA SEEDING////////////////////////

            modelBuilder.Entity<User>()
                .HasData(
                new User() { Id=1, Name="Ayşe", Surname="Duran", Email="Durayse@gmail.com", Adress="Batıkent", TelNo="05434346578"},
                new User() { Id = 2, Name = "Ai", Surname = "Kaşcı", Email = "Durayse@gmail.com", Adress = "Ümitköy", TelNo = "05434346578" },
                new User() { Id = 3, Name = "Ahmet", Surname = "Satır", Email = "ahmet1987@gmail.com", Adress = "Çamlıca", TelNo = "05434346579" },
                new User() { Id = 4, Name = "Kemal", Surname = "Kuru", Email = "12345@gmail.com", Adress = "Sıhiyye", TelNo = "05434346574" },
                new User() { Id = 5, Name = "Selvi", Surname = "Kara", Email = "sk1234@gmail.com", Adress = "Ulus", TelNo = "05434346573" },
                new User() { Id = 6, Name = "Melih", Surname = "Mutlu", Email = "2Mel@gmail.com", Adress = "Etimesgut", TelNo = "05434346575" },
                new User() { Id = 7, Name = "Kadir", Surname = "Taş", Email = "taskadir@gmail.com", Adress = "Bahçelievler", TelNo = "05434346570" },
                new User() { Id = 8, Name = "Elif", Surname = "Salkım", Email = "elifs@gmail.com", Adress = "Emek", TelNo = "05434346572" },
                new User() { Id = 9, Name = "aylin", Surname = "Durmuş", Email = "daylin@gmail.com", Adress = "Mamak", TelNo = "05434346571" },
                new User() { Id = 10, Name = "Deniz", Surname = "Kaleci", Email = "kalden@gmail.com", Adress = "Batımerkez", TelNo = "05434346576"}
                );
            modelBuilder.Entity<Restaurant>()
                .HasData(
                new Restaurant() { Id =111, Name= "Ala kebap", Address = "Batıkent", TelNo = "08505678990", CategoryId = 1 },
                new Restaurant() { Id = 112, Name = "Lezzet Sofrası", Address = "Kızılay", TelNo = "03123456789", CategoryId =7 },
                new Restaurant() { Id = 113, Name = "Pizza Evi", Address = "Çankaya", TelNo = "03127894561", CategoryId =8 },
                new Restaurant() { Id = 114, Name = "Burger Land", Address = "Bahçelievler", TelNo = "03125678321", CategoryId =2},
                new Restaurant() { Id = 115, Name = "Deniz Mahsülleri", Address = "Gölbaşı", TelNo = "03123450987", CategoryId = 21},
                new Restaurant() { Id = 116, Name = "Tost Köşesi", Address = "Etimesgut", TelNo = "03127895678", CategoryId = 5},
                new Restaurant() { Id = 117, Name = "Kahve Dünyası", Address = "Tunalı Hilmi", TelNo = "03125678901", CategoryId =13 },
                new Restaurant() { Id = 118, Name = "Pideci Baba", Address = "Ankara Üniversitesi", TelNo = "03123456789", CategoryId =9 },
                new Restaurant() { Id = 119, Name = "Kahvaltı Bahçesi", Address = "Yıldırım Beyazıt Üniversitesi", TelNo = "03127894567", CategoryId =10 },
                new Restaurant() { Id = 120, Name = "Lahmacun Dükkanı", Address = "Cebeci", TelNo = "03125678912", CategoryId = 11}
                );
            modelBuilder.Entity<Category>()
                .HasData(
                new Category() { Id = 1 ,Name= "Döner" },
                new Category() { Id = 2, Name = "Burger" },
                new Category() { Id = 3, Name = "Tavuk" },
                new Category() { Id = 4, Name = "Pasta&Tatlı" },
                new Category() { Id = 5, Name = "Tost&Sandviç" },
                new Category() { Id = 6, Name = "Sokak Lezzetleri" },
                new Category() { Id = 7, Name = "Kebap" },
                new Category() { Id = 8, Name = "Pizza" },
                new Category() { Id = 9, Name = "Pide" },
                new Category() { Id = 10, Name = "Kahvaltı" },
                new Category() { Id = 11, Name = "Lahmacun" },
                new Category() { Id = 12, Name = "Ev yemekleri" },
                new Category() { Id = 13, Name = "Kahve" },
                new Category() { Id = 14, Name = "Vejetaryen" },
                new Category() { Id = 15, Name = "Dünya Mutfağı" },
                new Category() { Id = 16, Name = "Köfte" },
                new Category() { Id = 17, Name = "Börek" },
                new Category() { Id = 18, Name = "Çiğ Köfte" },
                new Category() { Id = 19, Name = "Salata" },
                new Category() { Id = 20, Name = "İçecek" },
                new Category() { Id = 21, Name = "Deniz Ürünleri" },
                new Category() { Id = 22, Name = "Dondurma" }

                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product() { Id = 1, Name = "İskender", Price = 120, RestaurantId = 111},
                new Product() { Id = 2, Name = "Kuzu Şiş", Price = 120, RestaurantId = 111 },
                new Product() { Id = 3, Name = "Tavuk Şiş", Price = 120, RestaurantId = 111 },
                new Product() { Id = 4, Name = "Lokma", Price = 120, RestaurantId = 111 },
                new Product() { Id = 5, Name = "Alinazik", Price = 120, RestaurantId = 111 }
                );

            modelBuilder.Entity<Order>()
               .HasData(
                new Order() { Id=1, UserId=1, OrderDate= DateTime.Now},
                new Order() { Id = 2, UserId = 2, OrderDate = DateTime.Now },
                new Order() { Id = 3, UserId = 3 , OrderDate = DateTime.Now },
                new Order() { Id = 4, UserId = 4 , OrderDate = DateTime.Now },
                new Order() { Id = 5, UserId = 5, OrderDate = DateTime.Now }
                );

        }
    }
    
    
}
