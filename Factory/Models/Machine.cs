using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set;}
    public string Name { get; set; }
    public List <EngineerMachine> EngineerMachines { get; set; }
  }
}