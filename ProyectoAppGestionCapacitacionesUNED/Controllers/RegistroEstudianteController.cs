﻿using System;
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
    public class RegistroEstudianteController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;
        private List<RegistroEstudiante> registroEstudiantes;

        public RegistroEstudianteController(HostingEnvironment hostingEnvironment, ApplicationDbContext db)
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

            var Capacitaciones = from b in _db.CapacitacionEstudiantes select b;


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
                                                        
                            var FilePath = @"docs\RegistroEstudiantes\";

                            var RelativeFilePath = FilePath + Nombre + Extension;
                            var AbsFilePath = Path.Combine(rootPath, RelativeFilePath);

                            using (var fileStream = new FileStream(AbsFilePath, FileMode.Create))
                            {
                                files[0].CopyTo(fileStream);
                            }

                            registroEstudiantes = new List<RegistroEstudiante>();

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



                                            if (!reader.GetValue(2).ToString().All(char.IsDigit))
                                            {
                                                error = "Error en columna B";

                                            }

                                            if (error != "")
                                            {
                                                ModelState.AddModelError(string.Empty, error);

                                            }



                                            registroEstudiantes.Add(new RegistroEstudiante
                                            {
                                                NombreCompleto = reader.GetValue(1).ToString(),
                                                Cedula = long.Parse(reader.GetValue(2).ToString()),
                                                CorreoElectronico = reader.GetValue(3).ToString(),
                                                Telefono = reader.GetValue(4).ToString(),
                                                Genero = reader.GetValue(5).ToString(),
                                                CentroUniversitario = reader.GetValue(6).ToString(),
                                                GradoAcademico = reader.GetValue(7).ToString(),
                                                Interes = reader.GetValue(8).ToString(),
                                                Condiciones = reader.GetValue(9).ToString(),
                                                CapacitacionEstudianteFK = Id

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
                            ModelState.AddModelError(string.Empty, "Debe subir un archivo Excel con formato .xlsx o .xls");
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
                    if (_db.AsistenciaEstudiantes.Where(c => c.CapacitacionEstudianteID == Id).Any())
                    {
                        var eliminarAsistencia = _db.AsistenciaEstudiantes.Where(c => c.CapacitacionEstudianteID == Id).ToList();
                        _db.AsistenciaEstudiantes.RemoveRange();

                    }
                    if (_db.RegistroEstudiantes.Any(c => c.CapacitacionEstudianteFK == Id))
                    {
                        var eliminarRegistros = _db.RegistroEstudiantes.Where(c => c.CapacitacionEstudianteFK == Id).ToList();
                        _db.RegistroEstudiantes.RemoveRange(eliminarRegistros);

                        _db.RegistroEstudiantes.AddRange(registroEstudiantes);
                        _db.SaveChanges();

                        return RedirectToAction("ConfirmacionActualizacion", "RegistroEstudiante");
                    }
                    else
                    {
                        _db.RegistroEstudiantes.AddRange(registroEstudiantes);
                        _db.SaveChanges();

                        return RedirectToAction("Confirmacion", "RegistroEstudiante");
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

        public IActionResult InformacionRegistroEstudiante()
        {
            return View();
        }

        public IActionResult ConfirmacionActualizacion()
        {
            return View();
        }
    }
}