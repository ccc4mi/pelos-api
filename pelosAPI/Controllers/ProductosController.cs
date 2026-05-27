using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pelosAPI.Data;
using pelosAPI.Models;

namespace pelosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductosController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env= env;
        }

        // GET: api/productos (Traer todos los productos)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // POST: api/productos (Alta de producto)
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromForm] string nombre, [FromForm] decimal precio, [FromForm] int stock, [FromForm] IFormFile? imagen)
        {
            string folderPath = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads");
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string fileUrl = "uploads/default.jpg"; // Imagen por defecto si no suben nada

            if (imagen != null && imagen.Length > 0)
            {
                //nombre único para evitar que se pisen los archivos
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagen.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }
                fileUrl = $"uploads/{fileName}";
            }

            var producto = new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Stock = stock,
                ImagenUrl = fileUrl
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductos), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, [FromForm] string nombre, [FromForm] decimal precio, [FromForm] int stock, [FromForm] IFormFile? imagen)
        {
            var productoDb = await _context.Productos.FindAsync(id);
            if (productoDb == null) return NotFound();

            productoDb.Nombre = nombre;
            productoDb.Precio = precio;
            productoDb.Stock = stock;

            // reemplazo si se sube nueva img
            if (imagen != null && imagen.Length > 0)
            {
                string folderPath = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads");
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagen.FileName);
                string filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }
                productoDb.ImagenUrl = $"uploads/{fileName}";
            }

            _context.Entry(productoDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}/stock")]
        public async Task<IActionResult> PatchStock(int id, [FromBody] int nuevoStock)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            producto.Stock = nuevoStock;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}