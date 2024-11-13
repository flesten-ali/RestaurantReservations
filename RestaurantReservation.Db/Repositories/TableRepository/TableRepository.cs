using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.TableRepository;

public class TableRepository : ITableRepository
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Table table)
    {
        await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var table = await _context.Tables.FindAsync(id);
        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
    }

    public async Task<Table> GetById(int id)
    {
        return await _context.Tables.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(int id, Table table)
    {
        _context.Entry(table).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool TableExists(int id)
    {
        return _context.Tables.Any(x => x.Id == id);
    }
}
