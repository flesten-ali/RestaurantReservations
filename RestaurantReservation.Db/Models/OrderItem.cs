﻿namespace RestaurantReservation.Db.Models;

public class OrderItem
{
    public long Id { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
    public MenuItem MenuItem { get; set; }
    public int MenuItemId { get; set; }
}
