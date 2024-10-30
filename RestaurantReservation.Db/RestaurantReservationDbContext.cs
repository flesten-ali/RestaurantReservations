using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=WX1094183;Database=RestaurantReservationCore;TrustServerCertificate=True;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        var customers = new List<Customer>()
        {
                    new() { Id = 1, FirstName = "Cus1", LastName = "A", Email = "example1@gmail.com", PhoneNumbers = "059900293" },
                    new() { Id = 2, FirstName = "Cus2", LastName = "A", Email = "example2@gmail.com", PhoneNumbers = "059900293" },
                    new() { Id =3, FirstName = "Cus3", LastName = "B", Email = "example3@gmail.com", PhoneNumbers = "059900293" },
                    new() { Id = 4, FirstName = "Cus4", LastName = "C", Email = "example4@gmail.com", PhoneNumbers = "059900293" },
                    new() { Id = 5, FirstName = "Cus5", LastName = "D", Email = "example5@gmail.com", PhoneNumbers = "059900293" }
        };
        modelBuilder.Entity<Customer>()
            .HasData(customers);


        var restaurants = new List<Restaurant>()
        {
                    new() { Id = 1,Name="Res1",Adress="A",OpeningHours=12,PhoneNumber="9039741"},
                    new() { Id = 2,Name="Res2",Adress="B",OpeningHours=10,PhoneNumber="9039741"},
                    new() { Id = 3,Name="Res3",Adress="D",OpeningHours=6,PhoneNumber="9039741"},
                    new() { Id = 4,Name="Res4",Adress="C",OpeningHours=9,PhoneNumber="9039741"},
                    new() { Id = 5,Name="Res5",Adress="A",OpeningHours=12,PhoneNumber="9039741"}
        };
        modelBuilder.Entity<Restaurant>()
            .HasData(restaurants);


        var employees = new List<Employee>()
        {
                    new() { Id = 1, FirstName = "Emp1", LastName = "F",Position = "A",RestaurantId=1  },
                    new() { Id = 2, FirstName = "Emp2", LastName = "B",Position = "A",RestaurantId=1 },
                    new() { Id = 3, FirstName = "Emp3", LastName = "G",Position = "B",RestaurantId=2 },
                    new() { Id = 4, FirstName = "Emp4", LastName = "T",Position = "C",RestaurantId=4   },
                    new() { Id = 5, FirstName = "Emp5", LastName = "B", Position = "A",RestaurantId=5  }
        };
        modelBuilder.Entity<Employee>()
            .HasData(employees);


        var tables = new List<Table>()
        {
                    new() { Id = 1,RestaurantId=1,Capacity=2 },
                    new() { Id = 2,RestaurantId=2,Capacity=4 },
                    new() { Id = 3,RestaurantId=1,Capacity=3 },
                    new() { Id = 4,RestaurantId=3,Capacity=5 },
                    new() { Id = 5,RestaurantId=4,Capacity=6 },
                    new() { Id = 6,RestaurantId=5,Capacity=4 },
        };
        modelBuilder.Entity<Table>()
            .HasData(tables);


        var reservations = new List<Reservation>()
        {
            new(){Id = 1,RestaurantId = 1,PartySize = 2,CustomerId = 1, ReservationDate = DateTime.Now,TableId = 1},
            new(){Id = 2,RestaurantId = 1,PartySize = 2,CustomerId = 1, ReservationDate = DateTime.Now,TableId = 2},
            new(){Id = 3,RestaurantId = 2,PartySize = 2,CustomerId = 1, ReservationDate = DateTime.Now,TableId = 1},
            new(){Id = 4,RestaurantId = 3,PartySize = 2,CustomerId = 1, ReservationDate = DateTime.Now,TableId = 1},
            new(){Id = 5,RestaurantId = 5,PartySize = 2,CustomerId = 1, ReservationDate = DateTime.Now,TableId = 1}
        };
        modelBuilder.Entity<Reservation>()
            .HasData(reservations);


        var orders = new List<Order>()
        {
            new(){Id=1,EmployeeId=1,OrderDate=DateTime.Now,TotalAmount=2,ReservationId=1},
            new(){Id=2,EmployeeId=2,OrderDate=DateTime.Now,TotalAmount=12,ReservationId=2},
            new(){Id=3,EmployeeId=3,OrderDate=DateTime.Now,TotalAmount=10,ReservationId=3},
            new(){Id=4,EmployeeId=4,OrderDate=DateTime.Now,TotalAmount=11,ReservationId=4},
            new(){Id=5,EmployeeId=5,OrderDate=DateTime.Now,TotalAmount=120,ReservationId=5},
        };
        modelBuilder.Entity<Order>()
            .HasData(orders);


        var items = new List<MenuItem>()
        {
           new(){Id=1,Name="Item1",Price=140,RestaurantId=1},
           new(){Id=2,Name="Item2",Price=120,RestaurantId=2},
           new(){Id=3,Name="Item3",Price=130,RestaurantId=3},
           new(){Id=4,Name="Item4",Price=10,RestaurantId=4},
           new(){Id=5,Name="Item5",Price=60,RestaurantId=5}
        };
        modelBuilder.Entity<MenuItem>()
            .HasData(items);


        var orderItems = new List<OrderItem>()
        {
          new(){Id=1,MenuItemId=1,OrderId=1,Quantity=2},
          new(){Id=2,MenuItemId=2,OrderId=2,Quantity=2},
          new(){Id=3,MenuItemId=3,OrderId=3,Quantity=2},
          new(){Id=4,MenuItemId=4,OrderId=4,Quantity=2},
          new(){Id=5,MenuItemId=5,OrderId=5,Quantity=2}
        };
        modelBuilder.Entity<OrderItem>()
            .HasData(orderItems);
    }
}
