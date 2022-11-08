using Microsoft.AspNetCore.Mvc.Rendering;
using PulseRig.DataLayer.Entityes;
using System.ComponentModel.DataAnnotations;

namespace PulseRig.PresentationLayer.Models;

public class GroupViewModel
{
    public Group Group { get; set; }
    public List<EquipmentViewModel> Equipments { get; set; }
}

public class GroupEditViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public int StationId { get; set; } = 0;
    public List<SelectListItem> Stations { get; set; } = new();
}
