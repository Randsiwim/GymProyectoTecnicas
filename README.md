Título del Proyecto: Sistema de Gestión de Gimnasio
Autor: Randsiwim Lopez Orozco
Fecha de entrega: 27/11/24
Versión del proyecto: v1.0

 Introducción
Objetivo del Proyecto: 
Este proyecto tiene como objetivo crear un sistema de gestión para un gimnasio que permite administrar usuarios, clases, reservas, facturación y más, facilitando el manejo de la operación diaria.
Alcance del Proyecto: 
El sistema permite la gestión de entrenadores, clases programadas, usuarios (clientes y entrenadores), facturación, reservas de clases y la visualización de reportes.
Tecnologías Utilizadas
Lenguaje de programación: C#
Plataforma: Windows Forms (WinForms)

Herramientas y librerías:
Visual Studio (como IDE)
JSON para almacenamiento de datos

Diagrama de Arquitectura
Incluye un diagrama de la arquitectura del sistema, que puede incluir:
Interfaz de usuario (WinForms)
Lógica de negocio (clases y métodos)


Estructura del Proyecto
Model
C# Clase.cs
C# ClienteManager.cs
C# Equipo.cs
C# Factura.cs
C# Usuario.cs

proyectoGym
clientes.json
facturas.json
FormClases.cs
Form Factura.cs
FormInventario.cs
FormLogin.cs
FormMain.cs
Form Membresias.cs
FormReportes.cs
FormReservas.cs

Cómo Usar el Sistema
Iniciar sesión y registrar usuarios:
Cuando inicie el sistema se le pedirá que inicie sesión con Admin pass123. Si es un nuevo usuario, podrán registrarlo desde el formulario de registro.
Gestionar entrenadores y clases:
Como administrador, podrá agregar entrenadores y asignarles horarios a través del formulario correspondiente.

10. Problemas Conocidos
Login no se ingresa con los usuarios solo con Admin
Usuarios no se quedan guardados 
Membresias no muestra los usuarios para renovar membresias
Reservas no se guardan a aun usuario y no tiene funcionalidad boton ver reservas 
Inventario no queda guardado en un archivo 
Reportes no esta conectado a solo rol entrenador  y falto implementar su logica 
Facturas falto que queden almacenadas  y que se muestren una por mes y logica detras

Conclusiones
El sistema a pesar de falta de cosas se pudo implementar bastante se identificaron errores y se espera poder corregirilos .

Futuras Mejoras
Correccion de todos los problemas mencionados          
