﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;
using BEUEjercicio.Transactions;

namespace ProyecCertificacion.Controllers
{
    public class AlumnosController : Controller
    {
        // private Entities db = new Entities();

        
        // GET: Alumnos
        public ActionResult Index()
        {
            /*List<Alumno> a = new List<Alumno>();
            a.Add(AlumnoBLL.Get(1002));*/
            ViewBag.Title = "Listado de alumnos registrados";
            return View("List",AlumnoBLL.List());//ejemplo del metodo View sobrecargado, el primer parametro indica el nombre de la vista y el segundo el modelo
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = AlumnoBLL.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();//Alumno no encontrado
            }
            return View(alumno);//Vista + modelo
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idalumno,nombres,apellidos,cedula,fecha_nacimiento,lugar_nacimiento,sexo")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
               // AlumnoTBLL alumnoTBLL = new AlumnoTBLL(false);
                AlumnoBLL.Create(alumno);
               // db.Alumnoes.Add(alumno);
               // db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = AlumnoBLL.Get(id);   //db.Alumnoes.Find(id);
            if (alumno == null)
            {
                return HttpNotFound(); 
            }
            return View(alumno); //vista + alumno
        }

        // POST: Alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idalumno,nombres,apellidos,cedula,fecha_nacimiento,lugar_nacimiento,sexo")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
               // AlumnoTBLL alumnoTBLL = new AlumnoTBLL(true);
                AlumnoBLL.Update(alumno);
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = AlumnoBLL.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Alumno alumno = db.Alumnoes.Find(id);
            //db.Alumnoes.Remove(alumno);
            //db.SaveChanges();
            AlumnoBLL.Delete(id);
            return RedirectToAction("Index");
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
