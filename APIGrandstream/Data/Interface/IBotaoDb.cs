using APIGrandstream.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGrandstream.Data.Interface
{
    public interface IBotaoDb
    {
        Task<List<Botao>> Botoes();
        Task<List<Botao>> BotoesPorId(int Id);
        Task<Botao> Insert(Botao botao);
        Task<Botao> Update(Botao botao);
        Task<Botao> Delete(Botao botao);

    }
}
