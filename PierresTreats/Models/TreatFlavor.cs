namespace PierresTreats.Models
{
  public class TreatFlavor
  {       
    public Treat Treat { get; set; }
    public Flavor Flavor { get; set; }
    public int TreatId { get; set; }
    public int FlavorId { get; set; }
    public int TreatFlavorId { get; set; }
  }
}