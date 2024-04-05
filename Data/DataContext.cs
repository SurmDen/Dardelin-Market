using DardelinMarket.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DardelinMarket.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Busket> Buskets { get; set; }

        public DbSet<BusketModel> BusketModels { get; set; }

        public DbSet<OrderModel> OrderModels { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<IpDataModel> IpDataModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer()
                {
                    Id = 1,

                    Name = "Дарья",

                    Email = "dardelin09@gmail.com",

                    District = "Ленинградская область",

                    City = "Санкт-Петербург",

                    PostAddress = "ул. Лахтинская, д. 53Б, кв. 25",

                    Password = PasswordHesher.GenerateHesh("dardelin"),

                    Role = "Admin",

                },

                new Customer()
                {
                    Id = 2,

                    Name = "Денис",

                    Email = "surmanidzedenis609@gmail.com",

                    District = "Ленинградская область",

                    City = "Санкт-Петербург",

                    PostAddress = "ул. Лахтинская, д. 53Б, кв. 25",

                    Password = PasswordHesher.GenerateHesh("01052001denis"),

                    Role = "User"
                },

            });

            modelBuilder.Entity<Busket>().HasData(new Busket[]
            {
                new Busket()
                {
                    Id = 1,

                    CustomerId = 1
                },

                new Busket()
                {
                    Id = 2,

                    CustomerId = 2
                },
            });

            Category[] categories = new Category[]
            {
                new Category()
                {
                    Id = 1,

                    CategoryName = "кисти",

                    ImagePath = "/Images/Category/brushes.png"
                },

                new Category()
                {
                    Id = 2,

                    CategoryName = "краски",

                    ImagePath = "/Images/Category/paints.png"
                },

                new Category()
                {
                    Id = 3,

                    CategoryName = "карандаши",

                    ImagePath = "/Images/Category/pencil.png"
                },

                new Category()
                {
                    Id = 4,

                    CategoryName = "бумага",

                    ImagePath = "/Images/Category/paper.png"
                },

                new Category()
                {
                    Id = 5,

                    CategoryName = "канцелярия",

                    ImagePath = "/Images/Category/ruler.png"
                },

                new Category()
                {
                    Id = 6,

                    CategoryName = "вышивание",

                    ImagePath = "/Images/Category/sewing.png"
                },

                new Category()
                {
                    Id = 7,

                    CategoryName = "открытки",

                    ImagePath = "/Images/Category/postcard.png"
                },

                new Category()
                {
                    Id = 8,

                    CategoryName = "шопперы",

                    ImagePath = "/Images/Category/shopper.png"
                },

                new Category()
                {
                    Id = 9,

                    CategoryName = "футболки",

                    ImagePath = "/Images/Category/t-shirt.png"
                },

                new Category()
                {
                    Id = 10,

                    CategoryName = "скетчбуки",

                    ImagePath = "/Images/Category/sketchbook.png"
                },

                new Category()
                {
                    Id = 11,

                    CategoryName = "заказ на открытки",

                    ImagePath = "/Images/Category/bride.png"
                },

                new Category()
                {
                    Id = 12,

                    CategoryName = "расписанные предметы",

                    ImagePath = "/Images/Category/paint.png"
                },
            };

            modelBuilder.Entity<Category>().HasData(categories);

            Product[] products = new Product[]
            {
                new Product()
                {
                    Id = 1,

                    ProductName = "кисти стандарт",

                    Price = 200,

                    ImagePath = "/Images/Product/kists1.webp",

                    CategoryId = 1
                },

                new Product()
                {
                    Id = 2,

                    ProductName = "нейлоновые кисти",

                    Price = 300,

                    ImagePath = "/Images/Product/kists2.jpg",

                    CategoryId = 1,

                    Sales = 24
                },

                new Product()
                {
                    Id = 3,

                    ProductName = "акриловые краски",

                    Price = 400,

                    ImagePath = "/Images/Product/paints1.jpg",

                    CategoryId = 2
                },

                new Product()
                {
                    Id = 4,

                    ProductName = "гуашь",

                    Price = 350,

                    ImagePath = "/Images/Product/guash.jpg",

                    CategoryId = 2
                },

                new Product()
                {
                    Id = 5,

                    ProductName = "простые карандаши",

                    Price = 100,

                    ImagePath = "/Images/Product/pencils.webp",

                    CategoryId = 3
                },

                new Product()
                {
                    Id = 6,

                    ProductName = "цветные карандаши",

                    Price = 120,

                    ImagePath = "/Images/Product/pencil2.webp",

                    CategoryId = 3,

                    Sales = 40
                },

                new Product()
                {
                    Id = 7,

                    ProductName = "мелованная бумага",

                    Price = 600,

                    ImagePath = "/Images/Product/paper2.jpg",

                    CategoryId = 4
                },

                new Product()
                {
                    Id = 8,

                    ProductName = "дизайнерская бумага",

                    Price = 800,

                    ImagePath = "/Images/Product/paper1.jpg",

                    CategoryId = 4,

                    Sales = 45
                },

                new Product()
                {
                    Id = 9,

                    ProductName = "набор линеек",

                    Price = 130,

                    ImagePath = "/Images/Product/rulers.jpg",

                    CategoryId = 5
                },

                new Product()
                {
                    Id = 10,

                    ProductName = "гелевые ручки",

                    Price = 210,

                    ImagePath = "/Images/Product/pen1.webp",

                    CategoryId = 5
                },

                new Product()
                {
                    Id = 11,

                    ProductName = "набор ниток",

                    Price = 600,

                    ImagePath = "/Images/Product/knits.jpg",

                    CategoryId = 6
                },

                new Product()
                {
                    Id = 12,

                    ProductName = "набор иголок",

                    Price = 150,

                    ImagePath = "/Images/Product/igles.jpg",

                    CategoryId = 6,

                    Sales = 15
                },

                new Product()
                {
                    Id = 13,

                    ProductName = "юбилейные открытки",

                    Price = 200,

                    ImagePath = "/Images/Product/annuversary.webp",

                    CategoryId = 7
                },

                new Product()
                {
                    Id = 14,

                    ProductName = "День Рождения",

                    Price = 250,

                    ImagePath = "/Images/Product/birthday.jpg",

                    CategoryId = 7
                },

                new Product()
                {
                    Id = 15,

                    ProductName = "шоппер классический",

                    Price = 1000,

                    ImagePath = "/Images/Product/shopper1.jpg",

                    CategoryId = 8
                },

                new Product()
                {
                    Id = 16,

                    ProductName = "шоппер с принтом",

                    Price = 1200,

                    ImagePath = "/Images/Product/shopper2.jpg",

                    CategoryId = 8
                },

                new Product()
                {
                    Id = 17,

                    ProductName = "футболка классическая",

                    Price = 1200,

                    ImagePath = "/Images/Product/tshirt1.jpg",

                    CategoryId = 9,

                    Sales = 32
                },

                new Product()
                {
                    Id = 18,

                    ProductName = "футболка с принтом",

                    Price = 1500,

                    ImagePath = "/Images/Product/tshirt2.jpg",

                    CategoryId = 9
                },

                new Product()
                {
                    Id = 19,

                    ProductName = "скетчбук однотонный",

                    Price = 600,

                    ImagePath = "/Images/Product/sketh1.jpeg",

                    CategoryId = 10
                },

                new Product()
                {
                    Id = 20,

                    ProductName = "скетчбук с рисунком",

                    Price = 700,

                    ImagePath = "/Images/Product/sketch2.jpg",

                    CategoryId = 10
                },

                new Product()
                {
                    Id = 21,

                    ProductName = "открытки к свадьбе",

                    Price = 300,

                    ImagePath = "/Images/Product/wedding.jpg",

                    CategoryId = 11
                },

                new Product()
                {
                    Id = 22,

                    ProductName = "пригласительные открытки",

                    Price = 450,

                    ImagePath = "/Images/Product/inviting.jpg",

                    CategoryId = 11
                },

                new Product()
                {
                    Id = 23,

                    ProductName = "расписанная кружка",

                    Price = 1200,

                    ImagePath = "/Images/Product/cup.jpg",

                    CategoryId = 12
                },

                new Product()
                {
                    Id = 24,

                    ProductName = "авторский рюкзак",

                    Price = 2000,

                    ImagePath = "/Images/Product/back1.jpg",

                    CategoryId = 12,

                    Sales = 55
                }
            };

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
