using System.ComponentModel.DataAnnotations;

namespace PulseRig.DataLayer.Entityes;

public class Station
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Group> Groups { get; set; }
}
