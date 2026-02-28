using System;
using System.Collections.Generic;
using System.Linq;
using SieMarket.Models;
using SieMarket.Services;

var orders = new List<Order>
{
    new Order
    {
        CustomerId = "George",
        Items =
        {
            new OrderItem { 
                ProductName = "Laptop", 
                Quantity = 1, 
                UnitPrice = 600m } // m decimal
        }
    },

    new Order
    {
        CustomerId = "Maria",
        Items =
        {
            new OrderItem {
                ProductName = "Phone",
                Quantity = 2,
                UnitPrice = 700m } // m decimal
        }
    },
    new Order
    {
        CustomerId = "George",
        Items =
        {
            new OrderItem {
                ProductName = "Headphones",
                Quantity = 1,
                UnitPrice = 200m } // m decimal
        }
    }
};


// take the first order
var firstOrder = orders[0];

Console.WriteLine($"Customer: {firstOrder.CustomerId}");

// display the total value of all items before discount 
Console.WriteLine($"Subtotal: {firstOrder.Subtotal} EUR");

// display the discount amount applied (> 500EUR)
Console.WriteLine($"Discount: {firstOrder.DiscountAmount} EUR");

// display the final total after applying the discount policy
Console.WriteLine($"Total: {firstOrder.Total} EUR\n");

// how much each customer spent
var spendingPerCustomer = orders
    .GroupBy(o => o.CustomerId)
    .Select(group => new
    {
        Customer = group.Key,
        TotalSpent = group.Sum(o => o.Total)
    });

foreach (var customer in spendingPerCustomer)
{
    Console.WriteLine($"{customer.Customer} spent (total): {customer.TotalSpent} EUR");
}

// top spenders
var service = new OrderService();
var topCustomer = service.GetTopSpendingCustomer(orders);

Console.WriteLine($"\nTop spending customer: {topCustomer}\n");

// most popular products and their total quantity sold
var popularProducts = service.GetPopularProducts(orders);

foreach (var product in popularProducts)
{
    Console.WriteLine($"{product.ProductName} sold: {product.TotalQuantity} units");
}