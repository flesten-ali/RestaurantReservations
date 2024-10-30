using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.RestaurantRepository;

public class RestaurantRepo : IRestaurantRepo
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantRepo(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Restaurant restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Restaurant restaurant)
    {
        if (id != restaurant.Id)
        {
            Console.WriteLine("Bad Request!");
            return;
        }
        _context.Entry(restaurant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            if (!RestaurantExists(id))
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    private bool RestaurantExists(int id)
    {
        return _context.Restaurants.Any(x => x.Id == id);
    }
}
