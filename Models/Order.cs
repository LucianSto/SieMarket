using System;
using System.Collections.Generic;
using System.Linq;

namespace SieMarket.Models;

public class Order
{
    public int Id { get; set; }

    public string CustomerId { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // a list of items
    public List<OrderItem> Items { get; set; } = new();

    // sum of all line totals (no discount applied yet)
    public decimal Subtotal => Items.Sum(i => i.LineTotal);

    // calculates the final order price
    public decimal CalculateFinalPrice()
    {
        // if subtotal > 500 EUR, apply 10% discount to the entire order
        if (Subtotal > 500m)
            return Subtotal * 0.90m;

        return Subtotal;
    }

    public decimal Total => CalculateFinalPrice();

    // difference between subtotal and total
    public decimal DiscountAmount => Subtotal - Total;

    public bool HasDiscount => Subtotal > 500m;

}