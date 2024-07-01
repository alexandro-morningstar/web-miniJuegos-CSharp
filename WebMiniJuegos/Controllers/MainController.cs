using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMiniJuegos.Models;

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

            if (Session["index"] == null) // Si no existe un Session, iniciamos uno a 0 con el identificador "index"
            {
                Session["index"] = 0;
            }

            int index = (int)Session["index"]; // Asignamos el valor del Session (que es un objeto) como valor entero a la variable index
            
            // Instanciamos
            DwarfQuiz newQuiz = new DwarfQuiz();

            // Llamamos a la pregunta en el indice actual
            string question = newQuiz.GetQuestion(index);
            TempData["question"] = question;

            // Llamamos las opciones de la pregunta
            List<string> options = newQuiz.GetOptions(index);
            TempData["a"] = options[0];
            TempData["b"] = options[1];
            TempData["c"] = options[2];
            TempData["d"] = options[3];


            Session["index"] = (int)Session["index"] + 1;

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