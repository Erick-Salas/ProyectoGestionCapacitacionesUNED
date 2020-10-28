using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using ProyectoAppGestionCapacitacionesUNED.DbContext;
using ProyectoAppGestionCapacitacionesUNED.Helpers;
using ProyectoAppGestionCapacitacionesUNED.Models;

namespace ProyectoAppGestionCapacitacionesUNED.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Executive)]
    public class EncuestaPersonalAcademicoController : Controller
    {
        private readonly HostingEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _db;
        private List<EncuestaPersonalAcademico> encuestaPersonalAcademicos;

        public EncuestaPersonalAcademicoController(HostingEnvironment hostingEnvironment, ApplicationDbContext db)
        {
            _hostingEnvironment = hostingEnvironment;
            _db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreateGet(string searchCodeE)
        {
            ViewBag.CurrentFilter = searchCodeE;

            var Capacitaciones = from b in _db.CapacitacionPersonalAcademicos select b;


            if (!String.IsNullOrEmpty(searchCodeE))
            {
                if (Capacitaciones.SingleOrDefault(c => c.Codigo == searchCodeE) != null)
                {
                    var Identificador = Capacitaciones.SingleOrDefault(c => c.Codigo == searchCodeE);
                    var Id = Identificador.Id;


                    string rootPath = _hostingEnvironment.WebRootPath;



                    var Fecha = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    var Nombre = Fecha;

                    var files = HttpContext.Request.Form.Files;


                    if (files.Count != 0)
                    {
                        var Extension = Path.GetExtension(files[0].FileName);

                        if (Extension == ".xls" || Extension == ".xlsx")
                        {


                            var FilePath = @"docs\EncuestaPersonalAcademicos\";

                            var RelativeFilePath = FilePath + Nombre + Extension;
                            var AbsFilePath = Path.Combine(rootPath, RelativeFilePath);

                            using (var fileStream = new FileStream(AbsFilePath, FileMode.Create))
                            {
                                files[0].CopyTo(fileStream);
                            }

                            encuestaPersonalAcademicos = new List<EncuestaPersonalAcademico>();

                            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                            using (var stream = System.IO.File.Open(AbsFilePath, FileMode.Open, FileAccess.Read))
                            {
                                using (var reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration() { FallbackEncoding = Encoding.GetEncoding(1252) }))
                                {


                                    string error = "";
                                    try
                                    {
                                        reader.Read(); //skip first row
                                        while (reader.Read())
                                        {



                                            if (!reader.GetValue(9).ToString().Take(1).All(char.IsDigit))
                                            {
                                                error = "Error en columna J";

                                            }
                                            if (!reader.GetValue(10).ToString().Take(1).All(char.IsDigit))
                                            {
                                                error = "Error en columna K";

                                            }
                                            if (!reader.GetValue(11).ToString().Take(1).All(char.IsDigit))
                                            {
                                                error = "Error en columna L";

                                            }
                                            if (!reader.GetValue(12).ToString().Take(1).All(char.IsDigit))
                                            {
                                                error = "Error en columna M";

                                            }
                                            if (!reader.GetValue(13).ToString().Take(1).All(char.IsDigit))
                                            {
                                                error = "Error en columna N";

                                            }
                                            if (!reader.GetValue(14).ToString().Take(1).All(char.IsDigit))
                                            {
                                                error = "Error en columna O";

                                            }
                                            if (!reader.GetValue(15).ToString().Take(1).All(char.IsDigit))
                                            {
                                                error = "Error en columna P";

                                            }
                                            if (!reader.GetValue(16).ToString().Take(1).All(char.IsDigit))
                                            {
                                                error = "Error en columna Q";

                                            }

                                            if (error != "")
                                            {
                                                ModelState.AddModelError(string.Empty, error);

                                            }

                                            object pregunta10 = reader.GetValue(18);
                                            if (pregunta10 == null)
                                            {
                                                pregunta10 = "";
                                            }

                                            encuestaPersonalAcademicos.Add(new EncuestaPersonalAcademico
                                            {
                                                Pregunta1 = int.Parse(reader.GetValue(9).ToString().Substring(0, 1)),
                                                Pregunta2 = int.Parse(reader.GetValue(10).ToString().Substring(0, 1)),
                                                Pregunta3 = int.Parse(reader.GetValue(11).ToString().Substring(0, 1)),
                                                Pregunta4 = int.Parse(reader.GetValue(12).ToString().Substring(0, 1)),
                                                Pregunta5 = int.Parse(reader.GetValue(13).ToString().Substring(0, 1)),
                                                Pregunta6 = int.Parse(reader.GetValue(14).ToString().Substring(0, 1)),
                                                Pregunta7 = int.Parse(reader.GetValue(15).ToString().Substring(0, 1)),
                                                Pregunta8 = int.Parse(reader.GetValue(16).ToString().Substring(0, 1)),
                                                Pregunta9 = reader.GetValue(17).ToString(),
                                                Pregunta10 = pregunta10.ToString(),
                                                CapacitacionPersonalAcademicoID = Id
                                            });



                                        }


                                    }
                                    catch (Exception)
                                    {
                                        ModelState.AddModelError(string.Empty, "Error con el formato del documento Excel");
                                        ModelState.AddModelError(string.Empty, "Ver indicaciones en el botón de información");

                                    }

                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Debe subir un archivo Excel en formato .xlsx o .xls");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Debe seleccionar un archivo");
                        return View();
                    }

                    if (!ModelState.IsValid)
                    {
                        return View();
                    }

                    if (_db.EncuestaPersonalAcademicos.Any(c => c.CapacitacionPersonalAcademicoID == Id))
                    {
                        var eliminarRegistros = _db.EncuestaPersonalAcademicos.Where(c => c.CapacitacionPersonalAcademicoID == Id).ToList();
                        _db.EncuestaPersonalAcademicos.RemoveRange(eliminarRegistros);

                        _db.EncuestaPersonalAcademicos.AddRange(encuestaPersonalAcademicos);
                        _db.SaveChanges();

                        return RedirectToAction("ConfirmacionActualizacion", "EncuestaPersonalAcademico");
                    }
                    else
                    {
                        _db.EncuestaPersonalAcademicos.AddRange(encuestaPersonalAcademicos);
                        _db.SaveChanges();

                        return RedirectToAction("Confirmacion", "EncuestaPersonalAcademico");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "El código no existe");
                    return View();
                }



            }
            else
            {
                ModelState.AddModelError(string.Empty, "Debe digitar un código");
                return View();
            }

        }

        public IActionResult Confirmacion()
        {
            return View();
        }

        public IActionResult InformacionEncuestaPersonalAcademico()
        {
            return View();
        }

        public IActionResult ConfirmacionActualizacion()
        {
            return View();
        }
    }
}