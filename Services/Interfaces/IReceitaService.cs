using Receitas_Fiap.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receitas_Fiap.View.Interfaces
{
    public interface IReceitaService
    {
        List<ReceitasModel> GetReceita();
        ReceitasModel GetReceitaId(int id);
        void SaveReceita(ReceitasModel Receita);
        void DeleteReceita(int id);
        Task UpdateReceita(ReceitasModel Receita);        
    }
}
