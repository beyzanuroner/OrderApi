using OrderApi.Models;

namespace OrderApi.Services;

public interface IOrderService
{
    List<Order> GetAll();
    Order GetById(int id);
    Order Create(Order order);
    void Update(int id, Order order);
    void Delete(int id);
}