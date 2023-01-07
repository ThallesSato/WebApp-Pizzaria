using Contoso.Database;
using Contoso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace Contoso.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        // GET
        [HttpGet]
        public IEnumerable<Pizza> GetPizzas()
        {
            using (var dbContext = new AppDbContext())
            {
                return dbContext.Pizzas.ToList();
            }
        }
        // GET by Id action
        [HttpGet("{id}")]
        public IActionResult GetPizza(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var Pizza = dbContext.Pizzas.Find(id);
                if (Pizza == null)
                {
                    return NotFound("Pizza não encontrada.");
                }
                return Ok(Pizza);
            }
        }
        // Insere nova pizza no bd
        [HttpPost]
        public IActionResult PostPizza(Pizza pizza)
        {
            using (var dbContext = new AppDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                pizza.Created = DateTime.Now;
                dbContext.Pizzas.Add(pizza);
                dbContext.SaveChanges();

                return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);

            }
        }
        // Atualiza a pizza
        [HttpPut("{id}")]
        public IActionResult PutPizza(int id, Pizza pizza)
        {
            using (var dbContext = new AppDbContext())
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var oldpizza = dbContext.Pizzas.Find(id);
                if (oldpizza == null)
                {
                    return NotFound("Pizza não encontrada para ser atualizada.");
                }
                if(pizza.Id == 0)
                {
                    pizza.Id = id;
                }
                if(oldpizza.Id != pizza.Id)
                {
                    return BadRequest("O id não pode ser alterado");
                }

                oldpizza.Name = pizza.Name;
                oldpizza.Temglutem = pizza.Temglutem;
                oldpizza.Price= pizza.Price;
                oldpizza.Desc= pizza.Desc;
                dbContext.Pizzas.Update(oldpizza);
            
                dbContext.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var pizza = dbContext.Pizzas.Find(id);
                if (pizza == null)
                {
                    return NotFound("Pizza não encontrada.");
                }
                dbContext.Pizzas.Remove(pizza);
                dbContext.SaveChanges();
                return Ok();
            }
        }
    }

    //public PizzaController()
    //{
    //}

    //[HttpGet]
    //public ActionResult<List<Pizza>> GetAll() =>
    //PizzaService.GetAll();

    //// GET by Id action
    //[HttpGet("{id}")]
    //public ActionResult<Pizza> Get(int id)
    //{
    //    var pizza = PizzaService.Get(id);

    //    if (pizza == null)
    //        return NotFound();

    //    return pizza;
    //}

    //// POST action
    //[HttpPost]
    //public ActionResult Create(Pizza pizza)
    //{
    //    PizzaService.Add(pizza);
    //    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);

    //    // This code will save the pizza and return a result
    //}

    //// PUT action
    //[HttpPut("{id}")]
    //public ActionResult Update(int id, Pizza pizza)
    //{
    //    if (id != pizza.Id)
    //        return BadRequest();

    //    var existingPizza = PizzaService.Get(id);
    //    if (existingPizza is null)
    //        return NotFound();

    //    PizzaService.Update(pizza);

    //    return NoContent();

    //    // This code will update the pizza and return a result
    //}

    //// DELETE action
    //[HttpDelete("{id}")]
    //public ActionResult Delete(int id)
    //{
    //    var pizza = PizzaService.Get(id);

    //    if (pizza is null)
    //        return NotFound();

    //    PizzaService.Delete(id);

    //    return NoContent();

    //    // This code will delete the pizza and return a result
    //}
}
