using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace REST.API.Entities;

public class Book
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [StringLength(50)]
    public required string Genre { get; set; }
    [Range(1,100)]
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }
}