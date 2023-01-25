using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Belgrado.Data;
using SWProvincias_Belgrado.Models;

namespace SWProvincias_Belgrado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly DBPaisFinalContext context;

        public CiudadController(DBPaisFinalContext context)
        {
            this.context = context;
        }
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> GetClinica()
        {
            return context.Ciudades.ToList();
        }
        //UPDATE
        //PUT api/ciudad/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }

            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }

        //DELETE
        //DELETE api/ciudad/{id}
        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudad = (from c in context.Ciudades
                          where c.IdCiudad == id
                          select c).SingleOrDefault();

            if (ciudad == null)
            {
                return NotFound();
            }

            context.Ciudades.Remove(ciudad);
            context.SaveChanges();

            return ciudad;
        }
    }
}
