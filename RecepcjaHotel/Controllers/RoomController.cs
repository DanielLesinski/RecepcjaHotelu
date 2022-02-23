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
    public class RoomController : Controller
    {
        private readonly RepoRoom repoRoom;

        public RoomController(RepoRoom repoRoom)
        {
            this.repoRoom = repoRoom;
        }

        // GET: RoomController
        public ActionResult Index()
        {
            return View(repoRoom.GetAll);
        }

        // GET: RoomController/Details/id
        public ActionResult Details(int id)
        {
            return View(repoRoom.Get(id));
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View(new Room());
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            repoRoom.Add(room);
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomController/Edit/id
        public ActionResult Edit(int id)
        {
            return View(repoRoom.Get(id));
        }

        // POST: RoomController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Room room)
        {
            if(repoRoom.Update(id, room))
                return RedirectToAction(nameof(Index));
            int info = 1;
            return RedirectToAction("Details", "Forbidden", new { id = info });
        }

        // GET: RoomController/Delete/id
        public ActionResult Delete(int id)
        {
            return View(repoRoom.Get(id));
        }

        // POST: RoomController/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if(repoRoom.Delete(id))
                return RedirectToAction(nameof(Index));
            int info = 1;
            return RedirectToAction("Details", "Forbidden", new { id = info });
        }
    }
}
