using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Moreno.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace SWAdventureWorks_Moreno.Controllers
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

        [HttpGet]
        public ActionResult<IEnumerable<CreditCard>> Get()
        {
            return context.CreditCards.ToList();
        }

        [HttpGet("type/{cardType}")]
        public ActionResult<IEnumerable<CreditCard>> Get(string cardType)
        {
            List<CreditCard> creditCards = (from c in context.CreditCards
                                            where c.CardType == cardType
                                            select c).ToList();

            return creditCards;
        }

        [HttpGet("{id}")]
        public ActionResult<CreditCard> GetById(int id)
        {

            return context.CreditCards.Find(id);

        }

        [HttpPost]
        public ActionResult Post(CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.CreditCards.Add(creditCard);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreditCard creditCard)
        {
            if (id != creditCard.CreditCardId)
            {
                return BadRequest();
            }
            context.Entry(creditCard).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<CreditCard> Delete(int id)
        {
            var creditCard = (from c in context.CreditCards
                             where c.CreditCardId == id
                             select c).SingleOrDefault();

            if (creditCard == null)
            {
                return NotFound();
            }
            context.CreditCards.Remove(creditCard);
            context.SaveChanges();

            return creditCard;
        }

    }
}
