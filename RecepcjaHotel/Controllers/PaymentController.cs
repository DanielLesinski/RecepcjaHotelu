using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotel.Controllers
{
    using RecepcjaHotel.Repo;
    public class PaymentController : Controller
    {
        private readonly RepoPayment repoPayment;

        public PaymentController(RepoPayment repoPayment)
        {
            this.repoPayment = repoPayment;
        }

        // GET: PaymentController
        public ActionResult Index()
        {
            return View(repoPayment.GetAll);
        }

    }
}
