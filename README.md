# Pelos API

Repositorio con una API básica en ASP.NET Core para gestionar productos de petshop y una carpeta `pelosFront` con el frontend estático.

## Estructura del repositorio

- `pelosAPI/`
  - `Program.cs`: configuración de la aplicación, CORS, base de datos y OpenAPI.
  - `Controllers/ProductosController.cs`: puntos finales CRUD para productos.
  - `Data/AppDbContext.cs`: contexto de Entity Framework Core con SQLite.
  - `Models/Producto.cs`: modelo de producto.
  - `wwwroot/`: carpeta que contiene el frontend estático (HTML, CSS, assets) y las imágenes subidas.
    - `index.html`: página principal del frontend.
    - `uploads/`: carpeta para almacenar las imágenes subidas desde la API.

## Características

- API REST con controlador `api/productos`.
- Frontend estático integrado (HTML, CSS, JavaScript) servido desde `wwwroot/`.
- Operaciones soportadas:
  - `GET /api/productos`: obtener todos los productos.
  - `POST /api/productos`: crear un producto (incluye subida de imagen opcional).
  - `PUT /api/productos/{id}`: actualizar un producto.
  - `DELETE /api/productos/{id}`: eliminar un producto.
  - `PATCH /api/productos/{id}/stock`: actualizar el stock de un producto.
- Base de datos SQLite local: `peluqueria.db`.
- CORS habilitado para permitir llamadas desde el frontend.
- `wwwroot` configurado para servir archivos estáticos e imágenes.

## Requisitos

- .NET SDK 10.0 o superior.

## Ejecutar localmente

1. Abrir una terminal en `pelosAPI`.
2. Ejecutar:
   ```bash
   dotnet run
   ```
3. La aplicación quedará disponible en `http://localhost:5209` (por defecto).
4. El frontend cargará automáticamente al acceder a la URL raíz (`http://localhost:5209`).
5. La API está disponible en `http://localhost:5209/api/productos`.

## Notas

- Al arrancar, la aplicación crea la base de datos y las tablas si aún no existen.
- Si no se sube imagen al crear un producto, se usa `uploads/default.jpg` como valor predeterminado.
- El frontend estático se encuentra integrado en `wwwroot/` y se sirve automáticamente junto con la API.
- `UseDefaultFiles()` en `Program.cs` permite servir `index.html` al acceder a la raíz de la aplicación.
