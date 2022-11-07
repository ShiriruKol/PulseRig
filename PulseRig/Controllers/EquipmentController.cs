using Microsoft.AspNetCore.Mvc;
using PulseRig.BuissnesLayer;
using PulseRig.PresentationLayer;
using PulseRig.PresentationLayer.Models;

namespace PulseRig.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly DataManager _datamanager;
        private readonly ServicesManager _servicesmanager;

        public EquipmentController(DataManager datamanager, ServicesManager servicesmanager)
        {
            _datamanager = datamanager;
            _servicesmanager = servicesmanager;
        }

        public IActionResult Index()
        {
            List<EquipmentViewModel> _dirs = _servicesmanager.Equipments.GetEquipmentList();
            return View(_dirs);
        }
    }
}
