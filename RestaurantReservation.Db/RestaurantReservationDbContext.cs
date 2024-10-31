using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.CustomerRepository;
using RestaurantReservation.Db.Repositories.RestaurantRepository;
using Table = RestaurantReservation.Db.Models.Table;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<ReservationView> ReservationDetails { get; set; }
    public DbSet<EmployeeView> EmployeesDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=WX1094183;Database=RestaurantReservationCore;TrustServerCertificate=True;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationView>().HasNoKey().ToView(nameof(ReservationDetails));
        modelBuilder.Entity<EmployeeView>().HasNoKey().ToView(nameof(EmployeesDetails));
        modelBuilder.Entity<RevenueResult>().HasNoKey().ToFunction("CalculateTotalRevenue");
        modelBuilder.Entity<CustomersPartySize>().HasNoKey().ToSqlQuery("FindCustomersWithPartySize");

        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.MenuItem)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.MenuItemId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Customer>()
            .HasData(GetCustomers());

        modelBuilder.Entity<Restaurant>()
            .HasData(GetRestaurants());

        modelBuilder.Entity<Employee>()
            .HasData(GetEmployees());

        modelBuilder.Entity<Table>()
            .HasData(GetTables());

        modelBuilder.Entity<Reservation>()
            .HasData(GetReservations());

        modelBuilder.Entity<Order>()
            .HasData(GetOrders());

        modelBuilder.Entity<MenuItem>()
            .HasData(GetItems());

        modelBuilder.Entity<OrderItem>()
            .HasData(GetOrderItems());
    }

    private List<OrderItem> GetOrderItems()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new OrderItem
            {
                Id = index,
                MenuItemId = index,
                OrderId = index,
                Quantity = index
            }).ToList();
    }

    private List<MenuItem> GetItems()
    {
        return Enumerable.Range(1, 5)
      .Select(index => new MenuItem
      {
          Id = index,
          Name = $"Item {index}",
          Price = index * 10,
          RestaurantId = index
      }).ToList();
    }

    private List<Order> GetOrders()
    {
        return Enumerable.Range(1, 5)
          .Select(index => new Order
          {
              Id = index,
              EmployeeId = index,
              OrderDate = DateTime.Now,
              TotalAmount = index + 1,
              ReservationId = index
          }).ToList();
    }

    private List<Reservation> GetReservations()
    {
        return Enumerable.Range(1, 5)
           .Select(index => new Reservation
           {
               Id = index,
               RestaurantId = index,
               PartySize = index + 3,
               CustomerId = index,
               ReservationDate = DateTime.Now,
               TableId = index
           }).ToList();
    }

    private List<Table> GetTables()
    {
        return Enumerable.Range(1, 5)
           .Select(index => new Table
           {
               Id = index,
               RestaurantId = index,
               Capacity = index + 1
           }).ToList();
    }

    private List<Employee> GetEmployees()
    {
        var options = new List<string> { "Manager", "CEO", "Regular" };
        return Enumerable.Range(1, 5)
            .Select(index => new Employee
            {
                Id = index,
                FirstName = $"Emp {index}",
                LastName = $"B {index}",
                Position = options[new Random().Next(options.Count)],
                RestaurantId = index
            }).ToList();
    }

    private List<Restaurant> GetRestaurants()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new Restaurant
            {
                Id = index,
                Name = $"Res {index}",
                Adress = $"Address {index}",
                OpeningHours = index,
                PhoneNumber = $"059700{index}"
            }).ToList();
    }

    private List<Customer> GetCustomers()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new Customer
            {
                FirstName = $"Cus {index}",
                LastName = $"A {index}",
                Email = $"example{index}@gmail.com",
                PhoneNumbers = $"059700{index}"
            }).ToList();
    }
}
