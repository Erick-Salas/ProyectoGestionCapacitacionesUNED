using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAppGestionCapacitacionesUNED.DbContext;
using ProyectoAppGestionCapacitacionesUNED.Helpers;
using ProyectoAppGestionCapacitacionesUNED.Models;

namespace ProyectoAppGestionCapacitacionesUNED.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class AsistenciaPersonalAcademicoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AsistenciaPersonalAcademicoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Confirmacion()
        {
            return View();

        }

        public IActionResult ConfirmacionActualizacion()
        {
            return View();

        }

        public IActionResult Create()
        {
            var PersonalAcademico = Enumerable.Empty<RegistroPersonalAcademico>().AsQueryable();
            return View(PersonalAcademico);
        }

        [HttpPost]
        public IActionResult Create(string searchCodeA)
        {
            ViewBag.CurrentFilter = searchCodeA;

            var PersonalAcademico = Enumerable.Empty<RegistroPersonalAcademico>().AsQueryable();

            PersonalAcademico = from b in _db.RegistroPersonalAcademicos.Include(m => m.CapacitacionPersonalAcademico) select b;
            PersonalAcademico = PersonalAcademico.Where(m => m.CapacitacionPersonalAcademico.Codigo == searchCodeA);

            if (String.IsNullOrEmpty(searchCodeA))
            {
                return View(PersonalAcademico);
            }
            if (_db.CapacitacionPersonalAcademicos.Any(c => c.Codigo == searchCodeA))
            {
                if (PersonalAcademico.Where(m => m.CapacitacionPersonalAcademico.Codigo == searchCodeA).Any())
                {
                    return View(PersonalAcademico);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha creado registros de personal académico para este código");
                    return View(PersonalAcademico);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(PersonalAcademico);
            }

        }

        [HttpPost]
        public IActionResult Action(List<AsistenciaPersonalAcademico> AsistenciaPersonalAcademico)
        {
            if (AsistenciaPersonalAcademico.Any())
            {
                var id = AsistenciaPersonalAcademico[0].CapacitacionPersonalAcademicoID;
                if (_db.AsistenciaPersonalAcademicos.Any(c => c.CapacitacionPersonalAcademicoID == id))
                {
                    var eliminarRegistros = _db.AsistenciaPersonalAcademicos.Where(c => c.CapacitacionPersonalAcademicoID == id).ToList();
                    _db.AsistenciaPersonalAcademicos.RemoveRange(eliminarRegistros);

                    _db.AsistenciaPersonalAcademicos.AddRange(AsistenciaPersonalAcademico);
                    _db.SaveChanges();
                    return Json(new { newUrl = Url.Action("ConfirmacionActualizacion", "AsistenciaPersonalAcademico") });
                }
                else
                {
                    _db.AsistenciaPersonalAcademicos.AddRange(AsistenciaPersonalAcademico);
                    _db.SaveChanges();
                    return Json(new { newUrl = Url.Action("Confirmacion", "AsistenciaPersonalAcademico") });
                }

            }

            return Json(new { newUrl = Url.Action("Create", "AsistenciaPersonalAcademico") });
        }
    }
}