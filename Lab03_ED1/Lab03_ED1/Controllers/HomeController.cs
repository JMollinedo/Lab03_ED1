using Lab03_ED1.DataBase;
using Lab03_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab03_ED1.Controllers
{
    public class HomeController : Controller
    {
        DataAdmin Datos = DataAdmin.getInstance;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.Message = "Cargar Archivo Jason";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".json"))
                    {
                        JsonReader<Partido> LectorJson = new JsonReader<Partido>();
                        List<Partido> Partidos = LectorJson.Datos(upload.InputStream);
                        foreach(Partido match in Partidos)
                        {
                            Datos.fArbolAVL.Insertar(match);
                            Datos.nArbolAVL.Insertar(match);
                        }

                        // Asignar un ID al país para editar o eliminar

                        foreach (var item in Datos.fListaPartidos)
                        {
                            item.ID = Datos.PartidoId;
                            Datos.PartidoId++;
                        }


                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}