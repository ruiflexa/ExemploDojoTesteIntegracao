using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDojo.WebApi.Models
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefaContext _context;
        public TarefaRepository(TarefaContext context)
        {
            _context = context;
            Add(new Tarefa { Nome = "Item1" });
        }
        public IEnumerable<Tarefa> GetAll()
        {
            return _context.TarefaItens.ToList();
        }
        public void Add(Tarefa item)
        {
            _context.TarefaItens.Add(item);
            _context.SaveChanges();
        }
        public Tarefa Find(long key)
        {
            return _context.TarefaItens.FirstOrDefault(t => t.Chave == key);
        }
        public void Remove(long key)
        {
            var entity = _context.TarefaItens.First(t => t.Chave == key);
            _context.TarefaItens.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(Tarefa item)
        {
            _context.TarefaItens.Update(item);
            _context.SaveChanges();
        }
    }
}
