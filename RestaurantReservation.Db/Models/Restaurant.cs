namespace RestaurantReservation.Db.Models;

public class Restaurant
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Adress { get; set; }
    public int OpeningHours { get; set; }
    public List<MenuItem> MenuItems { get; set; } = [];
    public List<Reservation> Reservations { get; set; } = [];
    public List<Employee> Employees { get; set; } = [];
    public List<Table> Tables { get; set; } = [];
}
