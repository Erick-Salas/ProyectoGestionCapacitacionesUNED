# ProyectoGestionCapacitacionesUNED
Proyecto de página web para gestionar capacitaciones y generar reportes en base a la información almacenada

Tecnologías utilizadas:
-	ASP.NET
-	C#
-	HTML
-	CSS
-	Javascript
-	Entity Framework
-	SQL Server
-	Bootstrap
- Ajax

Este proyecto fue creado con el fin de poder ser alojado en Azure, lo cual se hizo sin embargo por los altos costos que conllevaba esto se tuvo que suspender

Por medio de esta página web se pueden crear, buscar y eliminar capacitaciones según el público seleccionado (estudiantes, personal académico, personal administrativo), a cada 
capacitación se le pueden ingresar personas interesadas en asistir, esto por medio de un Excel que se sube a la página con los datos ordenados de las personas que quieren asistir,
luego por medio de un módulo de asistencia se puede obtener la cantidad de personas inscritas a un curso y por medio de checkbox se puede seleccionar las personas que realmente
asistieron, por medio de un módulo que permite subir un Excel con datos de cierta forma ordenados que representen los datos de una encuesta, una vez subido la página puede mostrar
una serie de estadísticas correspondientes a la capacitación.

El proyecto puede convertir reportes mostrados en pantalla a formato PDF y también posee autenticación de forma que personas con el rol de administrador puede agregar personas
para que puedan ingresar y las que tienen rol normal solo pueden ingresar a la página, la contraseña puede ser cambiada cuando el usuario lo desee.

