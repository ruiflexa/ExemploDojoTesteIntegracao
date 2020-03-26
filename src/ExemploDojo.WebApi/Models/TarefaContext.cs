using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploDojo.WebApi.Models
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options)
            : base(options)
        { }
        public DbSet<Tarefa> TarefaItens { get; set; }
    }
}
