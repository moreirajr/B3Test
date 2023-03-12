using B3Test.Api.Constants;
using B3Test.Application.Features.AdicionarTarefas;
using B3Test.Application.Features.ListarTarefas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace B3Test.Api.Controllers
{
    [ApiController]
    [ApiVersion(Resources.v1)]
    [Route(Resources.defaultRoute)]
    public class TarefasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TarefasController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator), "Mediator cannot be null");
        }

        [HttpPost]
        [ProducesResponseType(typeof(AdicionarTarefaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarTarefas([FromBody] AdicionarTarefaRequest request)
        {
            var commandResult = await _mediator.Send(new AdicionarTarefaCommand(request));
            if (commandResult == null) return BadRequest(Resources.error);
            return Ok(commandResult);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListarTarefaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarTarefas([FromQuery] ListarTarefaRequest request)
        {
            var queryResult = await _mediator.Send(new ListarTarefaQuery(request));
            if (queryResult == null) return BadRequest(Resources.error);
            return Ok(queryResult);
        }
    }
}
