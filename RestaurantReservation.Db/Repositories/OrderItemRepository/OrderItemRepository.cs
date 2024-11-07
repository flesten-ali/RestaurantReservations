using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.OrderItemRepository;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var orderItem = await _context.OrderItems.FindAsync(id);
        _context.OrderItems.Remove(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task<OrderItem> GetById(int id)
    {
        return await _context.OrderItems.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(int id, OrderItem orderItem)
    {
        _context.Entry(orderItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool OrderItemExists(int id)
    {
        return _context.OrderItems.Any(x => x.Id == id);
    }
}
