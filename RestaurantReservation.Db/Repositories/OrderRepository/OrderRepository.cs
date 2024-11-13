using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.OrderRepository;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool OrderExists(int id)
    {
        return _context.Orders.Any(x => x.Id == id);
    }

    public async Task<List<Order>> ListOrdersAndMenuItems(int reservationId)
    {
        return await _context.Orders.Include(o => o.OrderItems).Where(o => o.ReservationId == reservationId).ToListAsync();
    }

    public async Task<double> CalculateAverageOrderAmount(int employeeId)
    {
        return await _context.Orders.Where(o=>o.EmployeeId == employeeId).AverageAsync(x=>x.TotalAmount);
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
    {
       return await _context.OrderItems
            .Where(oi =>oi.Order.ReservationId == reservationId)
            .Select(oi=>oi.MenuItem)
            .ToListAsync();
    }

    public async Task<Order> GetById(int id)
    {
        return await _context.Orders.SingleOrDefaultAsync(x => x.Id == id);
    }
}
