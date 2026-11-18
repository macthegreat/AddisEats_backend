namespace AddisEats.Api.Models;

public class Order
{
    public int Id { get; set; }
   public  int RestaurantId { get; set; }
    public int MenuItemId { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string OrderLocation { get; set; }
    
}