namespace RestaurantReservation.Db.Models;

public class Customer
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumbers { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}
