using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PierresTreats.Models
{
  public class Treat
  {
    [Required(ErrorMessage = "Name of the treat can't be empty.")]
    public string Name { get; set; }
    public int TreatId { get; set; }
    public List<TreatFlavor> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}
