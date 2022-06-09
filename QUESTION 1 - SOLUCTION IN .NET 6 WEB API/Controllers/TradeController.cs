
using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;
using Test.Functions;

namespace Trade.Controllers
{

    [ApiController]
    public class TradeController : ControllerBase
    {


        [HttpGet]
        [Route("trades/")]
        public IActionResult Get([FromServices] TestDbContext context)
        {
            return Ok(context.Trades.ToList());
        }


        [HttpGet]
        [Route("trades/{id:Guid}")]
        public IActionResult Get(
            [FromServices] TestDbContext context,
            [FromRoute] Guid id)
        {
            var trade = context.Trades.FirstOrDefault(x => x.Id.Equals(id));
            if (trade == null)
                return NotFound();

            return Ok(trade);

        }

        [HttpPost("trades/")]
        public IActionResult Post(
            [FromServices] TestDbContext context,
            [FromBody] List<TradeModelPost> trades)
        {

            TradeModel trade = new TradeModel();
            List<TradeModelRisk> risks = new List<TradeModelRisk>();
            DateTime paramDate = DateTime.Now;

            foreach (var item in trades)
            {
                if (item.Value == 0)
                {
                    return NotFound("Valor de transação não pode ser zerado.");
                }

                trade.ClientSector = item.ClientSector;
                trade.Value = item.Value;

                trade.CategoryRisk = RiskTrade.getCategoryRisk(item.Value, item.ClientSector, context).ToUpper();

                if (string.IsNullOrEmpty(trade.CategoryRisk))
                {
                    return NotFound("Não é possíve calcular o risco dessa transação com as informações fornecidas!");
                }

                TradeModelRisk risk = new TradeModelRisk();
                risk.CategoryRisk = trade.CategoryRisk.ToUpper();
                risks.Add(risk);

                context.Trades.Add(trade);
            }

            context.SaveChanges();

            return Created("/", risks);
        }

        [HttpPut]
        [Route("trades/{id:Guid}")]
        public IActionResult Put(
            [FromServices] TestDbContext context,
            [FromRoute] Guid id,
            [FromBody] TradeModelPut trade)
        {

            if (trade.Value == 0)
            {
                return NotFound("Valor de transação não pode ser zerado.");
            }

            var model = context.Trades.FirstOrDefault(x => x.Id.Equals(id));
            if (model == null)
                return NotFound();

            model.Value = trade.Value;
            model.ClientSector = trade.ClientSector;
            trade.CategoryRisk = RiskTrade.getCategoryRisk(trade.Value, trade.ClientSector, context).ToUpper();

            if (string.IsNullOrEmpty(trade.CategoryRisk))
            {
                return NotFound("Regra de risco inexistente para o tipo de transação!");
            }

            context.Trades.Update(model);
            context.SaveChanges();
            return Ok(model);

        }

        [HttpDelete]
        [Route("trades/{id:Guid}")]
        public IActionResult Delete(
            [FromServices] TestDbContext context,
            [FromRoute] Guid id)
        {
            var model = context.Trades.FirstOrDefault(x => x.Id.Equals(id));
            if (model == null)
                return NotFound();


            context.Trades.Remove(model);
            context.SaveChanges();
            return Ok(model);

        }


    }
}