using ProyectoAppGestionCapacitacionesUNED.Data;
using ProyectoAppGestionCapacitacionesUNED.DbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Models
{
    public class CapacitacionEstudiante : ICodigo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite un código")]
        [UniqueValidation("El código ya existe")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Digite un nombre para la capacitación")]
        [Display(Name = "Nombre de Capacitación")]
        public string NombreCapacitacion { get; set; }

        [Required(ErrorMessage = "Digite una fecha en formato dd/mm/aaaa")]
        [Display(Name = "Fecha de la Capacitación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaCapacitacion { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Digite una duración en formato 00:00")]
        [Display(Name = "Duración")]
        public TimeSpan Duracion { get; set; }

        [Required(ErrorMessage = "Digite un lugar")]
        [Display(Name = "Lugar de la Capacitación")]
        public string Lugar { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Digite una hora en formato 00:00")]
        [Display(Name = "Hora de Inicio")]
        public TimeSpan HorarioInicio { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Digite una hora en formato 00:00")]
        [Display(Name = "Hora de Salida")]
        public TimeSpan HorarioSalida { get; set; }

        [Required(ErrorMessage = "Digite una descripción")]
        [Display(Name = "Descripción de la Capacitación")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Digite el nombre del instructor")]
        [Display(Name = "Nombre del Instructor")]
        public string NombreInstructor { get; set; }

        [Required(ErrorMessage = "Digite el nombre de la cátedra")]
        [Display(Name = "Nombre de la Cátedra")]
        public string Catedra { get; set; }
    }
}
