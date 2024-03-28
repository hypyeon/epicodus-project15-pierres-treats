using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PierresTreats.Models
{
  public class Flavor
  {
    [Required(ErrorMessage = "Name of the treat can't be empty.")]
    public string Name { get; set; }
    public int FlavorId { get; set; }
    public List<TreatFlavor> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}
