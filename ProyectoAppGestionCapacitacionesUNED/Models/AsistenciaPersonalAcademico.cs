using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Models
{
    public class AsistenciaPersonalAcademico
    {
        public int Id { get; set; }

        public CapacitacionPersonalAcademico CapacitacionPersonalAcademico { get; set; }

        public int CapacitacionPersonalAcademicoID { get; set; }

        public RegistroPersonalAcademico RegistroPersonalAcademico { get; set; }

        public int RegistroPersonalAcademicoID { get; set; }

        public bool Asistencia { get; set; }
    }
}
