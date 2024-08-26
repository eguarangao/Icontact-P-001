# HorariosCRUD

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](https://github.com/tuusuario/HorariosCRUD)
[![License](https://img.shields.io/badge/license-MIT-blue)](https://opensource.org/licenses/MIT)

## Descripción

**HorariosCRUD** es una aplicación web desarrollada en C# utilizando Blazor WebAssembly y SQL Server como base de datos. Esta aplicación permite la gestión de horarios a través de un sistema CRUD (Crear, Leer, Actualizar y Eliminar), proporcionando una interfaz de usuario intuitiva y un backend robusto.

![Blazor WebAssembly](https://docs.microsoft.com/en-us/aspnet/core/blazor/media/webassembly.svg)
![SQL Server](https://upload.wikimedia.org/wikipedia/commons/8/87/Sql_data_base_with_logo.png)

## Características

- **Crear Horarios**: Registra horarios con detalles específicos.
- **Leer Horarios**: Visualiza la lista de horarios registrados en la base de datos.
- **Actualizar Horarios**: Modifica los horarios existentes según sea necesario.
- **Eliminar Horarios**: Elimina horarios que ya no sean necesarios.

## Tecnologías Utilizadas

- **Lenguaje de Programación**: C#
- **Frontend**: Blazor WebAssembly
- **Backend**: ASP.NET Core
- **Base de Datos**: SQL Server

## Instalación

1. **Clonar el repositorio**
   ```bash
   [git clone https://github.com/tuusuario/HorariosCRUD.git](https://github.com/eguarangao/Icontact-P-001.git)
## Base de Datos

1. **Configuración de la Base de Datos**

   - Asegúrate de tener SQL Server instalado y configurado.
   - Configura la cadena de conexión en el archivo `appsettings.json` para que apunte a tu instancia de SQL Server.

2. **Migración y Creación de la Base de Datos**

   - Abre la Consola del Administrador de Paquetes (Package Manager Console) en Visual Studio.

   - Ejecuta el siguiente comando para crear la primera migración, que generará el código necesario para crear las tablas en la base de datos:

     ```powershell
     Add-Migration InitialCreate
     ```

   - Luego, aplica la migración para crear la base de datos y sus tablas ejecutando el siguiente comando:

     ```powershell
     Update-Database
     ```

   Estos comandos generarán la base de datos necesaria y crearán todas las tablas definidas en tu modelo de datos.
