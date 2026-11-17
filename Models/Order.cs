namespace AddisEats.Api.Models;

public class Order
{
    int Id { get; set; }
    int RestaurantId { get; set; }
    int MenuItemId { get; set; }
    string CustomerName { get; set; }
    string PhoneNumber { get; set; }
    string OrderLocation { get; set; }
    
}