using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Controllers
{
    using RecepcjaHotelu.Models;
    using RecepcjaHotelu.Data;
    public class RoomsTypeController : Controller
    {
        private readonly DataRoomsType dataRoomsType;

        public RoomsTypeController(DataRoomsType dataRoomsType)
        {
            this.dataRoomsType = dataRoomsType;
        }

        // GET: RoomsTypeController
        public ActionResult Index()
        {
            return View(dataRoomsType.GetAll);
        }

        // GET: RoomsTypeController/Details/id
        public ActionResult Details(int id)
        {
            return View(dataRoomsType.Get(id));
        }

        // GET: RoomsTypeController/Create
        public ActionResult Create()
        {
            return View(new RoomsTypeModel());
        }

        // POST: RoomsTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomsTypeModel roomsType)
        {
            dataRoomsType.Add(roomsType);
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomsTypeController/Edit/id
        public ActionResult Edit(int id)
        {
            return View(dataRoomsType.Get(id));
        }

        // POST: RoomsTypeController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoomsTypeModel roomsType)
        {
            dataRoomsType.Update(id, roomsType);
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomsTypeController/Delete/id
        public ActionResult Delete(int id)
        {
            return View(dataRoomsType.Get(id));
        }

        // POST: RoomsTypeController/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RoomsTypeModel roomsType)
        {
            dataRoomsType.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
