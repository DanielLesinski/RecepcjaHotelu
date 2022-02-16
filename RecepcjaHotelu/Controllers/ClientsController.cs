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

    public class ClientsController : Controller
    {
        private readonly DataClients dataClients;

        public ClientsController(DataClients dataClients)
        {
            this.dataClients = dataClients;
        }

        // GET: ClientsController
        public ActionResult Index()
        {
            return View(dataClients.GetAll);
        }

        // GET: ClientsController/Details/id
        public ActionResult Details(int id)
        {
            return View(dataClients.Get(id));
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            return View(new ClientsModel());
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientsModel clients)
        {
            dataClients.Add(clients);
            return RedirectToAction(nameof(Index));
        }

        // GET: ClientsController/Edit/id
        public ActionResult Edit(int id)
        {
            return View(dataClients.Get(id));
        }

        // POST: ClientsController/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientsModel clients)
        {
            dataClients.Update(id, clients);
            return RedirectToAction(nameof(Index));
        }

        // GET: ClientsController/Delete/id
        public ActionResult Delete(int id)
        {
            return View(dataClients.Get(id));
        }

        // POST: ClientsController/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClientsModel clients)
        {
            dataClients.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
