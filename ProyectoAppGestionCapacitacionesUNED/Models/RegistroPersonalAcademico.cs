﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Models
{
    public class RegistroPersonalAcademico
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; }

        public long Cedula { get; set; }

        public string CorreoElectronico { get; set; }

        public string Telefono { get; set; }

        public string Genero { get; set; }

        public string Dependencia { get; set; }

        public string GradoAcademico { get; set; }

        public string Interes { get; set; }

        public string Condiciones { get; set; }

        public CapacitacionPersonalAcademico CapacitacionPersonalAcademico { get; set; }



        public int CapacitacionPersonalAcademicoID { get; set; }
    }
}
