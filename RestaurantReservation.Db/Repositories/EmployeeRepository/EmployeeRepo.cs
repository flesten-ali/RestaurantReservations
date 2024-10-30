using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.EmployeeRepository;

public class EmployeeRepo : IEmployeeRepo
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepo(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var emp = await _context.Employees.FindAsync(id);
        if (emp == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        _context.Employees.Remove(emp);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            Console.WriteLine("Bad Request!");
            return;
        }
        _context.Entry(employee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            if (!EmployeeExists(id))
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    private bool EmployeeExists(int id)
    {
        return _context.Employees.Any(x => x.Id == id);
    }
}
