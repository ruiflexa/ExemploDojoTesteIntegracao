using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDojo.WebApi.Models
{
    public interface ITarefaRepository
    {
        void Add(Tarefa item);
        IEnumerable<Tarefa> GetAll();
        Tarefa Find(long key);
        void Remove(long key);
        void Update(Tarefa item);
    }
}
