﻿using Microsoft.EntityFrameworkCore;
using ParkingControl.Domain.Entities;
using ParkingControl.Infra.Data.Context;
using ParkingControl.Infra.Data.IRepositories;

namespace ParkingControl.Infra.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly MySQLContext _context;

        public VeiculoRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<List<Veiculo>> BuscarTodos()
        {
            var result = _context.Veiculos;
            return await result.ToListAsync();
        }

        public async Task<int> Salvar(Veiculo veiculo)
        {
            veiculo.Placa.ToUpper();

            _context.Veiculos.Add(veiculo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Editar(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Deletar(Veiculo veiculo)
        {
            _context.Veiculos.Remove(veiculo);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Veiculo>> BuscarPorPlaca(string placa)
        {
            return await _context.Veiculos.Where(v => v.Placa.ToUpper().Contains(placa.ToUpper())).ToListAsync();
        }

        public async Task<Veiculo> BuscarPeloId(int id)
        {
            var resultado = await _context.Veiculos.FindAsync(id);
            return resultado != null ? resultado : new Veiculo();
        }
    }
}
