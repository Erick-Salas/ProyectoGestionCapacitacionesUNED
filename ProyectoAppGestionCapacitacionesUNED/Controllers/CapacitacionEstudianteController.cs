using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAppGestionCapacitacionesUNED.DbContext;
using ProyectoAppGestionCapacitacionesUNED.Helpers;
using ProyectoAppGestionCapacitacionesUNED.Models;

namespace ProyectoAppGestionCapacitacionesUNED.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class CapacitacionEstudianteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CapacitacionEstudianteController(ApplicationDbContext db)
        {
            _db = db;

        }

        public IActionResult Index(string searchString, int pageNumber = 1, int pageSize = 10)
        {

            ViewBag.CurrentFilter = searchString;
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var CapacitacionEstudiantes = from b in _db.CapacitacionEstudiantes select b;

            var CapacitacionCount = CapacitacionEstudiantes.Count();

            if (!String.IsNullOrEmpty(searchString))
            {
                CapacitacionEstudiantes = CapacitacionEstudiantes.Where(b => b.Codigo.Contains(searchString));
                CapacitacionCount = CapacitacionEstudiantes.Count();
            }

            CapacitacionEstudiantes = CapacitacionEstudiantes.Skip(ExcludeRecords)
                .Take(pageSize);

            var result = new PagedResult<CapacitacionEstudiante>
            {
                Data = CapacitacionEstudiantes.AsNoTracking().ToList(),
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
        public IActionResult Create(CapacitacionEstudiante capacitacion)
        {
            if (capacitacion.HorarioSalida < capacitacion.HorarioInicio)
            {
                ModelState.AddModelError("HorarioInicio", "La hora de inicio no debe ser mayor a la hora de salida");
            }

            if (ModelState.IsValid)
            {
                _db.CapacitacionEstudiantes.Add(capacitacion);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(capacitacion);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            var capacitacion = _db.CapacitacionEstudiantes.Find(id);

            if (capacitacion == null)
            {
                return NotFound();
            }
            if (_db.RegistroEstudiantes.Any(m => m.CapacitacionEstudianteFK == id))
            {
                var registroEstudiante = _db.RegistroEstudiantes.Where(m => m.CapacitacionEstudianteFK == id).ToList();
                _db.RegistroEstudiantes.RemoveRange(registroEstudiante);
            }
            if (_db.AsistenciaEstudiantes.Any(m => m.CapacitacionEstudianteID == id))
            {
                var registroAsistencia = _db.AsistenciaEstudiantes.Where(m => m.CapacitacionEstudianteID == id).ToList();
                _db.AsistenciaEstudiantes.RemoveRange(registroAsistencia);
            }
            if (_db.EncuestaEstudiantes.Any(m => m.CapacitacionEstudianteID == id))
            {
                var registroEncuesta = _db.EncuestaEstudiantes.Where(m => m.CapacitacionEstudianteID == id).ToList();
                _db.EncuestaEstudiantes.RemoveRange(registroEncuesta);
            }

            _db.CapacitacionEstudiantes.Remove(capacitacion);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var capacitacion = _db.CapacitacionEstudiantes.SingleOrDefault(b => b.Id == id);


            if (capacitacion == null)
            {
                return NotFound();
            }

            return View(capacitacion);
        }
    }
}