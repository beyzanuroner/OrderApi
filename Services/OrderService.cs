using OrderApi.Models;
using OrderApi.Exceptions;

namespace OrderApi.Services;

public class OrderService : IOrderService
{
    private static readonly List<Order> _orders = new()
    {
        new Order { Id = 1, CustomerName = "Ali", TotalAmount = 500 },
        new Order { Id = 2, CustomerName = "Ayşe", TotalAmount = 1200 }
    };

    public List<Order> GetAll() => _orders;

    public Order GetById(int id)
    {
        var order = _orders.FirstOrDefault(x => x.Id == id);

        if (order == null)
            throw new NotFoundException("Order not found.");

        return order;
    }

    public Order Create(Order order)
{
    if (order.TotalAmount < 100)
        throw new BadRequestException("Minimum order amount is 100.");

    order.Id = _orders.Max(x => x.Id) + 1;
    _orders.Add(order);
    return order;
}

    public void Update(int id, Order updated)
    {
        var order = GetById(id); // zaten exception atacak

        order.CustomerName = updated.CustomerName;
        order.TotalAmount = updated.TotalAmount;
    }

    public void Delete(int id)
    {
        var order = GetById(id); // zaten exception atacak
        _orders.Remove(order);
    }
}