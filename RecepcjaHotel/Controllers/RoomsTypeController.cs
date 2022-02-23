using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotel.Controllers
{
    using RecepcjaHotel.Models;
    using RecepcjaHotel.Repo;

    public class RoomsTypeController : Controller
    {
        private readonly RepoRoomsType repoRoomsType;

        public RoomsTypeController(RepoRoomsType repoRoomsType)
        {
            this.repoRoomsType = repoRoomsType;
        }

        // GET: RoomsTypeController
        public ActionResult Index()
        {
            return View(repoRoomsType.GetAll);
        }

        // GET: RoomsTypeController/Details/id
        public ActionResult Details(int id)
        {
            return View(repoRoomsType.Get(id));
        }

        // GET: RoomsTypeController/Create
        public ActionResult Create()
        {
            return View(new RoomsType());
        }

        // POST: RoomsTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomsType roomsType)
        {
            repoRoomsType.Add(roomsType);
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomsTypeController/Edit/id
        public ActionResult Edit(int id)
        {
            return View(repoRoomsType.Get(id));
        }

        // POST: RoomsTypeController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoomsType roomsType)
        {
            if(repoRoomsType.Update(id, roomsType))
                return RedirectToAction(nameof(Index));
            int info = 0;
            return RedirectToAction("Details", "Forbidden", new { id = info });
        }

        // GET: RoomsTypeController/Delete/id
        public ActionResult Delete(int id)
        {
            return View(repoRoomsType.Get(id));
        }

        // POST: RoomsTypeController/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if(repoRoomsType.Delete(id))
                return RedirectToAction(nameof(Index));
            int info = 0;
            return RedirectToAction("Details", "Forbidden", new { id = info });
        }
    }
}
