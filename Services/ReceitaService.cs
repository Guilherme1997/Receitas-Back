using Receitas_Fiap.Models;
using Receitas_Fiap.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receitas_Fiap.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly ReceitasContext _context;
        public ReceitaService(ReceitasContext context)
        {
            _context = context;
        }

        public List<ReceitasModel> GetReceita()
        {
            try
            {
                var list = _context.Receitas.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro em GetReceita : {ex.Message}");
            }
        }

        public ReceitasModel GetReceitaId(int id)
        {
            try
            {
                var res = _context.Receitas.Find(id);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro em GetReceitaID : {ex.Message}");
            }
        }


        public void SaveReceita(ReceitasModel Receita)
        {
            try
            {
                 _context.Receitas.Add(Receita);
                  _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro em SaveReceita : {ex.Message}");
            }
        }


        public Task UpdateReceita(ReceitasModel Receita)
        {
            _context.Update(Receita);
            _context.SaveChanges();

            return Task.CompletedTask;

        }
       

        public void DeleteReceita(int id)
        {
            try
            {
                ReceitasModel Receita = GetReceitaId(id);
                _context.Remove(Receita);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro em DeleteReceita : {ex.Message}");
            }

        }
    }
}
