using System.ComponentModel.DataAnnotations;
using Core.Models;
using Microsoft.EntityFrameworkCore;

public class EventType
{
    public string TypeName { get; set; }
    [Key]
    public int TypeId { get; set; }

    public List<EventInfo> Events { get; set; }
}