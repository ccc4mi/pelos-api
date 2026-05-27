# Pelos API

Repositorio con una API básica en ASP.NET Core para gestionar productos de peluquería y una carpeta `pelosFront` con el frontend estático.

## Estructura del repositorio

- `pelosAPI/`
  - `Program.cs`: configuración de la aplicación, CORS, base de datos y OpenAPI.
  - `Controllers/ProductosController.cs`: puntos finales CRUD para productos.
  - `Data/AppDbContext.cs`: contexto de Entity Framework Core con SQLite.
  - `Models/Producto.cs`: modelo de producto.
  - `wwwroot/uploads/`: carpeta para almacenar las imágenes subidas desde la API.
- `pelosFront/`
  - Archivo HTML, CSS y activos del frontend.

## Características

- API REST con controlador `api/productos`.
- Operaciones soportadas:
  - `GET /api/productos`: obtener todos los productos.
  - `POST /api/productos`: crear un producto (incluye subida de imagen opcional).
  - `PUT /api/productos/{id}`: actualizar un producto.
  - `DELETE /api/productos/{id}`: eliminar un producto.
  - `PATCH /api/productos/{id}/stock`: actualizar el stock de un producto.
- Base de datos SQLite local: `peluqueria.db`.
- CORS habilitado para permitir llamadas desde el frontend estático.
- `wwwroot` expuesto para servir imágenes y otros recursos estáticos.

## Requisitos

- .NET SDK 10.0 o superior.

## Ejecutar localmente

1. Abrir una terminal en `pelosAPI`.
2. Ejecutar:
   ```bash
   dotnet run
   ```
3. La API quedará disponible en el puerto que configure ASP.NET Core (por defecto `http://localhost:5000` o `https://localhost:5001`).

## Notas

- Al arrancar, la aplicación crea la base de datos y las tablas si aún no existen.
- Si no se sube imagen al crear un producto, se usa `uploads/default.jpg` como valor predeterminado.
- El frontend estático se encuentra en `pelosFront/` y puede consumirse directamente desde un servidor web o desde archivos locales si la configuración del navegador lo permite.
