﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.OrderRepository;

public class OrderRepo : IOrderRepo
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepo(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task Add(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            Console.WriteLine("Not Found!");
            return;
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, Order order)
    {
        if (id != order.Id)
        {
            Console.WriteLine("Bad Request!");
            return;
        }
        _context.Entry(order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            if (!OrderExists(id))
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    private bool OrderExists(int id)
    {
        return _context.Orders.Any(x => x.Id == id);
    }
}