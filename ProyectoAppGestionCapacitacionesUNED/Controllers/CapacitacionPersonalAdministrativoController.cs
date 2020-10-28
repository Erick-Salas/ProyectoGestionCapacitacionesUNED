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
    public class CapacitacionPersonalAdministrativoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CapacitacionPersonalAdministrativoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            ViewBag.CurrentFilter = searchString;
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var CapacitacionPersonalAdministrativos = from b in _db.CapacitacionPersonalAdministrativos select b;

            var CapacitacionCount = CapacitacionPersonalAdministrativos.Count();

            if (!String.IsNullOrEmpty(searchString))
            {
                CapacitacionPersonalAdministrativos = CapacitacionPersonalAdministrativos.Where(b => b.Codigo.Contains(searchString));
                CapacitacionCount = CapacitacionPersonalAdministrativos.Count();
            }

            CapacitacionPersonalAdministrativos = CapacitacionPersonalAdministrativos.Skip(ExcludeRecords)
                .Take(pageSize);

            var result = new PagedResult<CapacitacionPersonalAdministrativo>
            {
                Data = CapacitacionPersonalAdministrativos.AsNoTracking().ToList(),
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
        public IActionResult Create(CapacitacionPersonalAdministrativo capacitacion)
        {
            if (capacitacion.HorarioSalida < capacitacion.HorarioInicio)
            {
                ModelState.AddModelError("HorarioInicio", "La hora de inicio no debe ser mayor a la hora de salida");
            }

            if (ModelState.IsValid)
            {
                _db.CapacitacionPersonalAdministrativos.Add(capacitacion);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(capacitacion);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {

            var capacitacion = _db.CapacitacionPersonalAdministrativos.Find(id);

            if (capacitacion == null)
            {
                return NotFound();
            }
            if (_db.RegistroPersonalAdministrativos.Any(m => m.CapacitacionPersonalAdministrativoID == id))
            {
                var registroPersonalAdministrativo = _db.RegistroPersonalAdministrativos.Where(m => m.CapacitacionPersonalAdministrativoID == id).ToList();
                _db.RegistroPersonalAdministrativos.RemoveRange(registroPersonalAdministrativo);
            }
            if (_db.AsistenciaPersonalAdministrativos.Any(m => m.CapacitacionPersonalAdministrativoID == id))
            {
                var registroAsistencia = _db.AsistenciaPersonalAdministrativos.Where(m => m.CapacitacionPersonalAdministrativoID == id).ToList();
                _db.AsistenciaPersonalAdministrativos.RemoveRange(registroAsistencia);
            }
            if (_db.EncuestaPersonalAdministrativos.Any(m => m.CapacitacionPersonalAdministrativoID == id))
            {
                var registroEncuesta = _db.EncuestaPersonalAdministrativos.Where(m => m.CapacitacionPersonalAdministrativoID == id).ToList();
                _db.EncuestaPersonalAdministrativos.RemoveRange(registroEncuesta);
            }

            _db.CapacitacionPersonalAdministrativos.Remove(capacitacion);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var capacitacion = _db.CapacitacionPersonalAdministrativos.SingleOrDefault(b => b.Id == id);


            if (capacitacion == null)
            {
                return NotFound();
            }

            return View(capacitacion);
        }
    }
}