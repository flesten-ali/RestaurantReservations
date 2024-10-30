using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.TableRepository;

public class TableRepo : ITableRepo
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepo(RestaurantReservationDbContext context)
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
        if (table == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Table table)
    {
        if (id != table.Id)
        {
            Console.WriteLine("Bad Request!");
            return;
        }
        _context.Entry(table).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            if (!TableExists(id))
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    private bool TableExists(int id)
    {
        return _context.Tables.Any(x => x.Id == id);
    }
}
