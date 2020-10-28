using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAppGestionCapacitacionesUNED.DbContext;
using ProyectoAppGestionCapacitacionesUNED.Helpers;
using ProyectoAppGestionCapacitacionesUNED.Models;

namespace ProyectoAppGestionCapacitacionesUNED.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class CapacitacionPersonalAcademicoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        public CapacitacionPersonalAcademicoController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            ViewBag.CurrentFilter = searchString;
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var CapacitacionPersonalAcademicos = from b in _db.CapacitacionPersonalAcademicos select b;

            var CapacitacionCount = CapacitacionPersonalAcademicos.Count();

            if (!String.IsNullOrEmpty(searchString))
            {
                CapacitacionPersonalAcademicos = CapacitacionPersonalAcademicos.Where(b => b.Codigo.Contains(searchString));
                CapacitacionCount = CapacitacionPersonalAcademicos.Count();
            }

            CapacitacionPersonalAcademicos = CapacitacionPersonalAcademicos.Skip(ExcludeRecords)
                .Take(pageSize);

            var result = new PagedResult<CapacitacionPersonalAcademico>
            {
                Data = CapacitacionPersonalAcademicos.AsNoTracking().ToList(),
                TotalItems = CapacitacionCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(result);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CapacitacionPersonalAcademico capacitacion)
        {
            if (capacitacion.HorarioSalida < capacitacion.HorarioInicio)
            {
                ModelState.AddModelError("HorarioInicio", "La hora de inicio no debe ser mayor a la hora de salida");
            }

            if (ModelState.IsValid)
            {
                _db.CapacitacionPersonalAcademicos.Add(capacitacion);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(capacitacion);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            var capacitacion = _db.CapacitacionPersonalAcademicos.Find(id);

            if (capacitacion == null)
            {
                return NotFound();
            }
            if (_db.RegistroPersonalAcademicos.Any(m => m.CapacitacionPersonalAcademicoID == id))
            {
                var registroPersonalAcademico = _db.RegistroPersonalAcademicos.Where(m => m.CapacitacionPersonalAcademicoID == id).ToList();
                _db.RegistroPersonalAcademicos.RemoveRange(registroPersonalAcademico);
            }
            if (_db.AsistenciaPersonalAcademicos.Any(m => m.CapacitacionPersonalAcademicoID == id))
            {
                var registroAsistencia = _db.AsistenciaPersonalAcademicos.Where(m => m.CapacitacionPersonalAcademicoID == id).ToList();
                _db.AsistenciaPersonalAcademicos.RemoveRange(registroAsistencia);
            }
            if (_db.EncuestaPersonalAcademicos.Any(m => m.CapacitacionPersonalAcademicoID == id))
            {
                var registroEncuesta = _db.EncuestaPersonalAcademicos.Where(m => m.CapacitacionPersonalAcademicoID == id).ToList();
                _db.EncuestaPersonalAcademicos.RemoveRange(registroEncuesta);
            }

            _db.CapacitacionPersonalAcademicos.Remove(capacitacion);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var capacitacion = _db.CapacitacionPersonalAcademicos.SingleOrDefault(b => b.Id == id);


            if (capacitacion == null)
            {
                return NotFound();
            }

            return View(capacitacion);
        }
    }
}