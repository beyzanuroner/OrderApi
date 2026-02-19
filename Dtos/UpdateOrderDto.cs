using System.ComponentModel.DataAnnotations;

namespace OrderApi.Dtos;

public class UpdateOrderDto
{
    [Required]
    public string CustomerName { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal TotalAmount { get; set; }
}