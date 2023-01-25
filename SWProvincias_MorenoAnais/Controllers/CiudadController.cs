using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_MorenoAnais.Data;
using SWProvincias_MorenoAnais.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_MorenoAnais.Controllers
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


        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get(int edad)
        {

            return context.Ciudades.ToList();

        }


        [HttpPost]
        public ActionResult Post(Ciudad ciudades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudades);
            context.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ciudad ciudades)
        {
            if (id != ciudades.Id)
            {
                return BadRequest();
            }
            context.Entry(ciudades).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudades = (from c in context.Ciudades
                             where c.Id == id
                             select c).SingleOrDefault();

            if (ciudades == null)
            {
                return NotFound();
            }
            context.Ciudades.Remove(ciudades);
            context.SaveChanges();

            return ciudades;
        }


    }
}
