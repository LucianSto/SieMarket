using SieMarket.Models;

var order = new Order
{
    Id = 1,
    CustomerId = "67",
    Items =
    {
        new OrderItem
        {
            ProductName = "Laptop",
            Quantity = 1,
            UnitPrice = 600m // m decimal
        },
        new OrderItem
        {
            ProductName = "Mouse",
            Quantity = 2,
            UnitPrice = 25m // m decimal
        }
    }
};

// display the total value of all items before discount
Console.WriteLine($"Subtotal: {order.Subtotal} EUR");

// display the discount amount applied (> 500EUR)
Console.WriteLine($"Discount: {order.DiscountAmount} EUR");

// display the final total after applying the discount policy
Console.WriteLine($"Total: {order.Total} EUR");

// prevent the console window from closing immediately
Console.ReadKey();
