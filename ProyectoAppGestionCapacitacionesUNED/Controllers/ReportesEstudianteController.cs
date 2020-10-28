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
using Rotativa.AspNetCore;

namespace ProyectoAppGestionCapacitacionesUNED.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class ReportesEstudianteController : Controller
    {
        private readonly ApplicationDbContext _db;


        public ReportesEstudianteController(ApplicationDbContext db)
        {
            _db = db;

        }


        public IActionResult ReporteAsistencia()
        {
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable();
            return View(reportenull);
        }


        [HttpPost]
        public IActionResult ReporteAsistencia(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;

            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();


                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }

        }


        public IActionResult ReporteAsistenciaEstudiantePartial(string searchCode)
        {
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }

        }


        public IActionResult ReporteAsistenciaEstudiante(string searchCode)
        {
            var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
            var id = cod.Id;
            var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

            return new ViewAsPdf("ReporteAsistenciaEstudiantePartial", reporte)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4

            };
        }

        public IActionResult ReporteGenero()
        {
            var reporte = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            return View(reporte);
        }

        [HttpPost]
        public IActionResult ReporteGenero(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }

        }

        public IActionResult ReporteGeneroEstudiantePartial(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }

        }

        public IActionResult ReporteGeneroEstudiante(string searchCode)
        {
            var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
            var id = cod.Id;
            var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

            return new ViewAsPdf("ReporteGeneroEstudiantePartial", reporte)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4

            };
        }

        public IActionResult ReporteCentroUniversitario()
        {
            var reporte = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            return View(reporte);
        }

        [HttpPost]
        public IActionResult ReporteCentroUniversitario(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }
        }

        public IActionResult ReporteCentroUniversitarioEstudiantePartial(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }

        }

        public IActionResult ReporteCentroUniversitarioEstudiante(string searchCode)
        {
            var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
            var id = cod.Id;
            var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

            return new ViewAsPdf("ReporteCentroUniversitarioEstudiantePartial", reporte)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4

            };
        }


        public IActionResult ReporteGradoAcademico()
        {
            var reporte = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            return View(reporte);
        }

        [HttpPost]
        public IActionResult ReporteGradoAcademico(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }
        }

        public IActionResult ReporteGradoAcademicoEstudiantePartial(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }

        }

        public IActionResult ReporteGradoAcademicoEstudiante(string searchCode)
        {
            var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
            var id = cod.Id;
            var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

            return new ViewAsPdf("ReporteGradoAcademicoEstudiantePartial", reporte)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4

            };
        }

        public IActionResult ReporteGradoSatisfaccion()
        {
            var reporte = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable();
            return View();
        }

        [HttpPost]
        public IActionResult ReporteGradoSatisfaccion(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    if (_db.EncuestaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                    {


                        var reporte = _db.AsistenciaEstudiantes.Include(m => m.CapacitacionEstudiante).Include(m => m.RegistroEstudiante).Where(m => m.CapacitacionEstudianteID == id).Where(m => m.Asistencia == true).ToList();

                        var nombre = reporte.First().CapacitacionEstudiante.NombreCapacitacion;
                        var codigo = reporte.First().CapacitacionEstudiante.Codigo;
                        var instructor = reporte.First().CapacitacionEstudiante.NombreInstructor;
                        var fecha = reporte.First().CapacitacionEstudiante.FechaCapacitacion;


                        ViewBag.Nombre = nombre;
                        ViewBag.Codigo = codigo;
                        ViewBag.Instructor = instructor;
                        ViewBag.Fecha = fecha.ToShortDateString();

                        var uno = 1;
                        var dos = 2;
                        var tres = 3;
                        var cuatro = 4;
                        var cinco = 5;

                        var p1n1 = 0;
                        var p1n2 = 0;
                        var p1n3 = 0;
                        var p1n4 = 0;
                        var p1n5 = 0;

                        var p2n1 = 0;
                        var p2n2 = 0;
                        var p2n3 = 0;
                        var p2n4 = 0;
                        var p2n5 = 0;

                        var p3n1 = 0;
                        var p3n2 = 0;
                        var p3n3 = 0;
                        var p3n4 = 0;
                        var p3n5 = 0;

                        var p4n1 = 0;
                        var p4n2 = 0;
                        var p4n3 = 0;
                        var p4n4 = 0;
                        var p4n5 = 0;

                        var p5n1 = 0;
                        var p5n2 = 0;
                        var p5n3 = 0;
                        var p5n4 = 0;
                        var p5n5 = 0;

                        var p6n1 = 0;
                        var p6n2 = 0;
                        var p6n3 = 0;
                        var p6n4 = 0;
                        var p6n5 = 0;

                        var p7n1 = 0;
                        var p7n2 = 0;
                        var p7n3 = 0;
                        var p7n4 = 0;
                        var p7n5 = 0;

                        var p8n1 = 0;
                        var p8n2 = 0;
                        var p8n3 = 0;
                        var p8n4 = 0;
                        var p8n5 = 0;

                        if (_db.EncuestaEstudiantes.Any(m => m.CapacitacionEstudianteID == id))
                        {
                            try
                            {
                                var encuesta = _db.EncuestaEstudiantes.Where(c => c.CapacitacionEstudianteID == id).ToList();
                                for (int i = 0; i < encuesta.Count; i++)
                                {
                                    if (encuesta[i].Pregunta1 == uno)
                                    {
                                        p1n1 = p1n1 + 1;
                                    }
                                    if (encuesta[i].Pregunta1 == dos)
                                    {
                                        p1n2 = p1n2 + 1;
                                    }
                                    if (encuesta[i].Pregunta1 == tres)
                                    {
                                        p1n3 = p1n3 + 1;
                                    }
                                    if (encuesta[i].Pregunta1 == cuatro)
                                    {
                                        p1n4 = p1n4 + 1;
                                    }
                                    if (encuesta[i].Pregunta1 == cinco)
                                    {
                                        p1n5 = p1n5 + 1;
                                    }


                                    if (encuesta[i].Pregunta2 == uno)
                                    {
                                        p2n1 = p2n1 + 1;
                                    }
                                    if (encuesta[i].Pregunta2 == dos)
                                    {
                                        p2n2 = p2n2 + 1;
                                    }
                                    if (encuesta[i].Pregunta2 == tres)
                                    {
                                        p2n3 = p2n3 + 1;
                                    }
                                    if (encuesta[i].Pregunta2 == cuatro)
                                    {
                                        p2n4 = p2n4 + 1;
                                    }
                                    if (encuesta[i].Pregunta2 == cinco)
                                    {
                                        p2n5 = p2n5 + 1;
                                    }


                                    if (encuesta[i].Pregunta3 == uno)
                                    {
                                        p3n1 = p3n1 + 1;
                                    }
                                    if (encuesta[i].Pregunta3 == dos)
                                    {
                                        p3n2 = p3n2 + 1;
                                    }
                                    if (encuesta[i].Pregunta3 == tres)
                                    {
                                        p3n3 = p3n3 + 1;
                                    }
                                    if (encuesta[i].Pregunta3 == cuatro)
                                    {
                                        p3n4 = p3n4 + 1;
                                    }
                                    if (encuesta[i].Pregunta3 == cinco)
                                    {
                                        p3n5 = p3n5 + 1;
                                    }


                                    if (encuesta[i].Pregunta4 == uno)
                                    {
                                        p4n1 = p4n1 + 1;
                                    }
                                    if (encuesta[i].Pregunta4 == dos)
                                    {
                                        p4n2 = p4n2 + 1;
                                    }
                                    if (encuesta[i].Pregunta4 == tres)
                                    {
                                        p4n3 = p4n3 + 1;
                                    }
                                    if (encuesta[i].Pregunta4 == cuatro)
                                    {
                                        p4n4 = p4n4 + 1;
                                    }
                                    if (encuesta[i].Pregunta4 == cinco)
                                    {
                                        p4n5 = p4n5 + 1;
                                    }


                                    if (encuesta[i].Pregunta5 == uno)
                                    {
                                        p5n1++;
                                    }
                                    if (encuesta[i].Pregunta5 == dos)
                                    {
                                        p5n2++;
                                    }
                                    if (encuesta[i].Pregunta5 == tres)
                                    {
                                        p5n3++;
                                    }
                                    if (encuesta[i].Pregunta5 == cuatro)
                                    {
                                        p5n4++;
                                    }
                                    if (encuesta[i].Pregunta5 == cinco)
                                    {
                                        p5n5++;
                                    }


                                    if (encuesta[i].Pregunta6 == uno)
                                    {
                                        p6n1++;
                                    }
                                    if (encuesta[i].Pregunta6 == dos)
                                    {
                                        p6n2++;
                                    }
                                    if (encuesta[i].Pregunta6 == tres)
                                    {
                                        p6n3++;
                                    }
                                    if (encuesta[i].Pregunta6 == cuatro)
                                    {
                                        p6n4++;
                                    }
                                    if (encuesta[i].Pregunta6 == cinco)
                                    {
                                        p6n5++;
                                    }


                                    if (encuesta[i].Pregunta7 == uno)
                                    {
                                        p7n1++;
                                    }
                                    if (encuesta[i].Pregunta7 == dos)
                                    {
                                        p7n2++;
                                    }
                                    if (encuesta[i].Pregunta7 == tres)
                                    {
                                        p7n3++;
                                    }
                                    if (encuesta[i].Pregunta7 == cuatro)
                                    {
                                        p7n4++;
                                    }
                                    if (encuesta[i].Pregunta7 == cinco)
                                    {
                                        p7n5++;
                                    }


                                    if (encuesta[i].Pregunta8 == uno)
                                    {
                                        p8n1++;
                                    }
                                    if (encuesta[i].Pregunta8 == dos)
                                    {
                                        p8n2++;
                                    }
                                    if (encuesta[i].Pregunta8 == tres)
                                    {
                                        p8n3++;
                                    }
                                    if (encuesta[i].Pregunta8 == cuatro)
                                    {
                                        p8n4++;
                                    }
                                    if (encuesta[i].Pregunta8 == cinco)
                                    {
                                        p8n5++;
                                    }

                                }

                                int[] p1 = { p1n1, p1n2, p1n3, p1n4, p1n5 };
                                var maxp1 = p1.Max();
                                var maxindex1 = p1.ToList().IndexOf(maxp1);
                                var nummayor1 = 0;

                                switch (maxindex1)
                                {
                                    case 0:
                                        nummayor1 = 1;
                                        break;
                                    case 1:
                                        nummayor1 = 2;
                                        break;
                                    case 2:
                                        nummayor1 = 3;
                                        break;
                                    case 3:
                                        nummayor1 = 4;
                                        break;
                                    case 4:
                                        nummayor1 = 5;
                                        break;

                                }

                                int[] p2 = { p2n1, p2n2, p2n3, p2n4, p2n5 };

                                var maxp2 = p2.Max();
                                var maxindex2 = p2.ToList().IndexOf(maxp2);
                                var nummayor2 = 0;

                                switch (maxindex2)
                                {
                                    case 0:
                                        nummayor2 = 1;
                                        break;
                                    case 1:
                                        nummayor2 = 2;
                                        break;
                                    case 2:
                                        nummayor2 = 3;
                                        break;
                                    case 3:
                                        nummayor2 = 4;
                                        break;
                                    case 4:
                                        nummayor2 = 5;
                                        break;

                                }

                                int[] p3 = { p3n1, p3n2, p3n3, p3n4, p3n5 };

                                var maxp3 = p3.Max();
                                var maxindex3 = p3.ToList().IndexOf(maxp3);
                                var nummayor3 = 0;

                                switch (maxindex3)
                                {
                                    case 0:
                                        nummayor3 = 1;
                                        break;
                                    case 1:
                                        nummayor3 = 2;
                                        break;
                                    case 2:
                                        nummayor3 = 3;
                                        break;
                                    case 3:
                                        nummayor3 = 4;
                                        break;
                                    case 4:
                                        nummayor3 = 5;
                                        break;

                                }




                                int[] p4 = { p4n1, p4n2, p4n3, p4n4, p4n5 };

                                var maxp4 = p4.Max();
                                var maxindex4 = p4.ToList().IndexOf(maxp4);
                                var nummayor4 = 0;

                                switch (maxindex4)
                                {
                                    case 0:
                                        nummayor4 = 1;
                                        break;
                                    case 1:
                                        nummayor4 = 2;
                                        break;
                                    case 2:
                                        nummayor4 = 3;
                                        break;
                                    case 3:
                                        nummayor4 = 4;
                                        break;
                                    case 4:
                                        nummayor4 = 5;
                                        break;

                                }



                                int[] p5 = { p5n1, p5n2, p5n3, p5n4, p5n5 };

                                var maxp5 = p5.Max();
                                var maxindex5 = p5.ToList().IndexOf(maxp5);
                                var nummayor5 = 0;

                                switch (maxindex5)
                                {
                                    case 0:
                                        nummayor5 = 1;
                                        break;
                                    case 1:
                                        nummayor5 = 2;
                                        break;
                                    case 2:
                                        nummayor5 = 3;
                                        break;
                                    case 3:
                                        nummayor5 = 4;
                                        break;
                                    case 4:
                                        nummayor5 = 5;
                                        break;

                                }


                                int[] p6 = { p6n1, p6n2, p6n3, p6n4, p6n5 };

                                var maxp6 = p6.Max();
                                var maxindex6 = p6.ToList().IndexOf(maxp6);
                                var nummayor6 = 0;

                                switch (maxindex6)
                                {
                                    case 0:
                                        nummayor6 = 1;
                                        break;
                                    case 1:
                                        nummayor6 = 2;
                                        break;
                                    case 2:
                                        nummayor6 = 3;
                                        break;
                                    case 3:
                                        nummayor6 = 4;
                                        break;
                                    case 4:
                                        nummayor6 = 5;
                                        break;

                                }



                                int[] p7 = { p7n1, p7n2, p7n3, p7n4, p7n5 };

                                var maxp7 = p7.Max();
                                var maxindex7 = p7.ToList().IndexOf(maxp7);
                                var nummayor7 = 0;

                                switch (maxindex7)
                                {
                                    case 0:
                                        nummayor7 = 1;
                                        break;
                                    case 1:
                                        nummayor7 = 2;
                                        break;
                                    case 2:
                                        nummayor7 = 3;
                                        break;
                                    case 3:
                                        nummayor7 = 4;
                                        break;
                                    case 4:
                                        nummayor7 = 5;
                                        break;

                                }




                                int[] p8 = { p8n1, p8n2, p8n3, p8n4, p8n5 };

                                var maxp8 = p8.Max();
                                var maxindex8 = p8.ToList().IndexOf(maxp8);
                                var nummayor8 = 0;

                                switch (maxindex8)
                                {
                                    case 0:
                                        nummayor8 = 1;
                                        break;
                                    case 1:
                                        nummayor8 = 2;
                                        break;
                                    case 2:
                                        nummayor8 = 3;
                                        break;
                                    case 3:
                                        nummayor8 = 4;
                                        break;
                                    case 4:
                                        nummayor8 = 5;
                                        break;

                                }

                                double promedio = ((double)(nummayor1 + nummayor2 + nummayor3 + nummayor4 + nummayor5 + nummayor6 + nummayor7 + nummayor8) / (double)8);
                                promedio = Math.Round(promedio, 1);
                                ViewBag.Promedio = promedio.ToString();


                                return View();
                            }
                            catch (Exception)
                            {
                                ModelState.AddModelError(string.Empty, "Error al procesar datos");
                                return View();
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "No se ha encontrado una encuesta relacionada con el código de la capacitación");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "No se ha encontrado una encuesta relacionada con el código de la capacitación");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View();
            }
        }

        public IActionResult ReporteGradoSatisfaccionEstudiantePartial(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<AsistenciaEstudiante>().AsQueryable().ToList();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.AsistenciaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    if (_db.EncuestaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                    {
                        var reporte = _db.EncuestaEstudiantes.Include(m => m.CapacitacionEstudiante).Where(m => m.CapacitacionEstudianteID == id).ToList();

                        return View(reporte);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "No se ha definido la encuesta para la capacitación con este código");
                        return View(reportenull);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la asistencia para la capacitación con este código");
                    return View(reportenull);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }

        }

        public IActionResult ReporteGradoSatisfaccionEstudiante(string searchCode)
        {
            var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
            var id = cod.Id;
            var reporte = _db.EncuestaEstudiantes.Include(m => m.CapacitacionEstudiante).Where(m => m.CapacitacionEstudianteID == id).ToList();

            return new ViewAsPdf("ReporteGradoSatisfaccionEstudiantePartial", reporte)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4

            };
        }


        public IActionResult ReporteSugerencias()
        {
            var reporte = Enumerable.Empty<EncuestaEstudiante>().AsQueryable();
            return View(reporte);
        }

        [HttpPost]
        public IActionResult ReporteSugerencias(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<EncuestaEstudiante>().AsQueryable();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.EncuestaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.EncuestaEstudiantes.Where(m => m.CapacitacionEstudianteID == id).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la encuesta para la capacitación con este código");
                    return View(reportenull);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }
        }

        public IActionResult ReporteSugerenciasEstudiantePartial(string searchCode)
        {
            ViewBag.CurrentFilter = searchCode;
            var reportenull = Enumerable.Empty<EncuestaEstudiante>().AsQueryable();
            if (_db.CapacitacionEstudiantes.Any(c => c.Codigo == searchCode))
            {
                var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
                var id = cod.Id;
                if (_db.EncuestaEstudiantes.Any(c => c.CapacitacionEstudianteID == id))
                {
                    var reporte = _db.EncuestaEstudiantes.Where(m => m.CapacitacionEstudianteID == id).ToList();

                    return View(reporte);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No se ha definido la encuesta para la capacitación con este código");
                    return View(reportenull);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Código no encontrado");
                return View(reportenull);
            }

        }

        public IActionResult ReporteSugerenciasEstudiante(string searchCode)
        {
            var cod = _db.CapacitacionEstudiantes.SingleOrDefault(c => c.Codigo == searchCode);
            var id = cod.Id;
            var reporte = _db.EncuestaEstudiantes.Include(m => m.CapacitacionEstudiante).Where(m => m.CapacitacionEstudianteID == id).ToList();

            return new ViewAsPdf("ReporteSugerenciasEstudiantePartial", reporte)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4

            };
        }
    }
}