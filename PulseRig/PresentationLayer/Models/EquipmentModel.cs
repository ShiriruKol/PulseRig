using PulseRig.DataLayer.Entityes;
using System.ComponentModel.DataAnnotations;

namespace PulseRig.PresentationLayer.Models;

public class EquipmentViewModel
{
    public Equipment Equipment { get; set; }

    public string GroupName { get; set; }
}

public class EquipmentEditViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string FactoryNumber { get; set; }
    public int Groupid { get; set; }

}
