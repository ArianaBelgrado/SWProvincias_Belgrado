using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Belgrado.Models;

namespace SWAdventureWorks_Belgrado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly AdventureWorks2019Context context;

        public CreditCardController(AdventureWorks2019Context context)
        {
            this.context = context;
        }
        // Get
        [HttpGet]
        public ActionResult<IEnumerable<CreditCard>> GetClinica()
        {
            return context.CreditCard.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CreditCard> GetbyId(int id)
        {
            CreditCard creditCard = (from c in context.CreditCard
                                     where c.CreditCardId == id
                                     select c).SingleOrDefault();

            return creditCard;

        }

        [HttpGet("listado/{type}")]
        public ActionResult<IEnumerable<CreditCard>> GetbyType(string type)
        {
            List<CreditCard> creditCard = (from c in context.CreditCard
                                           where c.CardType == type
                                           select c).ToList();
            return creditCard;
        }

        //UPDATE
        //PUT api/creditCard/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, CreditCard ciudaCreditCardes)
        {
            if (id != ciudaCreditCardes.CreditCardId)
            {
                return BadRequest();
            }

            context.Entry(ciudaCreditCardes).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //INSERT
        [HttpPost]
        public ActionResult Post(CreditCard ciudaCreditCardes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.CreditCard.Add(ciudaCreditCardes);
            context.SaveChanges();
            return Ok();
        }
    }
}
