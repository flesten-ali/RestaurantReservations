using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.RestaurantRepository;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantRepository(RestaurantReservationDbContext context)
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
        _context.Restaurants.Remove(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Restaurant restaurant)
    {
        _context.Entry(restaurant).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool RestaurantExists(int id)
    {
        return _context.Restaurants.Any(x => x.Id == id);
    }

    public async Task<decimal> CalculateTheTotalRevenue(int restaurantId)
    {
        var result = await _context.Set<RevenueResult>()
             .FromSqlInterpolated($"SELECT dbo.CalculateTotalRevenue({restaurantId}) AS TotalRevenue")
             .AsNoTracking()
             .SingleAsync();
        return result.TotalRevenue;
    }

    public async Task<Restaurant> GetById(int id)
    {
        return await _context.Restaurants.SingleOrDefaultAsync(x => x.Id == id);
    }
}
