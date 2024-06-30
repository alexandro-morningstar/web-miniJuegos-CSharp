using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMiniJuegos.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Quiz()
        {
            return View("DwarfQuiz");
        }

        public ActionResult Nightmare()
        {
            return View("Dungeon");
        }

        public ActionResult PokeBattle()
        {
            return View("PokemonBattle");
        }
    }
}