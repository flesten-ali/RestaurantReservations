using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.ReservationRepository;

public class ReservationRepo : IReservationRepo
{
    private RestaurantReservationDbContext _context;

    public ReservationRepo(RestaurantReservationDbContext context)
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
        if (reservation == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Reservation reservation)
    {
        if (id != reservation.Id)
        {
            Console.WriteLine("Bad Request!");
            return;
        }
        _context.Entry(reservation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            if (!ReservationExists(id))
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    private bool ReservationExists(int id)
    {
        return _context.Reservations.Any(x => x.Id == id);
    }
}
