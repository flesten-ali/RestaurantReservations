using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.ReservationRepository;

public class ReservationRepository : IReservationRepository
{
    private RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Reservation reservation)
    {
        _context.Entry(reservation).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool ReservationExists(int id)
    {
        return _context.Reservations.Any(x => x.Id == id);
    }

    public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
    {
        return await _context.Reservations.Where(r => r.CustomerId == customerId).ToListAsync();
    }

    public async Task<List<ReservationView>> AllReservationsWithTheirAssociatedCustomerAndRestaurant()
    {
        return await _context.ReservationDetails.ToListAsync();
    }

    public async Task<Reservation> GetById(int id)
    {
        return await _context.Reservations.SingleOrDefaultAsync(x => x.Id == id);
    }
}
