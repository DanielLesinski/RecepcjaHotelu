using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Controllers
{
    public class RoomsController : Controller
    {
        // GET: RoomsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RoomsController/Details/id
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomsController/Edit/id
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomsController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: RoomsController/Delete/id
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomsController/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
