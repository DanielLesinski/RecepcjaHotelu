using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotel.Controllers
{
    using RecepcjaHotel.Models;
    public class ForbiddenController : Controller
    {
        // GET: ForbiddenController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ForbiddenController/Details/id
        public ActionResult Details(int id)
        {
            return View(new Forbidden(id));
        }
       
    }
}
