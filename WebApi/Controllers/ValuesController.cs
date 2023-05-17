using Contoso.Database;
using Contoso.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PizzaController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public IEnumerable<Pizza> GetPizzas()
        {
            {
                return _context.Pizzas.ToList();
            }
        }
        // GET by Id action
        [HttpGet("{id}")]
        public IActionResult GetPizza(int id)
        {
            {
                var Pizza = _context.Pizzas.Find(id);
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
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                pizza.Created = DateTime.Now;
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);

            }
        }
        // Atualiza a pizza
        [HttpPut("{id}")]
        public IActionResult PutPizza(int id, Pizza pizza)
        {
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var oldpizza = _context.Pizzas.Find(id);
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
                _context.Pizzas.Update(oldpizza);

                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            {
                var pizza = _context.Pizzas.Find(id);
                if (pizza == null)
                {
                    return NotFound("Pizza não encontrada.");
                }
                _context.Pizzas.Remove(pizza);
                _context.SaveChanges();
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
