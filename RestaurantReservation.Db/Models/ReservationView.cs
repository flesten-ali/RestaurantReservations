namespace RestaurantReservation.Db.Models;

public class ReservationView
{
    public DateTime ReservationDate { get; set; }
    public string CustomerFullName { get; set; }
    public string RestaurantName { get; set; }
    public string Adress { get; set; }
}
