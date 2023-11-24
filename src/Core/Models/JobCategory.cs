using System.ComponentModel.DataAnnotations;
using Core.Models;
using Microsoft.EntityFrameworkCore;

public class JobCategory
{
    public string CategoryName { get; set; }
    [Key]
    public int CategoryId { get; set; }
}
