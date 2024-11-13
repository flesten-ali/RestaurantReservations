using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.EmployeeRepository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
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
        _context.Employees.Remove(emp);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Employee employee)
    {
        _context.Entry(employee).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool EmployeeExists(int id)
    {
        return _context.Employees.Any(x => x.Id == id);
    }

    public async Task<List<Employee>> ListManagers()
    {
        return await _context.Employees.Where(e => e.Position == EmployeePosition.Manager.ToString()).ToListAsync();
    }

    public async Task<List<EmployeeView>> EmployeesWithRespectiveRestaurantDetails()
    {
        return await _context.EmployeesDetails.ToListAsync();
    }

    public async Task<Employee> GetById(int id)
    {
        return await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);
    }
}
