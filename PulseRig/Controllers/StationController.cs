using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PulseRig.BuissnesLayer;
using PulseRig.BuissnesLayer.Interfaces;
using PulseRig.DataLayer;
using PulseRig.DataLayer.Entityes;
using PulseRig.PresentationLayer;
using PulseRig.PresentationLayer.Models;

namespace PulseRig.Controllers
{
    public class StationController : Controller
    {
        private readonly DataManager _datamanager;
        private readonly ServicesManager _servicesmanager;

        public StationController(DataManager datamanager, ServicesManager servicesmanager)
        {
            _datamanager = datamanager;
            _servicesmanager = servicesmanager;
        }

        public IActionResult Index()
        {
            List<StationViewModel> _dirs = _servicesmanager.Stations.GetStationList();
            return View(_dirs);
        }
    }
}
