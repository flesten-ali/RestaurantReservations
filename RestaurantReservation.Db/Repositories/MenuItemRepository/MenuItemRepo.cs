using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.MenuItemRepository;

public class MenuItemRepo : IMenuItemRepo
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemRepo(RestaurantReservationDbContext context)
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
        if (menuItem == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, MenuItem menuItem)
    {
        if (id != menuItem.Id)
        {
            Console.WriteLine("Bad Request!");
            return;
        }
        _context.Entry(menuItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            if (!MenuItemExists(id))
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    private bool MenuItemExists(int id)
    {
        return _context.MenuItems.Any(x => x.Id == id);
    }
}
