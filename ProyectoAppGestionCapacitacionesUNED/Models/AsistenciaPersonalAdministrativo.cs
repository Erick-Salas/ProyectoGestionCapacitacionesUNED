using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Models
{
    public class AsistenciaPersonalAdministrativo
    {
        public int Id { get; set; }

        public CapacitacionPersonalAdministrativo CapacitacionPersonalAdministrativo { get; set; }

        public int CapacitacionPersonalAdministrativoID { get; set; }

        public RegistroPersonalAdministrativo RegistroPersonalAdministrativo { get; set; }

        public int RegistroPersonalAdministrativoID { get; set; }

        public bool Asistencia { get; set; }
    }
}
