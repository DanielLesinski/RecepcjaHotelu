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

    public class ClientController : Controller
    {
        private readonly RepoClient repoClient;

        public ClientController(RepoClient repoClient)
        {
            this.repoClient = repoClient;
        }

        // GET: ClientsController
        public ActionResult Index()
        {
            return View(repoClient.GetAll);
        }

        // GET: ClientsController/Details/id
        public ActionResult Details(int id)
        {
            return View(repoClient.Get(id));
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            return View(new Client());
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            repoClient.Add(client);
            return RedirectToAction(nameof(Index));
        }

        // GET: ClientsController/Edit/id
        public ActionResult Edit(int id)
        {
            return View(repoClient.Get(id));
        }

        // POST: ClientsController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client client)
        {
            if(repoClient.Update(id, client))
                return RedirectToAction(nameof(Index));
            int info = 2;
            return RedirectToAction("Details", "Forbidden", new { id = info });
        }

        // GET: ClientsController/Delete/id
        public ActionResult Delete(int id)
        {
            return View(repoClient.Get(id));
        }

        // POST: ClientsController/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if(repoClient.Delete(id))
                return RedirectToAction(nameof(Index));
            int info = 2;
            return RedirectToAction("Details", "Forbidden", new { id = info });
        }
    }
}
