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
    public class ProvinciaController : ControllerBase
    {
        private readonly DBPaisFinalContext context;

        public ProvinciaController(DBPaisFinalContext context)
        {
            this.context = context;
        }
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> GetClinica()
        {
            return context.Provincias.ToList();
        }
        //UPDATE
        //PUT api/provincia/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, Provincia provincia)
        {
            if (id != provincia.ProvinciaId)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Provincias.Add(provincia);
            context.SaveChanges();
            return Ok();
        }

        //DELETE
        //DELETE api/provincia/{id}
        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = (from c in context.Provincias
                          where c.ProvinciaId == id
                          select c).SingleOrDefault();

            if (provincia == null)
            {
                return NotFound();
            }

            context.Provincias.Remove(provincia);
            context.SaveChanges();

            return provincia;
        }
    }
}

