using APIGrandstream.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGrandstream.Data.Interface
{
    public interface ILeitoDb
    {
        Task<List<Leito>> Leitos(string console);
    }
}
