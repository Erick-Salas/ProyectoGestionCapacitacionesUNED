﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoAppGestionCapacitacionesUNED.DbContext;

namespace ProyectoAppGestionCapacitacionesUNED.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200229220718_AddModel")]
    partial class AddModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.AsistenciaEstudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Asistencia");

                    b.Property<int>("CapacitacionEstudianteID");

                    b.Property<int>("RegistroEstudianteID");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionEstudianteID");

                    b.HasIndex("RegistroEstudianteID");

                    b.ToTable("AsistenciaEstudiantes");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.AsistenciaPersonalAcademico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Asistencia");

                    b.Property<int>("CapacitacionPersonalAcademicoID");

                    b.Property<int>("RegistroPersonalAcademicoID");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionPersonalAcademicoID");

                    b.HasIndex("RegistroPersonalAcademicoID");

                    b.ToTable("AsistenciaPersonalAcademicos");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.AsistenciaPersonalAdministrativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Asistencia");

                    b.Property<int>("CapacitacionPersonalAdministrativoID");

                    b.Property<int>("RegistroPersonalAdministrativoID");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionPersonalAdministrativoID");

                    b.HasIndex("RegistroPersonalAdministrativoID");

                    b.ToTable("AsistenciaPersonalAdministrativos");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionEstudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Catedra")
                        .IsRequired();

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<TimeSpan>("Duracion");

                    b.Property<DateTime>("FechaCapacitacion");

                    b.Property<TimeSpan>("HorarioInicio");

                    b.Property<TimeSpan>("HorarioSalida");

                    b.Property<string>("Lugar")
                        .IsRequired();

                    b.Property<string>("NombreCapacitacion")
                        .IsRequired();

                    b.Property<string>("NombreInstructor")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CapacitacionEstudiantes");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionPersonalAcademico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Dependencia")
                        .IsRequired();

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<TimeSpan>("Duracion");

                    b.Property<DateTime>("FechaCapacitacion");

                    b.Property<TimeSpan>("HorarioInicio");

                    b.Property<TimeSpan>("HorarioSalida");

                    b.Property<string>("Lugar")
                        .IsRequired();

                    b.Property<string>("NombreCapacitacion")
                        .IsRequired();

                    b.Property<string>("NombreInstructor")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CapacitacionPersonalAcademicos");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionPersonalAdministrativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Dependencia")
                        .IsRequired();

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<TimeSpan>("Duracion");

                    b.Property<DateTime>("FechaCapacitacion");

                    b.Property<TimeSpan>("HorarioInicio");

                    b.Property<TimeSpan>("HorarioSalida");

                    b.Property<string>("Lugar")
                        .IsRequired();

                    b.Property<string>("NombreCapacitacion")
                        .IsRequired();

                    b.Property<string>("NombreInstructor")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CapacitacionPersonalAdministrativos");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.EncuestaEstudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacitacionEstudianteID");

                    b.Property<int>("Pregunta1");

                    b.Property<string>("Pregunta10")
                        .IsRequired();

                    b.Property<int>("Pregunta2");

                    b.Property<int>("Pregunta3");

                    b.Property<int>("Pregunta4");

                    b.Property<int>("Pregunta5");

                    b.Property<int>("Pregunta6");

                    b.Property<int>("Pregunta7");

                    b.Property<int>("Pregunta8");

                    b.Property<string>("Pregunta9");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionEstudianteID");

                    b.ToTable("EncuestaEstudiantes");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.EncuestaPersonalAcademico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacitacionPersonalAcademicoID");

                    b.Property<int>("Pregunta1");

                    b.Property<string>("Pregunta10")
                        .IsRequired();

                    b.Property<int>("Pregunta2");

                    b.Property<int>("Pregunta3");

                    b.Property<int>("Pregunta4");

                    b.Property<int>("Pregunta5");

                    b.Property<int>("Pregunta6");

                    b.Property<int>("Pregunta7");

                    b.Property<int>("Pregunta8");

                    b.Property<string>("Pregunta9");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionPersonalAcademicoID");

                    b.ToTable("EncuestaPersonalAcademicos");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.EncuestaPersonalAdministrativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacitacionPersonalAdministrativoID");

                    b.Property<int>("Pregunta1");

                    b.Property<string>("Pregunta10")
                        .IsRequired();

                    b.Property<int>("Pregunta2");

                    b.Property<int>("Pregunta3");

                    b.Property<int>("Pregunta4");

                    b.Property<int>("Pregunta5");

                    b.Property<int>("Pregunta6");

                    b.Property<int>("Pregunta7");

                    b.Property<int>("Pregunta8");

                    b.Property<string>("Pregunta9");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionPersonalAdministrativoID");

                    b.ToTable("EncuestaPersonalAdministrativos");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.RegistroEstudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacitacionEstudianteFK");

                    b.Property<long>("Cedula");

                    b.Property<string>("CentroUniversitario");

                    b.Property<string>("Condiciones");

                    b.Property<string>("CorreoElectronico");

                    b.Property<string>("Genero");

                    b.Property<string>("GradoAcademico");

                    b.Property<string>("Interes");

                    b.Property<string>("NombreCompleto");

                    b.Property<string>("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionEstudianteFK");

                    b.ToTable("RegistroEstudiantes");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.RegistroPersonalAcademico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacitacionPersonalAcademicoID");

                    b.Property<long>("Cedula");

                    b.Property<string>("Condiciones");

                    b.Property<string>("CorreoElectronico");

                    b.Property<string>("Dependencia");

                    b.Property<string>("Genero");

                    b.Property<string>("GradoAcademico");

                    b.Property<string>("Interes");

                    b.Property<string>("NombreCompleto");

                    b.Property<string>("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionPersonalAcademicoID");

                    b.ToTable("RegistroPersonalAcademicos");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.RegistroPersonalAdministrativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CapacitacionPersonalAdministrativoID");

                    b.Property<long>("Cedula");

                    b.Property<string>("Condiciones");

                    b.Property<string>("CorreoElectronico");

                    b.Property<string>("Dependencia");

                    b.Property<string>("Genero");

                    b.Property<string>("GradoAcademico");

                    b.Property<string>("Interes");

                    b.Property<string>("NombreCompleto");

                    b.Property<string>("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("CapacitacionPersonalAdministrativoID");

                    b.ToTable("RegistroPersonalAdministrativos");
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("PhoneNumber2");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.AsistenciaEstudiante", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionEstudiante", "CapacitacionEstudiante")
                        .WithMany()
                        .HasForeignKey("CapacitacionEstudianteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.RegistroEstudiante", "RegistroEstudiante")
                        .WithMany()
                        .HasForeignKey("RegistroEstudianteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.AsistenciaPersonalAcademico", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionPersonalAcademico", "CapacitacionPersonalAcademico")
                        .WithMany()
                        .HasForeignKey("CapacitacionPersonalAcademicoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.RegistroPersonalAcademico", "RegistroPersonalAcademico")
                        .WithMany()
                        .HasForeignKey("RegistroPersonalAcademicoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.AsistenciaPersonalAdministrativo", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionPersonalAdministrativo", "CapacitacionPersonalAdministrativo")
                        .WithMany()
                        .HasForeignKey("CapacitacionPersonalAdministrativoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.RegistroPersonalAdministrativo", "RegistroPersonalAdministrativo")
                        .WithMany()
                        .HasForeignKey("RegistroPersonalAdministrativoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.EncuestaEstudiante", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionEstudiante", "CapacitacionEstudiante")
                        .WithMany()
                        .HasForeignKey("CapacitacionEstudianteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.EncuestaPersonalAcademico", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionPersonalAcademico", "CapacitacionPersonalAcademico")
                        .WithMany()
                        .HasForeignKey("CapacitacionPersonalAcademicoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.EncuestaPersonalAdministrativo", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionPersonalAdministrativo", "CapacitacionPersonalAdministrativo")
                        .WithMany()
                        .HasForeignKey("CapacitacionPersonalAdministrativoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.RegistroEstudiante", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionEstudiante", "CapacitacionEstudiante")
                        .WithMany()
                        .HasForeignKey("CapacitacionEstudianteFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.RegistroPersonalAcademico", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionPersonalAcademico", "CapacitacionPersonalAcademico")
                        .WithMany()
                        .HasForeignKey("CapacitacionPersonalAcademicoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProyectoAppGestionCapacitacionesUNED.Models.RegistroPersonalAdministrativo", b =>
                {
                    b.HasOne("ProyectoAppGestionCapacitacionesUNED.Models.CapacitacionPersonalAdministrativo", "CapacitacionPersonalAdministrativo")
                        .WithMany()
                        .HasForeignKey("CapacitacionPersonalAdministrativoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
