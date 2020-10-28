using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Models
{
    public class AsistenciaEstudiante
    {
        public int Id { get; set; }

        public CapacitacionEstudiante CapacitacionEstudiante { get; set; }

        public int CapacitacionEstudianteID { get; set; }

        public RegistroEstudiante RegistroEstudiante { get; set; }

        public int RegistroEstudianteID { get; set; }

        public bool Asistencia { get; set; }
    }
}
