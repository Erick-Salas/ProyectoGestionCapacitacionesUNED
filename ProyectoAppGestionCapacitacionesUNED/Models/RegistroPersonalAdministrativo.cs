using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Models
{
    public class RegistroPersonalAdministrativo
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

        public CapacitacionPersonalAdministrativo CapacitacionPersonalAdministrativo { get; set; }



        public int CapacitacionPersonalAdministrativoID { get; set; }
    }
}
