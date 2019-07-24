using BibliotecaModelos;
using EntityBiblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBiblioteca.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            ViewBag.Autor = new Autor();
            return View();
        }

        public ActionResult Adiciona(Autor autor)
        {
            AutorDAO dao = new AutorDAO();
            dao.Adicionar(autor);
            return View();
        }
    }
}