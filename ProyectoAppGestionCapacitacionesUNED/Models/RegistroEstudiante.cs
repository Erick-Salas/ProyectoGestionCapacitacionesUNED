using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Models
{
    public class RegistroEstudiante
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; }

        public long Cedula { get; set; }

        public string CorreoElectronico { get; set; }

        public string Telefono { get; set; }

        public string Genero { get; set; }

        public string CentroUniversitario { get; set; }

        public string GradoAcademico { get; set; }

        public string Interes { get; set; }

        public string Condiciones { get; set; }

        public CapacitacionEstudiante CapacitacionEstudiante { get; set; }


        [ForeignKey("CapacitacionEstudiante")]
        public int CapacitacionEstudianteFK { get; set; }
    }
}
