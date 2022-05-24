using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        private static List<Categorias> listaDepartamentos = new List<Categorias> {
            new Categorias {
                Id = 1,
                Nombre = "Hogar",
                Descripcion = "Mesa"
            }
        };

        [HttpGet]
        [Route("GetAllCategorias")]
        public ActionResult<List<Categorias>> GetAllCategorias()
        {
            return Ok(_context.Categorias.ToList());
        }

        [HttpGet]
        [Route("GetCategoriasXId")]
        public ActionResult GetDepartmentById(int Id)
        {
            var Dpto = _context.Categorias.FirstOrDefault(d => d.Id == Id);

            if (Dpto == null) return BadRequest();
            return Ok(Dpto);
        }


        [HttpGet]
        [Route("GetCategoriasXnombre")]
        public ActionResult GetCategoriasXnombre(string Nombre)
        {
            var Cate = _context.Categorias.FirstOrDefault(d => d.Nombre == Nombre);
            if (Cate == null) return BadRequest();
            return Ok(Cate);
        }



        [HttpPost]
        [Route("AddCategoria")]
        public ActionResult AddDepartment(CategoriasDTO D)
        {
            Categorias Dpto = new Categorias()
            {
                Id = D.Id,
                Nombre = D.Nombre,
                Descripcion = D.Descripcion
            };
            _context.Add(Dpto);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("UptCategoria")]
        public ActionResult UptDepartment(CategoriasDTO D)
        {
            var Dpto = _context.Categorias.FirstOrDefault(dpto => dpto.Id == D.Id);
            if (Dpto == null) BadRequest();
            else
            {
                Dpto.Nombre = D.Nombre;
                Dpto.Descripcion = D.Descripcion;
            }
            _context.Update(Dpto);
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete]
        [Route("DelCategoria")]
        public ActionResult DelDepartment(CategoriasDTO D)
        {
            var Dpto = _context
                .Categorias.FirstOrDefault(dept => dept.Id == D.Id);
            if (Dpto == null) return BadRequest();
            else
            {
                _context.Remove(Dpto);
                _context.SaveChanges();
                return Ok();
            }
        }










    }

}
