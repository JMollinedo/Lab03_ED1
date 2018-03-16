using Lab03_ED1.DataBase;
using Lab03_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab03_ED1.Controllers
{
    public class PartidoController : Controller
    {
        DataAdmin Datos = DataAdmin.getInstance;
        // GET: Partido
        public ActionResult IndexFecha()
        {
            List<Partido> lista = new List<Partido>();
            Datos.fArbolAVL.Ordenar(ref lista, Datos.fArbolAVL.InOrder);
            return View(lista);
        }

        // GET: Partido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Partido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partido/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Partido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Partido/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Partido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Upload()
        {
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
                       

                        // Asignar un ID al país para editar o eliminar

                     foreach (var item in Datos.ListaPartidos)
                        {
                            item.ID = Datos.PartidoId;
                            Datos.PartidoId++;
                        }
                        

                        return RedirectToAction("IndexFecha");
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
    }
}
