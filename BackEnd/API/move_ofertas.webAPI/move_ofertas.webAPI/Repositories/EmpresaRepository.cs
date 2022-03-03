using move_ofertas.webAPI.Contexts;
using move_ofertas.webAPI.Domains;
using move_ofertas.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace move_ofertas.webAPI.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        MoveOfertasContext ctx = new MoveOfertasContext();

        public void Atualizar(int id, Empresa empresaAtualizada)
        {
            Empresa empresaBuscada = BuscarPorId(id);

            if (empresaBuscada.NomeEmpresa != null)
            {
                empresaBuscada.NomeEmpresa = empresaAtualizada.NomeEmpresa;
                empresaBuscada.RazaoSocial = empresaAtualizada.RazaoSocial;
                empresaBuscada.Endereco = empresaAtualizada.Endereco;
                empresaBuscada.Cnpj = empresaAtualizada.Cnpj;
                empresaBuscada.Telefone = empresaAtualizada.Telefone;
            }

            ctx.Empresas.Update(empresaBuscada);

            ctx.SaveChanges();
        }

        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresas.FirstOrDefault(e => e.IdEmpresa == id);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            ctx.Empresas.Add(novaEmpresa);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Empresa empresaBuscada = BuscarPorId(id);

            ctx.Empresas.Remove(empresaBuscada);

            ctx.SaveChanges();
        }

        public List<Empresa> ListarTodos()
        {
            return ctx.Empresas.ToList();
        }
    }
}
