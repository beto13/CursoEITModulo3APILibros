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
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AutoresController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return dbContext.Autores.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var resultado = dbContext.Autores.FirstOrDefault(x => x.Id == id);

            if (resultado == null)
            { return NotFound(); }

            return resultado;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            dbContext.Autores.Add(autor);
            dbContext.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value)
        {
            if (id != value.Id)
            {
                BadRequest();
            }

            dbContext.Entry(value).State = EntityState.Modified;
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var resultado = dbContext.Autores.FirstOrDefault(x => x.Id == id);

            if (resultado == null)
            { return NotFound(); }

            dbContext.Autores.Remove(resultado);
            dbContext.SaveChanges();
            return resultado;
        }
    }
}
