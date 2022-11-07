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

        [HttpGet]
        public IActionResult Add()
        {
            return View(new StationEditModel());
        }

        [HttpPost]
        public IActionResult Add(StationEditModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name.Trim()))
                ModelState.AddModelError(nameof(model.Name), "Указано некорректное наименование!");

            if (!ModelState.IsValid)
                return View(model);

            _servicesmanager.Stations.SaveStationEditModelToDb(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _servicesmanager.Stations.GetStationEditModel(id);
            if (model == null)
                return NotFound(nameof(model));

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StationEditModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name.Trim()))
                ModelState.AddModelError(nameof(model.Name), "Указано некорректное наименование!");

            if (!ModelState.IsValid)
                return View(model);

            _servicesmanager.Stations.SaveStationEditModelToDb(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            _servicesmanager.Stations.DeleteStation(id);
            return RedirectToAction("Index");
        }
    }
}
