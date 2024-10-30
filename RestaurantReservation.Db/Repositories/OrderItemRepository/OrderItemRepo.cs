using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.OrderItemRepository;

public class OrderItemRepo : IOrderItemRepo
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemRepo(RestaurantReservationDbContext context)
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
        if (orderItem == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        _context.OrderItems.Remove(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, OrderItem orderItem)
    {
        if (id != orderItem.Id)
        {
            Console.WriteLine("Bad Request!");
            return;
        }
        _context.Entry(orderItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            if (!OrderItemExists(id))
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    private bool OrderItemExists(int id)
    {
        return _context.OrderItems.Any(x => x.Id == id);
    }
}
