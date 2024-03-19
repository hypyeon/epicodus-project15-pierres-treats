using Microsoft.EntityFrameworkCore;

namespace PierresTreats.Models
{
  public class ToDoListContext : DbContext
  {
    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<TreatFlavor> TreatFlavors { get; set; }
    public ToDoListContext(DbContextOptions options) : base(options) { }
  }
}