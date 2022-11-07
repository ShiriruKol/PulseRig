using Microsoft.AspNetCore.Mvc;
using PulseRig.BuissnesLayer;
using PulseRig.PresentationLayer;
using PulseRig.PresentationLayer.Models;

namespace PulseRig.Controllers;

public class GroupController : Controller
{
    private readonly DataManager _datamanager;
    private readonly ServicesManager _servicesmanager;

    public GroupController(DataManager datamanager, ServicesManager servicesmanager)
    {
        _datamanager = datamanager;
        _servicesmanager = servicesmanager;
    }

    public IActionResult Index()
    {

        List<GroupViewModel> _dirs = _servicesmanager.Groups.GetGroupsList();
        return View(_dirs);
    }
}
