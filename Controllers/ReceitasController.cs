using Receitas_Fiap.Models;
using Receitas_Fiap.View.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Receitas_Fiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ILogger<ReceitasController> _logger;
        private readonly IReceitaService  _ReceitaService;

        private readonly ReceitasContext _context;

        public ReceitasController(ReceitasContext context,
                                ILogger<ReceitasController> logger,
                                IReceitaService ReceitaService)
        {
            _ReceitaService = ReceitaService;
            _logger = logger;
            _context = context;
        }

        [HttpGet("")]
        public IActionResult GetReceitas()
        {
            var res =  _ReceitaService.GetReceita();

            _logger.LogTrace($"Controller: ReceitaController - Action: GetReceitas - Passo: Inicio - data={res}.");
            _logger.LogInformation(res.ToString());

            var listaReceitas = JsonConvert.SerializeObject(res);

            return Ok(listaReceitas);
        }


        [HttpGet("{id}")]
        public IActionResult GetReceitaID(int id)
        {
            var res =  _ReceitaService.GetReceitaId(id);

            _logger.LogTrace($"Controller: ReceitaController - Action: GetReceitaID - Passo: Inicio - data={res}.");
            _logger.LogInformation(res.ToString());

            return Ok(res);
        }

        [HttpPut("atualizarReceita")]
        public IActionResult PutReceita(ReceitasModel Receita)
        {
                                 
            var res = _ReceitaService.UpdateReceita(Receita);

            _logger.LogTrace($"Controller: ReceitaController - Action: GetReceitaID - Passo: Inicio - data={res}.");
            _logger.LogInformation(res.ToString());

            return GetReceitaID(Receita.Id);
        }

        [HttpPost("salvarReceita")]
        public IActionResult PostReceita([FromBody] ReceitasModel Receita)
        {
            _ReceitaService.SaveReceita(Receita);

            _logger.LogTrace($"Controller: ReceitaController - Action: PostReceita - Passo: Inicio - data={Receita}.");
            _logger.LogInformation(Receita.ToString());

            return GetReceitas();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReceita(int id)
        {
            _ReceitaService.DeleteReceita(id);
            return GetReceitas();
        }

    }
}
