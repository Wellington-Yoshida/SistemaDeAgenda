using SistemaAgendaDominio;
using SistemaAgendaORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAgendaWeb.Controllers
{
    public class HomeController : Controller
    {
        private Contexto db = new Contexto();
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}