namespace Facotry.Models
{
  public class EngineerMachine
  {
    public int EngineerMachineId { get; set; }

    public int EngineerId { get; set; }
    public Engineer Engineer { get ; set; }
  }
}