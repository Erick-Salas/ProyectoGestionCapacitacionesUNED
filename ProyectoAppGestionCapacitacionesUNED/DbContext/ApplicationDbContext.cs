using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoAppGestionCapacitacionesUNED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<CapacitacionEstudiante> CapacitacionEstudiantes { get; set; }
        public DbSet<RegistroEstudiante> RegistroEstudiantes { get; set; }
        public DbSet<AsistenciaEstudiante> AsistenciaEstudiantes { get; set; }
        public DbSet<EncuestaEstudiante> EncuestaEstudiantes { get; set; }

        public DbSet<CapacitacionPersonalAcademico> CapacitacionPersonalAcademicos { get; set; }
        public DbSet<RegistroPersonalAcademico> RegistroPersonalAcademicos { get; set; }
        public DbSet<AsistenciaPersonalAcademico> AsistenciaPersonalAcademicos { get; set; }
        public DbSet<EncuestaPersonalAcademico> EncuestaPersonalAcademicos { get; set; }

        public DbSet<CapacitacionPersonalAdministrativo> CapacitacionPersonalAdministrativos { get; set; }
        public DbSet<RegistroPersonalAdministrativo> RegistroPersonalAdministrativos { get; set; }
        public DbSet<AsistenciaPersonalAdministrativo> AsistenciaPersonalAdministrativos { get; set; }
        public DbSet<EncuestaPersonalAdministrativo> EncuestaPersonalAdministrativos { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
