namespace AddisEats.Api.DTOs;

public class RetaurantQuery
{
    public string? Address {get; set;}
    public string? Name {get; set;}

    public bool? IsActive {get; set;}
    public int Page {get; set;} = 1 ;
    public int PageSize {get;set;} = 3;

}