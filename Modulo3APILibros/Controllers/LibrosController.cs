using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modulo3APILibros.Data;
using Modulo3APILibros.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Modulo3APILibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public LibrosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return dbContext.Libros.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerLibro")]
        public ActionResult<Libro> Get(int id)
        {
            var resultado = dbContext.Libros.FirstOrDefault(x => x.Id == id);

            if (resultado == null)
            { return NotFound(); }

            return resultado;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Libro libro)
        {
            dbContext.Libros.Add(libro);
            dbContext.SaveChanges();
            return new CreatedAtRouteResult("ObtenerLibro", new { id = libro.Id }, libro);
        }

        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var resultado = dbContext.Libros.FirstOrDefault(x => x.Id == id);

            if (resultado == null)
            { return NotFound(); }

            dbContext.Libros.Remove(resultado);
            dbContext.SaveChanges();
            return resultado;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro value)
        {
            if (id != value.Id)
            {
                BadRequest();
            }

            dbContext.Entry(value).State = EntityState.Modified;
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
