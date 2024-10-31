using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.CustomerRepository;

public class CustomerRepo : ICustomerRepo
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepo(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            Console.WriteLine("Bad Request!");
            return;
        }
        _context.Entry(customer).State = EntityState.Modified;

        Console.WriteLine(_context.ChangeTracker.DebugView.ShortView);

        try
        {
            Console.WriteLine();
            await _context.SaveChangesAsync();
        }
        catch
        {
            if (!CustomerExists(id))
            {
                Console.WriteLine("Not Found!");
            }
            else
            {
                throw;
            }
        }
    }

    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(x => x.Id == id);
    }

    public async Task Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CustomersPartySize>> CustomersReservationsWithPartySize(int size)
    {
        return await _context.Set<CustomersPartySize>()
            .FromSqlInterpolated($"FindCustomersWithPartySize {size}")
            .AsNoTracking()
            .ToListAsync();
    }
}
