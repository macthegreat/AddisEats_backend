namespace AddisEats.Api.Models;
public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public string OwnerAddress{get; set;}

}