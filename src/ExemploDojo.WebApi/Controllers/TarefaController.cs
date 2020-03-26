using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploDojo.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExemploDojo.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController : Controller
    {

        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public IEnumerable<Tarefa> GetAll()
        {
            return _tarefaRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTarefa")]
        public IActionResult GetById(long id)
        {
            var item = _tarefaRepository.Find(id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarefa item)
        {
            if (item == null)
                return BadRequest();

            _tarefaRepository.Add(item);
            return CreatedAtRoute("GetTarefa", new { id = item.Chave }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Tarefa item)
        {
            if (item == null || item.Chave != id)
            {
                return BadRequest();
            }

            var tarefa = _tarefaRepository.Find(id);
            if (tarefa == null)
                return NotFound();

            tarefa.Nome = item.Nome;
            tarefa.EstaCompleta = item.EstaCompleta;

            _tarefaRepository.Update(tarefa);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var tarefa = _tarefaRepository.Find(id);
            if (tarefa == null)
                return NotFound();

            _tarefaRepository.Remove(id);
            return new NoContentResult();
        }
    }
}