using Microsoft.AspNetCore.Mvc;
using OrderApi.Services;
using OrderApi.Dtos;
using OrderApi.Models;
using Microsoft.AspNetCore.Authorization;


namespace OrderApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
        => Ok(_service.GetById(id));

    [HttpPost]
    public IActionResult Create(CreateOrderDto dto)
    {
        var order = new Order
        {
            CustomerName = dto.CustomerName,
            TotalAmount = dto.TotalAmount
        };

        var created = _service.Create(order);

        return CreatedAtAction(nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateOrderDto dto)
    {
        var order = new Order
        {
            CustomerName = dto.CustomerName,
            TotalAmount = dto.TotalAmount
        };

        _service.Update(id, order);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}