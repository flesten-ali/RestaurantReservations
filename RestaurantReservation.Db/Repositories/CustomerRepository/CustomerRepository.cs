using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.CustomerRepository;

public class CustomerRepository : ICustomerRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
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
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(x => x.Id == id);
    }

    public async Task Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
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

    public async Task<Customer> GetById(int id)
    {
        return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
    }
}
