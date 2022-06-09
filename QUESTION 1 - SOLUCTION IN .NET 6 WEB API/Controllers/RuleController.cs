using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;

namespace Rule.Controllers
{
    [ApiController]
    public class RuleController : ControllerBase
    {


        [HttpGet]
        [Route("rules/")]
        public IActionResult Get([FromServices] TestDbContext context)
        {
            return Ok(context.Rules.ToList());
        }


        [HttpGet]
        [Route("rules/{id:Guid}")]
        public IActionResult Get(
            [FromServices] TestDbContext context,
            [FromRoute] Guid id)
        {
            var rule = context.Rules.FirstOrDefault(x => x.Id.Equals(id));
            if (rule == null)
                return NotFound();

            return Ok(rule);

        }

        [HttpPost("rules/")]
        public IActionResult Post(
            [FromServices] TestDbContext context,
            [FromBody] RuleModelPost rule)
        {
            RuleModel model = new RuleModel();

            model.MinValue = rule.MinValue;
            model.MaxValue = rule.MaxValue;
            model.ClientSector = rule.ClientSector.ToUpper();
            model.CategoryRisk = rule.CategoryRisk.ToUpper();

            context.Rules.Add(model);
            context.SaveChanges();

            return Created($"/{model.Id}", model);
        }

        [HttpPut]
        [Route("rules/{id:Guid}")]
        public IActionResult Put(
            [FromServices] TestDbContext context,
            [FromRoute] Guid id,
            [FromBody] RuleModelPut rule)
        {
            var model = context.Rules.FirstOrDefault(x => x.Id.Equals(id));
            if (model == null)
                return NotFound();

            model.MinValue = rule.MinValue;
            model.MaxValue = rule.MaxValue;
            model.ClientSector = rule.ClientSector.ToUpper();
            model.CategoryRisk = rule.CategoryRisk.ToUpper();

            context.Rules.Update(model);
            context.SaveChanges();
            return Ok(model);

        }

        [HttpDelete]
        [Route("rules/{id:Guid}")]
        public IActionResult Delete(
            [FromServices] TestDbContext context,
            [FromRoute] Guid id)
        {
            var model = context.Rules.FirstOrDefault(x => x.Id.Equals(id));
            if (model == null)
                return NotFound();


            context.Rules.Remove(model);
            context.SaveChanges();
            return Ok(model);

        }

    }
}