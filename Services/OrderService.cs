using System.Collections.Generic;
using System.Linq;
using SieMarket.Models;

namespace SieMarket.Services;

public class OrderService
{
    public string GetTopSpendingCustomer(List<Order> orders)
    {
        var result = orders
            .GroupBy(o => o.CustomerId)              // group orders by customerId
            .Select(group => new
            {
                CustomerId = group.Key,
                TotalSpent = group.Sum(o => o.Total) // sum of all customer orders
            })
            .OrderByDescending(x => x.TotalSpent)    // sort descending
            .FirstOrDefault();                       // take the first

        return result?.CustomerId ?? "No customers";
    }
}