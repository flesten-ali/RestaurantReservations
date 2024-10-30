class Program
{
    public static async Task Main(string[] args)
    {
        RestaurantReservationDbContext context = new();
        await TestTable(context);
    }

    private static async Task TestEmployee(RestaurantReservationDbContext context)
    {
        var emp = new Employee
        {
            FirstName = "emp6",
            LastName = "A",
            Position = "Manager",
            RestaurantId = 1,
        };
        Test<Employee> t = new(new EmployeeRepo(context));
        await t.TestAdd(emp);
        await t.TestUpdate(6, new Employee { Id = 6, FirstName = "Update emp6", LastName = "B", RestaurantId = 1, Position = "CEO" });
        await t.TestDelete(6);
    }

    private static async Task TestCustomer(RestaurantReservationDbContext context)
    {
        var customer = new Customer
        {
            FirstName = "Cus7",
            LastName = "A",
            Email = "Cus7@gmail.com",
            PhoneNumbers = "12131",
        };
        Test<Customer> t = new(new CustomerRepo(context));
        await t.TestAdd(customer);
        await t.TestUpdate(6, new Customer { Id = 6, FirstName = "Update Cus6", LastName = "B", PhoneNumbers = "1234" });
        await t.TestDelete(6);
    }

    private static async Task TestMenuItem(RestaurantReservationDbContext context)
    {
        var menuItem = new MenuItem
        {
            Name = "Falafel",
            Price = 2,
            RestaurantId = 2
        };
        Test<MenuItem> t = new(new MenuItemRepo(context));
        await t.TestAdd(menuItem);
        await t.TestUpdate(6, new MenuItem { Id = 6, Name = "Falafel Large", Price = 3, RestaurantId = 2 });
        await t.TestDelete(6);
    }

    private static async Task TestOrderItem(RestaurantReservationDbContext context)
    {
        var orderItem = new OrderItem
        {
            MenuItemId = 4,
            OrderId = 2,
            Quantity = 3,
        };
        Test<OrderItem> t = new(new OrderItemRepo(context));
        await t.TestAdd(orderItem);
        await t.TestUpdate(6, new OrderItem { Id = 6, MenuItemId = 4, OrderId = 3 });
        await t.TestDelete(6);
    }

    private static async Task TestOrder(RestaurantReservationDbContext context)
    {
        var order = new Order
        {
            EmployeeId = 1,
            ReservationId = 1,
            TotalAmount = 150,
            OrderDate = new DateTime()
        };
        Test<Order> t = new(new OrderRepo(context));
        await t.TestAdd(order);
        order.TotalAmount = 130;
        order.Id = 6;
        await t.TestUpdate(6, order);
        await t.TestDelete(6);
    }

    private static async Task TestReservation(RestaurantReservationDbContext context)
    {
        var reservation = new Reservation
        {
            PartySize = 10,
            CustomerId = 1,
            ReservationDate = new DateTime(),
            RestaurantId = 3,
            TableId = 4
        };
        Test<Reservation> t = new(new ReservationRepo(context));
        await t.TestAdd(reservation);
        reservation.PartySize = 12;
        reservation.Id = 6;
        await t.TestUpdate(6, reservation);
        await t.TestDelete(6);
    }

    private static async Task TestRestaurant(RestaurantReservationDbContext context)
    {
        var restaurant = new Restaurant
        {
            Name = "Teen",
            OpeningHours = 14,
            PhoneNumber = "095812",
            Adress = "Tulkarm",
        };
        Test<Restaurant> t = new(new RestaurantRepo(context));
        await t.TestAdd(restaurant);
        restaurant.Adress = "Nablus";
        restaurant.Id = 6;
        await t.TestUpdate(6, restaurant);
        await t.TestDelete(6);
    }

    private static async Task TestTable(RestaurantReservationDbContext context)
    {
        var table = new Table
        {
            Capacity = 9,
            RestaurantId = 1
        };
        Test<Table> t = new(new TableRepo(context));
        await t.TestAdd(table);
        table.RestaurantId = 2;
        table.Id = 7;
        await t.TestUpdate(7, table);
        await t.TestDelete(7);
    }
}