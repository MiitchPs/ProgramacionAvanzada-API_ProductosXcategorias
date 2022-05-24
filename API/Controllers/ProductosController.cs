using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllProductos")]
        public ActionResult<List<Productos>> GetAllProductos()
        {
            var productos = _context.Productos.ToList();
            return Ok(productos);
        }

        [HttpPost]
        [Route("AddProducto")]
        public ActionResult AddProducto(ProductosDTO P)
        {
            Productos Prod = new Productos()
            {
                Nombre = P.Nombre,
                Descripcion = P.Descripcion,
                Precio = P.Precio,
                stock = P.stock,
                Imagen = P.Imagen,
                CategoriasId = P.CategoriasId
            };
            _context.Productos.Add(Prod);    
            _context.SaveChanges();
            return Ok();
        }



        [HttpPut]
        [Route("UptProducto")]
        public ActionResult UptProducto(ProductosDTO ProdDTO)
        {
            var Prod = _context.Productos.FirstOrDefault(e => e.Id == ProdDTO.Id);
            if (Prod == null) return BadRequest();

            Prod.Nombre = ProdDTO.Nombre;
            Prod.Descripcion = ProdDTO.Descripcion;
            Prod.Precio = ProdDTO.Precio;
            Prod.stock = ProdDTO.stock;
            Prod.Imagen = ProdDTO.Imagen;
            Prod.CategoriasId = ProdDTO.CategoriasId;

            _context.Productos.Update(Prod);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("DelProducto")]
        public ActionResult DelProducto(int id)
        {
            var Prod = _context.Productos.FirstOrDefault(e => e.Id == id);
            if (Prod == null) return BadRequest();
            _context.Remove(Prod);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("GetProductosXId")]
        public ActionResult GetProductosXId(int Id)
        {
            var Prod = _context.Categorias.FirstOrDefault(d => d.Id == Id);

            if (Prod == null) return BadRequest();
            return Ok(Prod);
        }


        [HttpGet]
        [Route("GetProductoXcate")]
        public async Task<ActionResult> GetProductoByCate(int id)
        {

            var productos = await _context.Productos.Where(e => e.CategoriasId == id).ToListAsync();
            return Ok(productos);

        }

    











    }
}
