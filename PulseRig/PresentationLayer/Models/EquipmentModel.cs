using Microsoft.AspNetCore.Mvc.Rendering;
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

    [Required(ErrorMessage = "Тип является обязательным полем!")]
    public string Type { get; set; } = string.Empty;

    [Required(ErrorMessage = "Заводской номер является обязательным полем!")]
    public string FactoryNumber { get; set; } = string.Empty;

    public int GroupId { get; set; } = 0;
    public List<SelectListItem> Groups { get; set; } = new();

}
