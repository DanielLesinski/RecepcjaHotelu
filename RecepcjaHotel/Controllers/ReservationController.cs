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
    public class ReservationController : Controller
    {
        private readonly RepoReservation repoReservation;

        public ReservationController(RepoReservation repoReservation)
        {
            this.repoReservation = repoReservation;
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            return View(repoReservation.GetAll);
        }

        // GET: ReservationController/Details/id
        public ActionResult Details(int id)
        {
            return View(repoReservation.Get(id));
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            return View(new Reservation());
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            if(repoReservation.Add(reservation))
                return RedirectToAction(nameof(Index));
            int info = 3;
            return RedirectToAction("Details", "Forbidden", new { id = info });
        }

        // GET: ReservationController/Edit/id
        public ActionResult Edit(int id)
        {
            return View(repoReservation.Get(id));
        }

        // POST: ReservationController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Reservation reservation)
        {
            if(repoReservation.Update(id,reservation))
                return RedirectToAction(nameof(Index));
            int info = 3;
            return RedirectToAction("Details", "Forbidden", new { id = info });
        }

        // GET: ReservationController/Delete/id
        public ActionResult Delete(int id)
        {
            return View(repoReservation.Get(id));
        }

        // POST: ReservationController/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            repoReservation.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
