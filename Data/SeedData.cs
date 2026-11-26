using AddisEats.Api.Models;

namespace AddisEats.Api.Data;

public class SeedData
{
    public static List<Restaurant> restaurants = new List<Restaurant>
    {
        new Restaurant { Id = 1, Name = "Addis Ababa Restaurant", Location = "Bole", PhoneNumber = "555-1234", IsActive = true, OwnerAddress = "456 Elm St" },
        new Restaurant { Id = 2, Name = "Blue Nile Restaurant", Location = "Ayat", PhoneNumber = "555-5678", IsActive = false, OwnerAddress = "789 Pine St" },
        new Restaurant { Id = 3, Name = "Lucy Restaurant", Location = "Mexico", PhoneNumber = "555-9012", IsActive = true, OwnerAddress = "321 Cedar St" },
        new Restaurant { Id = 4, Name = "Ethio Restaurant", Location = "Megenagna", PhoneNumber = "555-3456", IsActive = true, OwnerAddress = "654 Spruce St" },
        new Restaurant { Id = 5, Name = "Tena Yistilign Restaurant", Location = "Bole", PhoneNumber = "555-7890", IsActive = true, OwnerAddress = "987 Birch St" },
        new Restaurant { Id = 6, Name = "Kategna Restaurant", Location = "Megenagna", PhoneNumber = "555-2345", IsActive = true, OwnerAddress = "123 Main St" },
        new Restaurant { Id = 7, Name = "Sishu Restaurant", Location = "Bole", PhoneNumber = "555-6789", IsActive = false, OwnerAddress = "246 Aspen St" },
        new Restaurant { Id = 8, Name = "Abay Restaurant", Location = "Megenagna", PhoneNumber = "555-0123", IsActive = true, OwnerAddress = "357 Cherry St" },
        new Restaurant { Id = 9, Name = "Fendika Restaurant", Location = "Mexico", PhoneNumber = "555-4567", IsActive = false, OwnerAddress = "468 Walnut St" },
        new Restaurant { Id = 10, Name = "Doro Wat Restaurant", Location = "Megenagna", PhoneNumber  = "555-8901", IsActive = true, OwnerAddress = "579 Chestnut St" },
        new Restaurant { Id = 11, Name = "Injera Restaurant", Location = "Mexico", PhoneNumber = "555-2345", IsActive = true, OwnerAddress = "680 Poplar St" },
        new Restaurant { Id = 12, Name = "Bunna Restaurant", Location = "Ayat", PhoneNumber = "555-6789", IsActive = true, OwnerAddress = "791 Fir St" }
    };

    public static List<MenuItem> menuItems = new List<MenuItem>
    {
    new MenuItem {Id=1,Category="Main-course",Name ="shiro" ,Price =230m, RestaurantId=1},
    new MenuItem {Id = 2,Category ="Traditional-Dish",Name ="DoroWet", Price=1280m,RestaurantId=3},
    new MenuItem {Id= 3 , Category = "fasting", Name="Cotelet",Price =430m,RestaurantId =1},
    new MenuItem {Id= 4 , Category = "fasting", Name="salad",Price =330m,RestaurantId =1}
    };

    public static List<Order> listOfOrders = new List<Order>
    {
        new Order{Id=1,CustomerId =1, CustomerName="Abbe", DeliveryAddress="Bole gerji", MenuItemId=1, PhoneNumber="0912212121", Quantity=2, RestaurantId=1, TotalAmount=2300m},
        new Order{Id=3, CustomerId=2, CustomerName ="beza", DeliveryAddress="mebrathayl", MenuItemId =2, PhoneNumber="0923323232", Quantity=2, RestaurantId=2, TotalAmount=1233m}
    };

    public static List<User> listOfusers = new List<User>
    {
        
    };
}


