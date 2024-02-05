# ProyectoGestionCapacitacionesUNED
Proyecto para la creación de una página web para gestionar capacitaciones y generar reportes en base a la información almacenada sobre estas capacitaciones.

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

Por medio de esta página web se pueden crear, buscar y eliminar capacitaciones según el público seleccionado (estudiantes, personal académico, personal administrativo), a cada 
capacitación se le pueden ingresar personas interesadas en asistir a las capacitaciones, esto por medio de un Excel que se sube a la página con los datos ordenados de las personas que quieren asistir.

Por medio de un módulo de asistencia se puede obtener la cantidad de personas inscritas a un curso, este módulo contiene casillas que se pueden seleccionar indicando las personas que realmente
asistieron.

Por medio de un módulo de encuestas que permite subir un documento Excel con datos ordenados sobre diferentes aspectos sobre la capacitación, una vez subido la página puede mostrar
una serie de estadísticas correspondientes a la capacitación.

Este proyecto tiene la funcionabilidad de convertir reportes mostrados en pantalla a formato PDF y también posee la funcionabilidad de autenticación por roles de forma que personas con el rol de administrador puede agregar personas
para que puedan ingresar y las que tienen rol normal solo pueden ingresar a la página, y un módulo de configuración de usuario donde la contraseña puede ser cambiada cuando el usuario lo desee.

