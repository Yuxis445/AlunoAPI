using AlunoApi.Model;
using AlunoApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AlunoApi.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class AlunosCrontroller : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosCrontroller(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos(){
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch{
                //return BadRequest("Request invalido");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome){
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);

                if( alunos.Count()==0)
                    return NotFound($"Não existem alunos com o criterio {nome}");

                return Ok(alunos);
            }
            catch{
                return BadRequest("Request invalido");
            }
        }

        [HttpGet("{id:int}", Name="GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id){
            try
            {
                var aluno = await _alunoService.GetAluno(id);

                if( aluno == null)
                    return NotFound($"Não existem aluno com o id= {id}");

                return Ok(aluno);
            }
            catch{
                return BadRequest("Request invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno){

            try
            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id}, aluno);
            }
            catch{
                return BadRequest("Request invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Aluno aluno){
            //no put sempre tem q passar todos os dados mesmo aqueles que nao forem alterados.
            try
            {
                if( aluno.Id == id){
                    await _alunoService.UpdateAluno(aluno);
                    return NoContent();
                } else{
                    return BadRequest("Dados Invalidos");
                }
            }
            catch{
                return BadRequest("Request invalido");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id){
            try
            {
               var aluno = await _alunoService.GetAluno(id);
               if(aluno != null){
                   await _alunoService.DeleteAluno(aluno);
                   return Ok($"Aluno de id={id} foi excluido com sucesso");
               } else{
                   return NotFound("Aluno nao encontrado");
               }
            }
            catch{
                return BadRequest("Request invalido");
            }

        }

    }
}