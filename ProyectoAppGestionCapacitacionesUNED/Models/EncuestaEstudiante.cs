using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Models
{
    public class EncuestaEstudiante
    {
        public int Id { get; set; }
        public int Pregunta1 { get; set; }
        public int Pregunta2 { get; set; }
        public int Pregunta3 { get; set; }
        public int Pregunta4 { get; set; }
        public int Pregunta5 { get; set; }
        public int Pregunta6 { get; set; }
        public int Pregunta7 { get; set; }
        public int Pregunta8 { get; set; }
        public string Pregunta9 { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Pregunta10 { get; set; }
        public CapacitacionEstudiante CapacitacionEstudiante { get; set; }
        public int CapacitacionEstudianteID { get; set; }
    }
}
