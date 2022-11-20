using Microsoft.AspNetCore.Mvc;
using valinor_viagens_CSharp.Model;
using valinor_viagens_CSharp.Repository;

namespace valinor_viagens_CSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private int id_cliente;

        public UsuarioController(IUsuarioRepository repository) {
            _repository = repository;
        }

        [HttpGet("{id_cliente}")]
        public async Task<IActionResult> GetById(int id_cliente){
            var usuarios = await _repository.GetUsuarios();
            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

          [HttpGet]
        public async Task<IActionResult> GetAll(){
            var usuario = await _repository.GetUsuarioById(id_cliente);
            return usuario != null
            ? Ok(usuario) : NotFound("Usuario não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario){
           _repository.AddUsuario(usuario);
           return await _repository.SaveChangesAsync() 
           ? Ok("Cliente adicionado") : BadRequest("Algo deu errado."); 
        }   

        [HttpPut("{id_cliente}")] 
        public async Task<IActionResult> Atualizar(int id_cliente, Usuario usuario){
            var usuarioExiste = await _repository.GetUsuarioById(id_cliente);
            if (usuarioExiste == null) return NotFound("Cliente não encontrado!");

            usuarioExiste.nome = usuario.nome ?? usuarioExiste.nome;
            usuarioExiste.cpf = usuario.cpf != new String()
            ? usuario.cpf : usuarioExiste.cpf;

            _repository.AtualizarUsuario(usuarioExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Cliente atualizado.") : BadRequest ("Algo deu errado.");

        }
        [HttpDelete("id_cliente")]
        public async Task<IActionResult> Delete(int id_cliente){
            var usuarioExiste = await _repository.GetUsuarioById(id_cliente);
            if (usuarioExiste == null) return NotFound("Cliente não encontrado!");

            _repository.DeletarUsuario(usuarioExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Cliente atualizado.") : BadRequest ("Algo deu errado.");

        } 

    }
}    

