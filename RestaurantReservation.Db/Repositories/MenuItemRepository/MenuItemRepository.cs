using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.MenuItemRepository;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var menuItem = await _context.MenuItems.FindAsync(id);
        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, MenuItem menuItem)
    {
        _context.Entry(menuItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool MenuItemExists(int id)
    {
        return _context.MenuItems.Any(x => x.Id == id);
    }

    public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
    {
        return await _context.MenuItems
            .Where(x => x.OrderItems.Any(oi => oi.Order.ReservationId == reservationId))
            .ToListAsync();
    }

    public async Task<MenuItem> GetById(int id)
    {
        return await _context.MenuItems.SingleOrDefaultAsync(x => x.Id == id);
    }
}
