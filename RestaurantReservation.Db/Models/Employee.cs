namespace RestaurantReservation.Db.Models;

public class Employee
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<Order> Orders { get; set; } = [];

}
