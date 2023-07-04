using Microsoft.EntityFrameworkCore;
using ParkingControl.Domain.Entities;
using ParkingControl.Infra.Data.Context;
using ParkingControl.Infra.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Infra.Data.Repositories
{
    public class VeiculoRepository: IVeiculoRepository
    {
        private readonly MySQLContext _context;

        public VeiculoRepository(MySQLContext context)
        {
            _context = context;
        }

        public Task<Veiculo> BuscarPorPlaca(string placa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Veiculo>> BuscarTodos()
        {
            var query = await _context.Veiculos.ToListAsync();
            return query;
        }

        public Task<int> Deletar(Veiculo veiculo)
        {
            _context.Veiculos.Remove(veiculo);
            return _context.SaveChangesAsync();
        }

        public Task<int> Editar(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public Task<int> Salvar(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public async Task<Veiculo> BuscarPeloId(int id)
        {
            return await _context.Veiculos.FindAsync(id);            
        }
    }
}
